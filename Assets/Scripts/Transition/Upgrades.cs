using UnityEngine;
using UnityEngine.UI;
public class Upgrades : MonoBehaviour
{
    public Color32 selectColor = new Color32 ( 3 , 152 , 0 , 255 );

    public void AttributeIncrease(int index)
{
    if(index==0)
    {
        Player.Instance.STR += 5;
        GameObject.Find("STRtxt").GetComponent<Text>().color= selectColor;
        GameObject.Find("DEXtxt").GetComponent<Text>().text="DEX";
        GameObject.Find("INTtxt").GetComponent<Text>().text="INT";
    }
    if(index==1)
    {
        Player.Instance.DEX += 5;
        GameObject.Find("DEXtxt").GetComponent<Text>().color= selectColor;
        GameObject.Find("STRtxt").GetComponent<Text>().text="STR";
        GameObject.Find("INTtxt").GetComponent<Text>().text="INT";
    }
    if(index==2)
    {
        Player.Instance.INT += 5;
        GameObject.Find("INTtxt").GetComponent<Text>().color=selectColor;
        GameObject.Find("DEXtxt").GetComponent<Text>().text="DEX";
        GameObject.Find("STRtxt").GetComponent<Text>().text="STR";
    }

    GameObject.Find("UpgradeSTR").SetActive(false);
    GameObject.Find("UpgradeDEX").SetActive(false);
    GameObject.Find("UpgradeINT").SetActive(false);
}

public void HoneEquipment(int index)
{
    if(index==0)
    {
        Player.Instance.equippedSword.Hone(Player.Instance);
        GameObject.Find("SwUGdesc").GetComponent<Text>().color=selectColor;
    }
    if(index==1)
    {
        Player.Instance.equippedArmor.Hone(Player.Instance);
        GameObject.Find("SwUGdesc (1)").GetComponent<Text>().color=selectColor;
    }
    if(index==2)
    {
        Player.Instance.equippedAmulet.Hone(Player.Instance);
        GameObject.Find("SwUGdesc (2)").GetComponent<Text>().color=selectColor;
    }
    GameObject.Find("UpgradeSword").SetActive(false);
    GameObject.Find("UpgradeArmor").SetActive(false);
    GameObject.Find("UpgradeAmulet").SetActive(false);
}

}