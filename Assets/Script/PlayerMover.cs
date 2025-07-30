using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class NewMonoBehaviourScript : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Speed = nameof(Speed);
    private const string Jump = nameof(Jump);
    private const string SpeedUpDown = nameof(SpeedUpDown);

    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private Transform _leftBoard;
    [SerializeField] private Transform _rightBoard;
    

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private float _direction;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        
    }


    private void FixedUpdate()
    {
        _direction = Input.GetAxisRaw(Horizontal);
        _rigidbody2D.linearVelocity = new Vector2(_direction * _speed,_rigidbody2D.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, _forceJump);
            _isGround = false;
            _animator.SetBool(Jump, true);
            _animator.SetFloat(SpeedUpDown, _rigidbody2D.linearVelocity.y);
        }

        _animator.SetFloat(Speed,Math.Abs(_direction));
        _animator.SetFloat(SpeedUpDown, _rigidbody2D.linearVelocity.y);

        ClampPosition();


        FlipX();

    }

    private void ClampPosition()
    {
        float clampedX = Math.Clamp(transform.position.x, _leftBoard.position.x,_rightBoard.position.x);
        transform.position = new Vector3(clampedX,transform.position.y,transform.position.z);
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
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            _animator.SetBool(Jump, false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = false;
            _animator.SetBool(Jump, true);
        }
    }


}
