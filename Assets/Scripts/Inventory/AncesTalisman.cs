public class AncesTalisman : Amulet
{
    public AncesTalisman()
    {
        itemName = "Ancestral Talisman";
        description = "A gift from the ancestors.";
        upgradeDesc ="+5 Max HP\n+5 DEF\n+2 ATK\n+2 CRIT";
        itemSprite = GetSpriteFromSheet("Amulets", "Amulets_46");
    }
    public override void Hone(Player player)
    {
        player.maxHealth+=5;
        player.currentHealth+=5;
        player.defense+=5;
        player.attackDamage+=2;
        player.critChance+=2;
    }
}
