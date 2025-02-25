using UnityEngine;

public class Shadow : Enemy
{
    public GameObject tentacle1;
    public GameObject tentacle2;
    public bool enraged=false;

        public Shadow()
    {  
        enemyIndex=2;
        enemyProj="ShadowProj";
        backDrop = "bgshadow";
    }

    protected override void Update()
    {
        base.Update();
        if(Player.Instance.currentHealth<=maxHealth/2 && !enraged) // INTENTIONAL: When PlayerHP < Shadow half HP, Shadow gains ATK buff.
        {
        tentacle1.SetActive(true);
        tentacle2.SetActive(true);
        attackDamage*=2; //Could have stored base AD or whatever but idk seems like an interesting mechanic if debuffs are introduced later.
        enraged=true;
        }
        else if(Player.Instance.currentHealth>maxHealth/2 && enraged)
        {
        tentacle1.SetActive(false);
        tentacle2.SetActive(false);
        attackDamage/=2;
        enraged=false;
        }
    }

    public override void ApplyPoison(int stacks, int potency)
    {
        return;
    }

    public override void AttackPlayer()
    {
        FireProjectile();
    }
    public override void Die()
    {
        base.Die();
        if(tentacle1.activeSelf) tentacle1.GetComponent<Animator>().SetTrigger("Death");
        if(tentacle2.activeSelf) tentacle1.GetComponent<Animator>().SetTrigger("Death");
    }
}
