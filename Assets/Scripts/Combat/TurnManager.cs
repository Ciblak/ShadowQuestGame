using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public bool isPlayerTurn = true;
    public float messageDuration = 1.5f;
    public Text cooldownMessage;
    public Action OnTurnStart;

    private void Start()
    {
        Instance = this;
    }
    private void Awake()
    {
        OnTurnStart+=CardManager.Instance.CardDrop;
    }

    public void PlayerUseSkill(int skillIndex)
    {
        if (!isPlayerTurn) return;
        Skill selectedSkill = Player.Instance.skills[skillIndex];
        Enemy target = FindFirstObjectByType<Enemy>();
        if (selectedSkill.cooldownTimer > 0){
            Debug.Log($"{selectedSkill.skillName} is on cooldown for {selectedSkill.cooldownTimer} more turns");
            StartCoroutine(ShowMessage($"{selectedSkill.skillName} is on cooldown for {selectedSkill.cooldownTimer} more turns", messageDuration));
            return;
        }
        selectedSkill.UseSkill(skillIndex);
        isPlayerTurn = false;
        StartCoroutine(DelayedEnemyTurn());
    }

    void EnemyTurn()
    {
        Enemy enemy = FindFirstObjectByType<Enemy>();
        if (enemy != null && !enemy.dead) enemy.AttackPlayer();

        StartCoroutine(DelayedPlayerTurn());
    }
    IEnumerator DelayedPlayerTurn()
{
    yield return new WaitForSeconds(1f);
	isPlayerTurn = true;
    OnTurnStart?.Invoke();
    Player.Instance.ProcessPoison();
}
    IEnumerator DelayedEnemyTurn()
{
    yield return new WaitForSeconds(1f);
    Enemy target = FindFirstObjectByType<Enemy>();
    target.ProcessPoison();
	OnTurnStart?.Invoke();
    EnemyTurn();
}
    IEnumerator ShowMessage(string message, float duration)
    {
        cooldownMessage.text = message;
        cooldownMessage.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        cooldownMessage.gameObject.SetActive(false);
        cooldownMessage.text = "";
    }
}
