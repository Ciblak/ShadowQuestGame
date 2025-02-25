using UnityEngine;
using UnityEngine.UI;

public class UIFetcher : MonoBehaviour
{
    //public Text healthText;
    public Text attackText;
    public Text defenseText;
    public Text critChanceText;
    public Text strengthText;
    public Text dexterityText;
    public Text intelligenceText;
    public Text playerPoisonText;
    public Text enemyPoisonText;
    public Text skill1CD;
    public Text skill2CD;
    public Text skill3CD;
    public Image skill1Img;
    public Image skill2Img;
    public Image skill3Img;
    private Color32 offCD = new Color32( 255 , 255 , 255 , 255 );
    private Color32 onCD = new Color32( 89 , 89 , 89 , 255 );
    public Image enemyHealthBar;
    public Text enemyHealthText;

    private Player player;

    void Start()
    {
        player = Player.Instance;

        if (player == null)
        {
            return;
        }

        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (player == null) return;
        Enemy target = GameObject.FindFirstObjectByType<Enemy>();
        //healthText.text = $"{player.currentHealth} / {player.maxHealth}";
        attackText.text = $" {player.attackDamage}";
        defenseText.text = $"{player.defense}";
        critChanceText.text = $" {player.critChance}%";
        strengthText.text = $" {player.STR}";
        dexterityText.text = $"{player.DEX}";
        intelligenceText.text = $" {player.INT}";
        //CD UI
        Image[] skillCDImgs = { skill1Img, skill2Img, skill3Img };
        Text[] skillCDTexts = { skill1CD, skill2CD, skill3CD };
        for (int i = 0; i < player.skills.Count && i < skillCDTexts.Length; i++)
        {
            if(player.skills[i].cooldownTimer>0){
            skillCDImgs[i].color=onCD;
            skillCDTexts[i].gameObject.SetActive(true);
            skillCDTexts[i].text = $"{player.skills[i].cooldownTimer}";
        }
        else{
            skillCDImgs[i].color=offCD;
            skillCDTexts[i].text = "";
            skillCDTexts[i].gameObject.SetActive(false);
        }
        }
        //if (skill1.cooldownTimer>0)
        //poison txt
        if (player.poisonEffect.poisonStacks > 0)
        {   
            playerPoisonText.gameObject.SetActive(true);
            playerPoisonText.text = $"Poison x{Player.Instance.poisonEffect.poisonStacks}";
            player.healthBar.color = player.poisonHP;
        }
            else
            {
                playerPoisonText.text = "";
                playerPoisonText.gameObject.SetActive(false);
                player.healthBar.color = player.normalHP;
            
        }
        if (target!=null&&target.poisonEffect.poisonStacks > 0)
        {   
            enemyPoisonText.gameObject.SetActive(true);
            enemyPoisonText.text = $"Poison x{target.poisonEffect.poisonStacks}";
            target.healthBar.color = target.poisonHP;
        }
            else
            {
                enemyPoisonText.text = "";
                enemyPoisonText.gameObject.SetActive(false);
                if (target.healthBar!=null) target.healthBar.color = target.normalHP;
            
        }
    }
}