using AnimId;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    public Vector2 motionVec;
    public Vector2 lookDirection = new Vector2(0, 0); // 플레이어가 바라보는 방향 지정
    public float speed;
    public float runSpeed;
    public float horizontal;
    public float vertical;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {   
        ProcessMove();
        PlayerRun();
    }

    private void Update()
    {

    }
    
    public void ProcessMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        motionVec = new Vector2(horizontal, vertical);

        if (horizontal != 0f || vertical != 0f)
        {
            lookDirection.Set(motionVec.x, motionVec.y);
        }

        _rigidbody.velocity = motionVec.normalized * speed;

        Vector2 position = _rigidbody.position;
        position = position + motionVec * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position);

        _animator.SetFloat("Look X", lookDirection.x);
        _animator.SetFloat("Look Y", lookDirection.y);
        _animator.SetFloat("Speed", _rigidbody.velocity.sqrMagnitude);
    }

    private void Run()
    {
        Vector2 runPosition = _rigidbody.position;
        runPosition = runPosition + motionVec * runSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(runPosition);
    }

    private void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Run();
        }
    }
}
