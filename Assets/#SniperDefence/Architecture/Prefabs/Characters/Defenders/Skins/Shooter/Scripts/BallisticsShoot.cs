using InfinityCode.UltimateEditorEnhancer.Windows;
using UnityEngine;

public class BallisticsShoot : MonoBehaviour
{
    [SerializeField] private float _angle;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private GameObject _bullet;



    private float _gravityForce = Physics.gravity.y;

    private void Start()
    {
        _bulletSpawn.localEulerAngles = new Vector3(-_angle, 0f, 0f);
        _angle = _angle * Mathf.PI / 180;
    }

    public void Shoot(Transform target)
    {

        float speed = SpeedCulculate(target);

        GameObject newBullet = Instantiate(_bullet, _bulletSpawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = _bulletSpawn.forward * speed;
    }

    private float SpeedCulculate(Transform target)
    {
        Vector3 direction = target.position - _bulletSpawn.position;

        float distanse = direction.magnitude;
        float directionY = direction.y;

        float speed2 = (_gravityForce * distanse * distanse) / (2 * (directionY - Mathf.Tan(_angle) * distanse) * Mathf.Pow(Mathf.Cos(_angle), 2));
        float speed = Mathf.Sqrt(Mathf.Abs(speed2));

        return speed;
    }
}
