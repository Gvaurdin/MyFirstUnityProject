using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float changeDirectionInterval = 3f;

    private Rigidbody2D rb;
    private float directionTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionTimer = changeDirectionInterval;
        SetRandomDirection();
    }

    private void SetRandomDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        directionTimer -= Time.deltaTime;
        if (directionTimer < 0f)
        {
            SetRandomDirection();
            directionTimer = changeDirectionInterval;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetRandomDirection();
    }
}
