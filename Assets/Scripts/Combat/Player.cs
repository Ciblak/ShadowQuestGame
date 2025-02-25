using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public static Player Instance;
    public int STR;
    public int DEX;
    public int INT;
    public Item equippedSword;
    public Item equippedArmor;
    public Item equippedAmulet;
    public List<Skill> skills = new List<Skill>();
	public bool critGuaranteed=false;

private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    else
    {
        Destroy(gameObject);
        return;
    }
}
 private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        healthBar = GameObject.Find("PlayerHP")?.GetComponent<Image>();
        healthText = GameObject.Find("PlayerHPText")?.GetComponent<Text>();
        UpdateHealthBar();
    }

protected override void Start()
{
    base.Start();
    ResetPlayer();
}
public void ResetPlayer()
{
    maxHealth = 100;
    currentHealth = maxHealth;
    attackDamage = 0;
    defense = 0;
    critChance = 0;
    if(healthBar!=null)healthBar.fillAmount = 1;
    STR = 5;
    DEX = 5;
    INT = 5;
	incDmgTaken=0;

    EquipItem(GameManager.Instance.selectedSword);
    EquipItem(GameManager.Instance.selectedArmor);
    EquipItem(GameManager.Instance.selectedAmulet);

    skills.Clear();
    skills.Add(new ViperStrike());
    skills.Add(new Slash());
    skills.Add(new SiphoningStrike());
}


public void EquipItem(Item item)
{
    item.Equip(this);
}

    public void ReduceCooldowns()
{
    foreach (Skill skill in skills)
    {
        if (skill.cooldownTimer > 0)
            skill.cooldownTimer--;
    }
}
public override void Die()
    {
        base.Die();
        GameManager.Instance.GameOver();
    }
}
