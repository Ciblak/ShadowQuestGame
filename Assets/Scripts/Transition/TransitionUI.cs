using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TransitionUI : MonoBehaviour
{
    [Header("Equipment UI")]
    public GameObject swordSlotImage;
    public GameObject armorSlotImage;
    public GameObject amuletSlotImage;

    public Button swordUpgradeButton;
    public Button armorUpgradeButton;
    public Button amuletUpgradeButton;
    public Button strButton;
    public Button dexButton;
    public Button intButton;

    public Text swordNameText;
    public Text armorNameText;
    public Text amuletNameText;
    public Text swordUpgradeDesc;
    public Text armorUpgradeDesc;
    public Text amuletUpgradeDesc;


    [Header("Skill UI")]
    public List<GameObject> skillSlots = new List<GameObject>();
    public List<Button> skillUpgradeButtons = new List<Button>();
    public List<Text> skillNameTexts = new List<Text>();

    private void Start()
    {
        UpdateEquipmentUI();
        UpdateSkillsUI();
    }

    public void UpdateEquipmentUI()
    {
        Item equippedSword = Player.Instance.equippedSword;
        Item equippedArmor = Player.Instance.equippedArmor;
        Item equippedAmulet = Player.Instance.equippedAmulet;

        swordSlotImage.GetComponent<SpriteRenderer>().sprite = equippedSword.itemSprite;
        armorSlotImage.GetComponent<SpriteRenderer>().sprite = equippedArmor.itemSprite;
        amuletSlotImage.GetComponent<SpriteRenderer>().sprite = equippedAmulet.itemSprite;

        swordNameText.text = equippedSword.itemName;
        armorNameText.text = equippedArmor.itemName;
        amuletNameText.text = equippedAmulet.itemName;

        swordUpgradeDesc.text = equippedSword.upgradeDesc;
        armorUpgradeDesc.text = equippedArmor.upgradeDesc;
        amuletUpgradeDesc.text = equippedAmulet.upgradeDesc;
    }

    public void NextBattle()
    {
        GameManager.Instance.currentRoom++;
        GameManager.Instance.LoadBattle();
    }

    public void UpdateSkillsUI()
    {
    /*
        List<Skill> equippedSkills = Player.Instance.skills;

        for (int i = 0; i < skillSlots.Count; i++)
        {
            if (i < equippedSkills.Count && equippedSkills[i] != null)
            {
                skillSlots[i].GetComponent<SpriteRenderer>().sprite = equippedSkills[i].skillIcon;
                skillNameTexts[i].text = equippedSkills[i].skillName;
                skillUpgradeButtons[i].onClick.RemoveAllListeners();
                skillUpgradeButtons[i].onClick.AddListener(() => equippedSkills[i].Evolve());
            }
            else
            {
                skillSlots[i].GetComponent<SpriteRenderer>().sprite = null;
                skillNameTexts[i].text = "No Skill";
                skillUpgradeButtons[i].onClick.RemoveAllListeners();
            }
        }
        */
    }
}
