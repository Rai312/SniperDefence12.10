using UnityEngine;

public class Shooter : Defender
{
    [SerializeField] private BallisticsShoot _ballisticsShoot;
    [SerializeField] private BulletDefender _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    
    public BallisticsShoot BallisticsShoot => _ballisticsShoot;
    public Bullet BulletPrefab => _bulletPrefab;

    private void TakeAim()
    {
        SetTarget();

        if (Target != null)
            _ballisticsShoot.Shoot(Target.transform);
    }

    public override void HitTarget()
    {
        TakeAim();
    }

    public override void OnTargetDied()
    {
        Target.Died -= OnTargetDied;
    }
}