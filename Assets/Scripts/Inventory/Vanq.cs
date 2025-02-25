using UnityEngine;
public class Vanq : Sword
{
    public Vanq()
    {
        itemName = "Vanquisher";
        description = "A simple sword.";
        itemSprite = GetSpriteFromSheet("Swords", "Swords_30");
        upgradeDesc ="+10 ATK\n+5 crit";
    }
        public override void Hone(Player player)
    {
        player.attackDamage+=10;
        player.critChance+=5;
    }
}
