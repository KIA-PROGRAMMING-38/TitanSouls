using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 _inputVec;
    Rigidbody2D _rigid;
    Animator _animator;
    public float _speed;
    public float _runspeed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        _inputVec.x = Input.GetAxisRaw("Horizontal");
        _inputVec.y = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = _inputVec.normalized * _speed * Time.fixedDeltaTime;        
        _rigid.MovePosition(_rigid.position + moveVec);

        if (Input.GetKey(KeyCode.X))
        {
            Run();
        }
    }

    void Run()
    {
        Vector2 moveVec = _inputVec.normalized * _runspeed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + moveVec);
    }
}
