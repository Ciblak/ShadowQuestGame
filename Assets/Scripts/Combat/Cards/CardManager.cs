using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    public Card[] playerCards = new Card[3];
    private List<Type> allCardTypes = new List<Type>();
    public GameObject[] cardSlots;
    private int cardTimer=0;

    private void Awake()
    {
        if (Instance == null){
            Instance = this;
            LoadAllCardTypes();
        }
        else Destroy(gameObject);
        GameManager.Instance.FightEnd+=WipeCards;
    }

    public void CardDrop()
    {
        cardTimer++;
        if (cardTimer==10){
        cardTimer=0;
        AddRandomCard();
        }
    }

public void AddCard(Card card)
{
    for (int i = 0; i < playerCards.Length; i++)
    {
        if (playerCards[i] == null)
        {
            playerCards[i] = card;
            card.ApplyPassiveEffect(Player.Instance);
            SpriteRenderer slotSpriteRenderer = cardSlots[i].GetComponent<SpriteRenderer>();
            TooltipTrigger trg = cardSlots[i].GetComponent<TooltipTrigger>();
            slotSpriteRenderer.sprite = card.cardSprite;
            trg.tooltipMessage = card.description;
            break;
        }
    }
}

    public void AddRandomCard()
    {
        Type randomCardType = allCardTypes[UnityEngine.Random.Range(0, allCardTypes.Count)];
        AddCard((Card)Activator.CreateInstance(randomCardType));
    }


    public void UseCard(int cardIndex)
    {
        if(!TurnManager.Instance.isPlayerTurn) return;
        Card cardToUse = playerCards[cardIndex];
        cardToUse.Consume(Player.Instance);
    }

        private void LoadAllCardTypes()
    {
        allCardTypes = Assembly.GetAssembly(typeof(Card))
        .GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Card)))
        .ToList();
    }

public void RemoveCard(Card card)
{

    for (int i = 0; i < playerCards.Length; i++)
    {
    if (playerCards[i] == card)
    {
        card.RemovePassiveEffect(Player.Instance);
        SpriteRenderer slotSpriteRenderer = cardSlots[i].GetComponent<SpriteRenderer>();
        TooltipTrigger trg = cardSlots[i].GetComponent<TooltipTrigger>();
        slotSpriteRenderer.sprite = null;
        trg.tooltipMessage=null;
        playerCards[i] = null;
        break;
    }
    }
}

public void WipeCards()
{
    for (int i = 0; i < playerCards.Length; i++)
    {
        if (playerCards[i] != null)
        {
            RemoveCard(playerCards[i]);
        }
    }
}

}
