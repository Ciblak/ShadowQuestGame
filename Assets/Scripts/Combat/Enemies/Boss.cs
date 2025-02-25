using UnityEngine;

public class Boss : Enemy
{
    public int bossPhase = 1;
    public int countdownTimer = 0;
    public bool playerMarked=false;

        public Boss()
    {  
        enemyIndex=5;
        enemyProj="BossProj";
        backDrop="bgfire";
    }

    public override void AttackPlayer()
    {
        if(currentHealth<=2*maxHealth/3) {bossPhase=2; PlayAnimation("Phase2");}
        else if (currentHealth<=maxHealth/3) {bossPhase=3; lifeSteal=20; PlayAnimation("Phase3");}

        if(bossPhase==1) {
            FireProjectile();
        }

        if(bossPhase>=2){
            //PlayAnimation("Phase2"); //Yes, it triggers each time he attacks, it's intentional
            MarkAttack();

        }
    }

    private void MarkAttack()
    {
        if(countdownTimer>0)countdownTimer--;
        if(playerMarked==false){
            countdownTimer=3;
            playerMarked=true;
            PlayEffectOnPlayer("Target");
        }
        if(playerMarked==true&&countdownTimer==0){
            playerMarked=false;
            PlayEffectOnPlayer("NoTarget");
            Player.Instance.TakeDamage(Player.Instance.maxHealth/2);
            if(bossPhase==3)Heal((int) System.Math.Round((Player.Instance.maxHealth/2 - Player.Instance.defense)*(lifeSteal*0.01f)));
            PlayEffectOnPlayer("MarkProc");
        }
        else{
            FireProjectile();
        }
    }
}
