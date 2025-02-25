using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> inventory = new List<Item>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);
    }

    public void EquipItem(int itemIndex)
    {


        Player.Instance.EquipItem(inventory[itemIndex]);
    }
}
