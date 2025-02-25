using UnityEngine;
public class ViperStrike : Skill
{
    public ViperStrike() :base()
    {  
        skillName = "Viper Strike";
        description = "Strike your enemy with your equipped weapon, dealing 80% ATK +200% DEX damage and applying 3 stacks of Poison.";
        ailmentIndex = 1;
        cooldown = 2;
        usesAttribute = true;
        stacks = 3;
        damageEffectiveness = 0.8f;
        DEXscaling=2;
        skillIcon = Resources.Load<Sprite>("ViperStrikePIX");
    }
    public override void PlaySkillAnimation()
    {
        Player.Instance.PlayAnimation("Attack1");
        GameObject circle = GameObject.Find("Circle");
        Animator circleAnimator = circle.GetComponent<Animator>();
        circleAnimator.SetTrigger("Slash1");
    }
}