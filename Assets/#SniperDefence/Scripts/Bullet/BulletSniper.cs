using UnityEngine;

public class BulletSniper : Bullet
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        _rigidbody.AddForce(Camera.main.transform.forward * _movementSpeed, ForceMode.Impulse);
    }
}
