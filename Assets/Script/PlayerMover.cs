using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class NewMonoBehaviourScript : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal); 
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private Transform _leftBoard;
    [SerializeField] private Transform _rightBoard;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private float _direction;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }


    private void FixedUpdate()
    {
        _direction = Input.GetAxisRaw(Horizontal) * _speed * Time.fixedDeltaTime;
        _rigidbody2D.linearVelocity = new Vector2(_direction,_rigidbody2D.linearVelocity.y);

        if(Input.GetKey(KeyCode.Space) && _isGround == true)
        {
            Debug.Log("+");
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _forceJump);
            _isGround = false;
        }

        if (transform.position.x < _leftBoard.position.x)
        {
            transform.position = new Vector3(_leftBoard.position.x, transform.position.y, 0);
        }

        if (transform.position.x > _rightBoard.position.x)
        {
            transform.position = new Vector3(_rightBoard.position.x, transform.position.y, 0);
        }

        FlipX();

    }

    private void FlipX()
    {
        if(_direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_direction < 0) 
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rigidbody2D.linearVelocity = new Vector2
                (_rigidbody2D.linearVelocity.x, _rigidbody2D.linearVelocity.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        _isGround = true;
    }

}
