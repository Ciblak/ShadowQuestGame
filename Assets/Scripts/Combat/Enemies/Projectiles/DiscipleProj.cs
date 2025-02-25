using UnityEngine;

public class DiscipleProj : EnemyProjectile
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Player>().TakeDamage(damage);
        base.OnTriggerEnter2D(other);
    }
}