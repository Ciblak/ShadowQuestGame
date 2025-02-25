using UnityEngine;

public class CursedMirror : Card
{
    public CursedMirror()
    {
        cardName = "Cursed Mirror";
        description = "+25% Crit Chance, but take 25% more damage from hits. Use card to deal damage equal to 200% of the Enemy's ATK";
        cardSprite = Resources.Load<Sprite>("cursedmirror");
    }

	public override void ApplyPassiveEffect(Player player)
	{
		Player.Instance.critChance+=25;
		Player.Instance.incDmgTaken+=25;
	}

    public override void RemovePassiveEffect(Player player)
    {
        Player.Instance.critChance-=25;
		Player.Instance.incDmgTaken-=25;
    }

    public override void Consume(Player player)
    {
        base.Consume(player);
        Enemy target = GameObject.FindFirstObjectByType<Enemy>();
		int mirrorDmg = target.attackDamage*2;
		
		target.TakeDamage(mirrorDmg);

        CardManager.Instance.RemoveCard(this);
    }
}
