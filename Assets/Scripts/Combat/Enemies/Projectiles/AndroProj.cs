using UnityEngine;

public class AndroProj : EnemyProjectile
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Player>().TakeDamage(damage);
        Player.Instance.ApplyPoison(3, (int) System.Math.Round(damage/2f));
        base.OnTriggerEnter2D(other);
    }
}
