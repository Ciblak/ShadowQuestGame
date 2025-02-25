using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 10;
    private Transform target;
    private Rigidbody2D rb;

private void Awake()
{
    Enemy target = GameObject.FindFirstObjectByType<Enemy>();
    damage=target.attackDamage;
    rb = GetComponent<Rigidbody2D>();
}
public void SetTarget(Vector3 targetPosition)
{
    Vector2 direction = (targetPosition - transform.position);
    rb.linearVelocity = direction * speed;
}

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
