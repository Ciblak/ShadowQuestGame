using UnityEngine;

public class Corrosion : Card
{
    public Corrosion()
    {
        cardName = "Corrosion";
        description = "At the start of each turn, both the You and your Enemy are applied 1 stack of Poison. Consuming this card will remove all Poison stacks from the Enemy, dealing their damage at once.";
        cardSprite = Resources.Load<Sprite>("corrosion");
    }

public override void ApplyPassiveEffect(Player player)
{
    if (TurnManager.Instance == null)
    {
        return;
    }
    TurnManager.Instance.OnTurnStart += ApplyPoisonEachTurn;
    Skill viperStrike = Player.Instance.skills.Find(skill => skill.skillName == "Viper Strike");
    viperStrike.cooldown = 0;
    viperStrike.cooldownTimer = 0;
}

    public override void RemovePassiveEffect(Player player)
    {
        TurnManager.Instance.OnTurnStart -= ApplyPoisonEachTurn;
        Skill viperStrike = Player.Instance.skills.Find(skill => skill.skillName == "Viper Strike");
        viperStrike.cooldown = 2;
    }

    private void ApplyPoisonEachTurn()
    {
        Player.Instance.ApplyPoison(1, 5);
        Enemy target = GameObject.FindFirstObjectByType<Enemy>();
        target.ApplyPoison(1, 5);
    }

    public override void Consume(Player player)
    {
        base.Consume(player);
        Enemy target = GameObject.FindFirstObjectByType<Enemy>();
        while (target.poisonEffect.poisonStacks > 0)
        {
            target.ProcessPoison();
        }

        CardManager.Instance.RemoveCard(this);
    }
}
