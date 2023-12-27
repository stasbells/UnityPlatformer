using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigitBody2D;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigitBody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _animator.SetFloat("moveX",Input.GetAxisRaw("Horizontal"));
        _animator.SetFloat("moveY", _rigitBody2D.velocity.y);
        _animator.SetBool("isGrounded", _playerMovement.IsGround);
    }
}