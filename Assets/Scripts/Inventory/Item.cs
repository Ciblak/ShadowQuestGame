using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public string description;
    
    public int attackBonus;
    public int defenseBonus;
    public int healthBonus;
    public Sprite itemSprite;

    public int critChance;
    public string upgradeDesc;


    public virtual void Equip(Player player)
    {
        
    }
    public virtual void Hone(Player player)
    {

    }

protected static Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();

protected static Sprite GetSpriteFromSheet(string sheetName, string spriteName)
{
    if (!spriteCache.ContainsKey(spriteName))
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(sheetName);
        foreach (Sprite sprite in sprites)
            spriteCache[sprite.name] = sprite;
    }
    return spriteCache.ContainsKey(spriteName) ? spriteCache[spriteName] : null;
}

}
