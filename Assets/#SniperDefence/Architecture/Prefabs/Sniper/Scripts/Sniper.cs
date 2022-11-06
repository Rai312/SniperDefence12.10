using UnityEngine;

public class Sniper : MonoBehaviour
{
    [SerializeField] private OpticalSight _opticalSight;
    [SerializeField] private BulletSniper _bulletPrefab;
    [SerializeField] private Camera _camera;

    private void OnEnable()
    {
        _opticalSight.SightIsReleased += Shoot;
    }

    private void OnDisable()
    {
        _opticalSight.SightIsReleased -= Shoot;
    }

    private void Shoot()
    {
        BulletSniper bullet = Instantiate(_bulletPrefab, _camera.transform.position, Quaternion.identity, null);
        bullet.Move();
    }
}