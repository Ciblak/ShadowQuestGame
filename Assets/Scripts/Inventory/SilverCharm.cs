public class SilverCharm : Amulet
{
    public SilverCharm()
    {
        itemName = "Silver Charm";
        description = "A mystical amulet with hidden powers.";
        upgradeDesc ="+7 CRIT";
        itemSprite = GetSpriteFromSheet("Amulets", "Amulets_47");
    }
    public override void Hone(Player player)
    {
        player.critChance+=7;
    }
}
