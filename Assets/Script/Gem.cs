using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Gem : MonoBehaviour
{
    private const string Player = nameof(PlayerMover_2);
    private const string Dead = nameof(Dead);



    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _spriteRenderer.color = Random.ColorHSV();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMover_2 playerMover)) 
        {
            _animator.SetTrigger(Dead);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
