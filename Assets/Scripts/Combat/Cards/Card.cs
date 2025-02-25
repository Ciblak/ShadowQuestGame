using UnityEngine;

public abstract class Card
{
    public string cardName;
    public string description;
    public Sprite cardSprite;

    public virtual void ApplyPassiveEffect(Player player) { }
    public virtual void RemovePassiveEffect(Player player) { }
    public virtual void Consume(Player player) { }
}
