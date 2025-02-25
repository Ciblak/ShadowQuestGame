using UnityEngine;
using UnityEngine.UI;
public class Enemy : Character
{
    public int enemyIndex;
    protected GameObject projectilePrefab;
    protected string enemyProj;
    protected string backDrop;
    private Sprite backgroundImg;
    protected override void Start()
    {
        base.Start();
        healthBar=GameObject.Find("EnemyHP")?.GetComponent<Image>();
        healthText=GameObject.Find("EnemyHPText")?.GetComponent<Text>();
        healthBar.fillAmount = 1;
        maxHealth = 80+GameManager.Instance.currentRoom*20;
        defense=3 + GameManager.Instance.currentRoom*2;
        currentHealth = maxHealth;
        attackDamage = GameManager.Instance.currentRoom*10;
    }

    private void Awake()
    {
        backgroundImg = Resources.Load<Sprite>(backDrop);
        GameObject.Find("SceneBackground").GetComponent<SpriteRenderer>().sprite=backgroundImg;
        if (enemyIndex==3) Player.Instance.transform.position = new Vector3(-3.8f, -2.3f, 0);
        else if (enemyIndex==4) Player.Instance.transform.position = new Vector3(-3.8f, -2.0f, 0);
        else Player.Instance.transform.position = new Vector3(-3.8f, -1.62f, 0);
    }

    public virtual void AttackPlayer()
    {
    }

    public override void Die()
    {
        base.Die();
        /*
        PlayEffectOnEnemy("EnemyDeath");
        SpriteRenderer slotSpriteRenderer = this.GetComponent<SpriteRenderer>();
        slotSpriteRenderer.sprite = null;
        */
        GameManager.Instance.NextRoom();
    }
    
    protected virtual void FireProjectile()
    {
        projectilePrefab = Resources.Load<GameObject>(enemyProj);
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<EnemyProjectile>().SetTarget(new Vector3(-3.2f, -0.4f, 0f));
    }
}
