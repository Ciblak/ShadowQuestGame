using UnityEngine;
public class Slash : Skill
{
    public Slash() : base()
    {  
        skillName = "Slash";
        description = "Strike your enemy with your equipped weapon, dealing 100% attack damage.";
        damageEffectiveness = 1.0f;
        ailmentIndex = 0;
        skillIcon = Resources.Load<Sprite>("slash");
    }
    public override void PlaySkillAnimation()
    {
        Player.Instance.PlayAnimation("Attack2");
        GameObject circle = GameObject.Find("Circle");
        Animator circleAnimator = circle.GetComponent<Animator>();
        circleAnimator.SetTrigger("Slash2");
    }
}
