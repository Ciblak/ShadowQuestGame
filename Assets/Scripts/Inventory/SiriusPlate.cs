public class SiriusPlate : Armor
{
    public SiriusPlate()
    {
        itemName = "Sirius Plate";
        description = "A simple armor.";
        upgradeDesc ="+15 max hp\n+3 CRIT";
        itemSprite = GetSpriteFromSheet("ZORT", "ZORT_2");
    }
        public override void Hone(Player player)
    {
        player.maxHealth+=15;
        player.currentHealth+=15;
        player.critChance+=3;
    }
}
