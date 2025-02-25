using UnityEngine;

public class LuckyStrikes : Card
{
    public LuckyStrikes()
    {
        cardName = "Lucky Strikes";
        description = "Your attacks randomly deal damage between 10-200% of your ATK. When used, your next attack is guaranteed to crit.";
        cardSprite = Resources.Load<Sprite>("luckystrikes");
    }

	public override void ApplyPassiveEffect(Player player)
	{
		Player.Instance.randoDmg=true;
	}

    public override void RemovePassiveEffect(Player player)
    {
		Player.Instance.randoDmg=false;
    }

    public override void Consume(Player player)
    {
        base.Consume(player);
		Player.Instance.critGuaranteed=true;
        CardManager.Instance.RemoveCard(this);
    }
}
