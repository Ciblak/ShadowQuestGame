using UnityEngine;

public class Disciple : Enemy
{
        public int beamCountdown=3;
        public Disciple()
    {  
        enemyIndex=4;
        enemyProj="DiscipleProj";
        backDrop = "bgdisciple";
        attackDamage*=3;
    }

    public override void AttackPlayer()
    {
        beamCountdown--;
        if(beamCountdown>0){
        PlayAnimation("Charge");
        }
        if(beamCountdown==0){
        PlayAnimation("Attack");
        FireProjectile();
        beamCountdown=3;
        }

    }
}
