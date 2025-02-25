using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    public virtual float MoveDistance { get; } = 8f;
    public static PlayerCombat Instance;
    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
    }
    else
    {
        Destroy(gameObject);
        return;
    }
}
public void MoveNPlayAnimation()
{
    StartCoroutine(MoveAndPlayAnimation());
}
private IEnumerator MoveAndPlayAnimation()
{
    Vector3 startPosition = Player.Instance.transform.position;
    Vector3 targetPosition = startPosition + new Vector3(MoveDistance, 0, 0);

    while (Mathf.Abs(Player.Instance.transform.position.x - targetPosition.x) > 0.1f)
    {
        Player.Instance.transform.position = Vector3.MoveTowards(
            Player.Instance.transform.position,
            targetPosition,
            50f * Time.deltaTime
        );
        yield return null;
    }


    while (Mathf.Abs(Player.Instance.transform.position.x - startPosition.x) > 0.1f)
    {
        Player.Instance.transform.position = Vector3.MoveTowards(
            Player.Instance.transform.position,
            startPosition,
            50f * Time.deltaTime
        );
        yield return null;
    }
}
}