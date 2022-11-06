using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private UnitAnimator _unitAnimator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _targetDistance;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _deathParticle;
    [SerializeField] private float _speed = 3f;

    private int _currentHealth;
    private IReadOnlyList<Unit> _targets;
    private Unit _target;

    public bool IsAlive { get; private set; }
    public float HitDistance => _hitDistance;
    public ParticleSystem DeathParticle => _deathParticle;
    public UnitAnimator UnitAnimator => _unitAnimator;
    public Unit Target => _target;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public float Health => _health;
    public float Speed => _speed;

    public event Action Waiting;
    public event Action TargetSearching;
    public event Action TargetAssigned;
    public event Action Fight;
    public event Action Died;

    public void Initialize(IReadOnlyList<Unit> enemies)
    {
        if (enemies == null)
            throw new ArgumentNullException("Unit is not initialized by enemies.");
        _currentHealth = _health;
        _targets = enemies;
    }

    private void OnEnable()
    {
        IsAlive = true;
    }

    public void SetTarget()
    {
        _target = GetTarget();
        if (_target == null)
        {
            Waiting?.Invoke();
            return;
        }
        _target.Died += OnTargetDied;
        TargetAssigned?.Invoke();
    }

    public void Damage(int damage)
    {
        if (damage < _currentHealth)
            _currentHealth -= damage;
        else
        {
            IsAlive = false;
            _currentHealth = 0;

            if (_target != null)
                _target.Died -= OnTargetDied;

            Died?.Invoke();
        }
    }

    public virtual void HitTarget()
    {
        if (_target != null)
        {
            if (_target.Health <= 0)
            {
                Waiting.Invoke();
            }
            else
                _target.Damage(_damage);
        }
    }

    public void StartFighting()
    {
        Fight?.Invoke();
    }

    public virtual void OnTargetDied()
    {
        _target.Died -= OnTargetDied;
        Waiting?.Invoke();
    }
    
    public void CheckDistanceToEnemy()
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            if (this is Enemy)
            {
                if (_targets[i] is Defender)
                    TrySearchTarget(i);
            }
            else if (this is Defender)
            {
                if (_targets[i] is Enemy)
                    TrySearchTarget(i);
            }
        }
    }

    public void SetDie()
    {
        Died?.Invoke();
    }

    public void SetWaiting()
    {
        Waiting?.Invoke();
    }

    private Unit TrySetTarget(int indexTarget, Unit nearestTarget, float distanceToNearestTarget)
    {
        float distanceToTarget = Vector3.Distance(transform.position, _targets[indexTarget].transform.position);
    
        if (distanceToTarget < distanceToNearestTarget)
        {
            nearestTarget = _targets[indexTarget];
            distanceToNearestTarget = distanceToTarget;
        }

        return nearestTarget;
    }
    
    //Need refactoring this method
    private Unit GetTarget()
    {
        Unit nearestTarget = null;
        float distanceToNearestTarget = float.MaxValue;
        
        if (this is Enemy)
        {
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets[i] is Defender && _targets[i].IsAlive)
                {
                    //TrySetTarget(i, nearestTarget, distanceToNearestTarget);
                    float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);
                    
                    if (distanceToTarget < distanceToNearestTarget)
                    {
                        nearestTarget = _targets[i];
                        distanceToNearestTarget = distanceToTarget;
                    }
                }
            }
            return nearestTarget;
        }
        else
        {
            for (int i = 0; i < _targets.Count; i++)
            {
                if (_targets[i] is Enemy && _targets[i].IsAlive)
                {
                    //TrySetTarget(i, nearestTarget, distanceToNearestTarget);
                    float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);
                    
                    if (distanceToTarget < distanceToNearestTarget)
                    {
                        nearestTarget = _targets[i];
                        distanceToNearestTarget = distanceToTarget;
                    }
                }
            }
            return nearestTarget;
        }
    }

    private void TrySearchTarget(int indexTarget)
    {
        float distanceToTarget = Vector3.Distance(transform.position, _targets[indexTarget].transform.position);

        if (distanceToTarget < _targetDistance && _targets[indexTarget].IsAlive)
        {
            TargetSearching?.Invoke();
        }
    }
    
    //The Event in Animation
    private void HandleDieAnimation()
    {
        gameObject.SetActive(false);
    }
}
