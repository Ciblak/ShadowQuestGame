using UnityEngine;
public class Sword : Item
{
    public Sword()
    {
        attackBonus = 10;
        critChance = 10;
    }

    public override void Equip(Player player)
    {
        if (player.equippedSword != null)
        {
            player.attackDamage -= player.equippedSword.attackBonus;
            player.critChance -= player.equippedSword.critChance;
        }
        player.critChance += critChance;
        player.attackDamage += attackBonus;
        player.equippedSword = this;
    }
}
