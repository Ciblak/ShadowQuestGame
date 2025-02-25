using UnityEngine;
public class SiphoningStrike : Skill
{
    public SiphoningStrike() : base()
    {  
        skillName = "Siphoning Strike";
        description = "Strike your enemy with your bare fist, dealing 100% STR + 100% INT as damage and healing for 30% of the damage dealt. Cleanses any negative effects.";
        cooldown = 4;
        damageEffectiveness = 0.0f;
        usesAttribute = true;
        STRscaling = 1;
        INTscaling = 1;
        heals = true;
        healAmount = 0.3f;
        ailmentIndex = 0;
        skillIcon = Resources.Load<Sprite>("siphon");
    }
    public override void PlaySkillAnimation()
    {
        Player.Instance.PlayAnimation("Block");
        GameObject circle = GameObject.Find("Circle");
        Animator circleAnimator = circle.GetComponent<Animator>();
        circleAnimator.SetTrigger("BlockFlash");
    }
        public override void SkillExtraFX()
    {
        Player.Instance.poisonEffect.poisonStacks=0;
    }
}