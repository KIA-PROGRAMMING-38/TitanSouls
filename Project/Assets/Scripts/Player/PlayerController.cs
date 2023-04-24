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


    public GameObject weapon;
    public Vector2 motionVec;
    public Vector2 lookDirection = new Vector2(0, 0); // 플레이어가 바라보는 방향 지정
    [SerializeField] float normalSpeed, runSpeed;
    public float speed;

    private void Start()
    {
        weapon.SetActive(false);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {   
        ProcessMove();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            GameObject.Find("WeaponParent").transform.Find("Weapon").gameObject.SetActive(true);
        }
    }

    public void ProcessMove()
    {
        if (Input.GetKey(KeyCode.X))
        {
            speed = runSpeed;
        }
        
        else
        {
            speed = normalSpeed;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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
}
