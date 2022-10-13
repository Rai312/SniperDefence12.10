using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Shooter : Defender
{
    [SerializeField] private BallisticsShoot _ballisticsShoot;
    [SerializeField] private BulletDefender _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private float _shootSpeed = 20f;

    public BallisticsShoot BallisticsShoot => _ballisticsShoot;
    public Bullet BulletPrefab => _bulletPrefab;

    private void TakeAim()
    {
        SetTarget();

        if (Target != null)
        {
            _ballisticsShoot.Shoot(Target.transform);
        }

        
        //Bullet bullet = Instantiate(_bulletPrefab, _shootPoint.transform.position, Quaternion.identity, null);

        //float distanceToTarget = Vector3.Distance(bullet.transform.position, Target.transform.position);
        //float shootTime = distanceToTarget / _shootSpeed;

        //bullet.transform.DOMove(Target.transform.position, shootTime).SetEase(Ease.Linear).OnComplete(() => { bullet.gameObject.SetActive(false); });
    }

    public override void HitTarget()
    {
        TakeAim();
    }

    public override void OnTargetDied()
    {
        Target.Died -= OnTargetDied;
        //SetTarget();
    }
}