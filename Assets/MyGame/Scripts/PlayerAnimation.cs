using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PhysicsMovement))]

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const double swingClearanceR = 0.5;
    private const double swingClearanceL = -0.5;

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
        if (_physicsMovement.GetCurrentVelocity().x < swingClearanceL)
        {
            _sprite.flipX = true;
        }
        else if (_physicsMovement.GetCurrentVelocity().x > swingClearanceR)
        {
            _sprite.flipX = false;
        }
        _animator.SetFloat("Speed", _physicsMovement.GetCurrentVelocity().x);

        if (Input.GetKeyDown(KeyCode.Space) && _physicsMovement.Grounded)
        {
            _animator.SetTrigger("Jump");
            _animator.ResetTrigger("Grounded");

        }
    }
}
