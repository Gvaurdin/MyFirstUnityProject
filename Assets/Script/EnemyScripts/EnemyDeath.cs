using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyDeath : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            animator.SetTrigger("Die");
        }
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
