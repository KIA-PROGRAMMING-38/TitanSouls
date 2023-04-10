using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigid;
    Animator _animator;
    Vector2 _motionVec;
    [SerializeField] float _speed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        _motionVec = new Vector2(Horizontal, Vertical);
        _animator.SetFloat("Horizontal", Horizontal);
        _animator.SetFloat("Vertical", Vertical);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("IsMove", true);
        }

        else
        {
            _animator.SetBool("IsMove", false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetBool("IsInputX", true);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            _animator.SetBool("IsInputX", false);
        }


    }

    private void Move()
    {
        _rigid.velocity = _motionVec * _speed;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
