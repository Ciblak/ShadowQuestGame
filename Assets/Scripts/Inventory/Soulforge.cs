public class Soulforge : Armor
{
    public Soulforge()
    {
        itemName = "Soulforge";
        description = "A simple armor.";
        upgradeDesc ="+10 DEF";
        itemSprite = GetSpriteFromSheet("ZORT", "ZORT_9");
    }
        public override void Hone(Player player)
    {
        player.defense+=10;
    }
}
