using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class OpticalSight : MonoBehaviour
{
    [SerializeField] private float _startZoom;
    [SerializeField] private GameObject _sight;

    private Camera _camera;
    private float _maximumFov = 60;
    private float _duration = 0.5f;
    private float _targetFieldOfView = 41;
    private float _targetZoom;
    private Tween _fieldFovAnimation;
    private float _elapsedTime;
    private float _timeBetweenShoot = 1.5f;
    private Sequence _shootAnimation;
    private bool _isWork = true;
    private Coroutine _shoot;
    private bool _isTached = true;

    private bool _canShoot => _camera.fieldOfView < _targetFieldOfView;

    public event Action SightIsReleased;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        EnableSight();
    }

    public void EnableSight()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            _elapsedTime = 0;
            _sight.SetActive(true);
            _targetZoom = _maximumFov - _startZoom;
            _fieldFovAnimation = _camera.DOFieldOfView(_targetZoom, _duration);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_canShoot && _isWork)
            {
                _isTached = false;
                Shoot();
                _isTached = true;
            }

            else
            {
                _fieldFovAnimation.Kill();
                Hide();
            }
        }
        else
        {
            if (_elapsedTime > _timeBetweenShoot)
                Hide();
        }
    }

    private void Hide()
    {
        _sight.SetActive(false);
        _targetZoom = _maximumFov;
        _camera.DOFieldOfView(_maximumFov, _duration);
    }

    private void Shoot()
    {
        SightIsReleased?.Invoke();

        StartCoroutine(ShootAnimation());
    }

    private IEnumerator ShootAnimation()
    {
        float xOffset = 3;
        float duration = 0.2f;
        float multiplier = 1.5f;

        _shootAnimation = DOTween.Sequence();
        _isWork = false;

        _shootAnimation
            .Append(_camera.transform.DOLocalRotate(GetRotation(-xOffset), duration, RotateMode.LocalAxisAdd))
            .Append(_camera.transform.DOLocalRotate(GetRotation(xOffset), duration * multiplier,
                RotateMode.LocalAxisAdd));

        yield return _shootAnimation.WaitForCompletion();
        _isWork = true;
    }

    private Vector3 GetRotation(float xOffset)
    {
        float zeroAngle = 0;

        return new Vector3(xOffset, zeroAngle, zeroAngle);
    }
}