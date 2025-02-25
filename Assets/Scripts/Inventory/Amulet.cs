public class Amulet : Item
{
    public Amulet()
    {
        healthBonus = 50;
        critChance = 10;
    }

    public override void Equip(Player player)
    {
        if (player.equippedAmulet != null) 
        {
            player.maxHealth -= player.equippedAmulet.healthBonus;
            player.critChance -= player.equippedAmulet.critChance;
        }
        player.maxHealth += healthBonus;
        player.currentHealth += healthBonus; // Boost current health too
        player.critChance += critChance;
        player.equippedAmulet = this;
    }
}
