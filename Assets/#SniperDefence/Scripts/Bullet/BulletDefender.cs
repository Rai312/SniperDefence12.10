using UnityEngine;

public class BulletDefender : Bullet
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        transform.forward = _rigidbody.velocity;
    }
}