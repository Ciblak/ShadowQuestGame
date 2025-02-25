using UnityEngine;
public class Nebulus : Sword
{
    public Nebulus()
    {
        itemName = "Nebulus";
        description = "A simple sword.";
        itemSprite = GetSpriteFromSheet("Swords", "Swords_40");
        upgradeDesc ="+15 ATK\n+10 max HP";
    }
        public override void Hone(Player player)
    {
        player.attackDamage+=10;
        player.maxHealth+=10;
        player.currentHealth+=10;
    }
}
