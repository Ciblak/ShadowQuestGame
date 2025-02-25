using UnityEngine;

public class BossProj : EnemyProjectile
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Boss target = GameObject.FindFirstObjectByType<Boss>();
        Player.Instance.TakeDamage(target.attackDamage);
        target.Heal((int) System.Math.Round((target.attackDamage - Player.Instance.defense)*(target.lifeSteal*0.01f)));
        base.OnTriggerEnter2D(other);
    }
}
