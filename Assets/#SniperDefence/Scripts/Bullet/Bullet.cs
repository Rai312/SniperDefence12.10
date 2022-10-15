using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Damage(_damage);
            gameObject.SetActive(false);
        }
    }
}