public class ConqPlate : Armor
{
    public ConqPlate()
    {
        itemName = "conqueror plate";
        description = "A simple armor.";
        upgradeDesc ="+5 DEF\n+10 max hp";
        itemSprite = GetSpriteFromSheet("ZORT", "ZORT_10");
    }
        public override void Hone(Player player)
    {
        player.defense+=5;
        player.maxHealth+=10;
        player.currentHealth+=10;
    }
}
