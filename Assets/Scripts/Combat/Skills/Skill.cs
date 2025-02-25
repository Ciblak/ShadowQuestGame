using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Skill
{
    public string skillName;
    public string description;
    public float damageEffectiveness;
    public Sprite skillIcon;
    
    public int cooldown = 0;
    public int cooldownTimer = 0;
    public int usesLeft = -1;  // -1 means unlimited uses, otherwise, it’s the number of times it can be used per battle
    public int stacks;
    public bool heals = false;
    public float healAmount;
    public bool usesAttribute = false;
    public int STRscaling=0;
    public int DEXscaling=0;
    public int INTscaling=0;
    public int ailmentIndex=0; //1 for poison

    public Skill()
    {
        GameManager.Instance.FightEnd+=ResetCooldown;
    }
    public virtual void PlaySkillAnimation()
    {
    }
    public void ResetCooldown()
    {
        cooldownTimer=0;
    }

    public void UseSkill(int skillIndex)
{
    Skill selectedSkill = Player.Instance.skills[skillIndex];

    if (selectedSkill.cooldownTimer > 0)
    {
        return;
    }
    Enemy target = GameObject.FindFirstObjectByType<Enemy>();

    bool isCrit = Random.value < (Player.Instance.critChance / 100f);
	if (Player.Instance.critGuaranteed) isCrit=true;
    int finalDamage=0;
	int preDmg=Player.Instance.attackDamage;
	if(Player.Instance.randoDmg) {
		float multiplier = Random.Range(0.1f, 2.0f);
		preDmg=(int)System.Math.Round(preDmg*multiplier);
	}
    if (!selectedSkill.usesAttribute) finalDamage =(int) System.Math.Round(isCrit ? preDmg * 1.5 * selectedSkill.damageEffectiveness : preDmg * selectedSkill.damageEffectiveness);
    
    if (selectedSkill.usesAttribute) finalDamage =(int) System.Math.Round(isCrit ? preDmg * 1.5 * selectedSkill.damageEffectiveness + STRscaling*Player.Instance.STR + DEXscaling*Player.Instance.DEX + INTscaling*Player.Instance.INT : preDmg * selectedSkill.damageEffectiveness + STRscaling*Player.Instance.STR + DEXscaling*Player.Instance.DEX + INTscaling*Player.Instance.INT);     //not using else bc it looks bad :)
//
        PlayerCombat.Instance.MoveNPlayAnimation();
        selectedSkill.PlaySkillAnimation();
//
    if(isCrit) PlayCritAnimation();
    target.TakeDamage(finalDamage);
    if (selectedSkill.ailmentIndex==1) target.ApplyPoison(selectedSkill.stacks , (int) System.Math.Round(Player.Instance.INT/4.0f));
    if (selectedSkill.heals) Player.Instance.Heal((int) System.Math.Round(finalDamage * selectedSkill.healAmount));

    selectedSkill.SkillExtraFX();

	Player.Instance.critGuaranteed=false;

    Player.Instance.ReduceCooldowns();

    selectedSkill.cooldownTimer = selectedSkill.cooldown;
    if (selectedSkill.usesLeft > 0) selectedSkill.usesLeft--;
}
    public void PlayCritAnimation()
    {
        GameObject critThing = GameObject.Find("CritThing");
        Animator critAnimator = critThing.GetComponent<Animator>();
        critAnimator.SetTrigger("Crit");
    }
    public virtual void SkillExtraFX()
    {

    }
    public virtual void Evolve()
    {
        
    }
}
