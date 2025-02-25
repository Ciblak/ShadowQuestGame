public class Armor : Item
{
    public Armor()
    {
        defenseBonus = 5;
    }

    public override void Equip(Player player)
    {
        if (player.equippedArmor != null) player.defense -= player.equippedArmor.defenseBonus;
        player.defense += defenseBonus;
        player.equippedArmor = this;
    }
}
