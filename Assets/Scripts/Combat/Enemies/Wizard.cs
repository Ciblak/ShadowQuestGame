using UnityEngine;

public class Wizard : Enemy
{
    public Wizard()
    {  
        enemyIndex=3;
        enemyProj="WizardProj";
        backDrop = "bgwizard";
    }

    public override void AttackPlayer()
    {   
        PlayAnimation("Attack");
        FireProjectile();
    }

    public override void TakeDamage(int damage)
    {
        Player.Instance.TakeDamage(damage/5);
        base.TakeDamage(damage);
    }
}