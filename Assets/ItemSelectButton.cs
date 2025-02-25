using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    public void SelectItem(string itemName)
    {
        GameManager.Instance.SelectItemByName(itemName);
    }
}
