using UnityEngine;

public class PoisonEffect
{
    public int poisonStacks = 0;
    public int poisonDmgPerTick = 0;

    public void ApplyPoison(int amount, int potency)
    {
        poisonStacks += amount;
        poisonDmgPerTick = potency;
    }

    public void ProcessPoison(Character target)
    {
        if (poisonStacks > 0)
        {
            target.TakePoisonDamage(poisonDmgPerTick);
            poisonStacks--;
        }
    }
}
