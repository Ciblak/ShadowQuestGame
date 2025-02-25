using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Image healthBar;
    public Text healthText;
    public int attackDamage=0;
    public int defense=0;
    public int critChance=0;
    public PoisonEffect poisonEffect = new PoisonEffect();
    public Color32 normalHP = new Color32( 219 , 0 , 0 , 186 );
    public Color32 poisonHP = new Color32( 64 , 202 , 0 , 186 );
    protected Animator animator;
	public int incDmgTaken=0;
	public bool randoDmg=false;
	public int lifeSteal=0;
    
    public virtual void ApplyPoison(int stacks, int potency)
    {
    poisonEffect.ApplyPoison(stacks, potency);
    healthBar.color = poisonHP;
    }

    public virtual void TakeDamage(int damage)
    {
        int finaldmg=(damage-defense)*(1 + incDmgTaken/100);
        currentHealth -= finaldmg;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

        public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }
    public void UpdateHealthBar()
    {
    if (healthBar != null)
        {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
        healthText.text = currentHealth + " / " + maxHealth;
        }
    }
        protected virtual void Update()
    {
        UpdateHealthBar();
    }

    public void TakePoisonDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void ProcessPoison()
{
    poisonEffect.ProcessPoison(this); //idek don't ask
}

public virtual void Die()
{
    PlayAnimation("Death");
}
    //ANIMATIONS
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
        public void PlayAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    protected void PlayEffectOnPlayer(string Trigger)
    {
        GameObject circle2 = GameObject.Find("Circle2");
        Animator circle2Animator = circle2.GetComponent<Animator>();
        circle2Animator.SetTrigger(Trigger);
    }

        protected void PlayEffectOnEnemy(string Trigger)
    {
        GameObject circle = GameObject.Find("Circle");
        Animator circleAnimator = circle.GetComponent<Animator>();
        circleAnimator.SetTrigger(Trigger);
    }
}