using UnityEngine;
public class Dolunay : Sword
{
    public Dolunay()
    {
        itemName = "Full Moon Edge";
        description = "A simple sword.";
        itemSprite = GetSpriteFromSheet("Swords", "Swords_38");
        upgradeDesc ="+20 ATK";
    }
        public override void Hone(Player player)
    {
        player.attackDamage+=20;
    }
}
