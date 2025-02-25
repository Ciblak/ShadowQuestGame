using UnityEngine;

public class ShadowProj : EnemyProjectile
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Player>().TakeDamage(damage);
        base.OnTriggerEnter2D(other);
    }
}
