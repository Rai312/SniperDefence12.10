using UnityEngine;
using Zenject;

public class BallisticsShoot : MonoBehaviour
{
    [SerializeField] private float _angle;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private BulletDefender _bulletPrefab;
    [SerializeField] private float _speedMultyplaer;
    [SerializeField] private int _bulletCount;
    
    [Inject]
    private Transform _BulletPoolConteiner;

    private ObjectPool<BulletDefender> _bulletPool;

    private float _gravityForce = Physics.gravity.y;

    private void Start()
    {
        _bulletPool = new ObjectPool<BulletDefender>(_bulletPrefab, _bulletCount, _BulletPoolConteiner);
        _bulletSpawn.localEulerAngles = new Vector3(-_angle, 0f, 0f);
        _angle = _angle * Mathf.PI / 180;
    }

    public void Shoot(Transform target)
    {
        if (_bulletPool.TryGetObject(out BulletDefender newBullet))
        {
            print("Shoot1");
            float speed = SpeedCulculate(target);
            newBullet.transform.position = _bulletSpawn.position;
            newBullet.gameObject.SetActive(true);
            newBullet.GetComponent<Rigidbody>().velocity = _bulletSpawn.forward * speed;
            print("Shoot2");
        }
    }

    private float SpeedCulculate(Transform target)
    {
        Vector3 direction = target.position - _bulletSpawn.position;

        float distanse = direction.magnitude;
        float directionY = direction.y;

        float speed2 = (_gravityForce * distanse * distanse) / (2 * (directionY - Mathf.Tan(_angle) * distanse) * Mathf.Pow(Mathf.Cos(_angle), 2));
        float speed = Mathf.Sqrt(Mathf.Abs(speed2)) * _speedMultyplaer;

        return speed;
    }
}
