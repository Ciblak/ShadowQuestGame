using UnityEngine;

public class VampiricEmbrace : Card
{
    public VampiricEmbrace()
    {
        cardName = "Vampiric Embrace";
        description = "Gain 10% Lifesteal, but take 5%HP damage at the start of your turn.";
        cardSprite = Resources.Load<Sprite>("vampiricembrace");
    }

	public override void ApplyPassiveEffect(Player player)
	{
		Player.Instance.lifeSteal+=10;
		TurnManager.Instance.OnTurnStart += takeDmgOnTurn;
	}

    public override void RemovePassiveEffect(Player player)
    {
		Player.Instance.lifeSteal-=10;
		TurnManager.Instance.OnTurnStart -= takeDmgOnTurn;
    }

    public override void Consume(Player player)
    {
        base.Consume(player);
		Player.Instance.currentHealth=Player.Instance.maxHealth;
        CardManager.Instance.RemoveCard(this);
    }
	private void takeDmgOnTurn(){
	if (TurnManager.Instance.isPlayerTurn) Player.Instance.TakeDamage((int) System.Math.Round(Player.Instance.maxHealth*0.05f));
	}
}