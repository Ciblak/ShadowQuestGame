using UnityEngine;

public class Andro : Enemy
{
        public Andro()
    {  
        enemyIndex=1;
        enemyProj="AndroProj";
        backDrop = "BattleBG";
    }

    public override void AttackPlayer()
    {
        if(currentHealth<maxHealth/2 && poisonEffect.poisonStacks>0){
        Heal((int) System.Math.Round(poisonEffect.poisonStacks*maxHealth*0.05f));
        PlayEffectOnEnemy("PoisonHeal");
        poisonEffect.poisonStacks=0;
        }
        else{
            if(Player.Instance.poisonEffect.poisonStacks>=7) {
                PlayAnimation("Attack");
                PlayEffectOnPlayer("PoisonProc");
                while (Player.Instance.poisonEffect.poisonStacks > 0)
                {
                Player.Instance.ProcessPoison();
                }
            }
            else{
            PlayAnimation("Attack");
            FireProjectile();
        }
        }
    }
}
