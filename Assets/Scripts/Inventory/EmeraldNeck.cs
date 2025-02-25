public class EmeraldNeck : Amulet
{
    public EmeraldNeck()
    {
        itemName = "Emerald Necklace";
        description = "A mystical amulet with hidden powers.";
        upgradeDesc ="+10 Max HP\n+5 CRIT Chance";
        itemSprite = GetSpriteFromSheet("Amulets", "Amulets_48");
    }
    public override void Hone(Player player)
    {
        player.maxHealth+=10;
        player.critChance+=5;
    }
}
