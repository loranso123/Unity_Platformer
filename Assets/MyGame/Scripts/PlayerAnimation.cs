using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PhysicsMovement _physicsMovement;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_physicsMovement.Velocity.x < -0.5)
        {
            _sprite.flipX = true;
        }
        else if (_physicsMovement.Velocity.x > 0.5)
        {
            _sprite.flipX = false;
        }
        _animator.SetFloat("Speed", _physicsMovement.Velocity.x);

        if (Input.GetKeyDown(KeyCode.Space) && _physicsMovement.Grounded)
        {
            _animator.SetTrigger("Jump");
            _animator.ResetTrigger("Grounded");

        }
    }
}
