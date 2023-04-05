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

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _animator.SetFloat("StayHorizontal", Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat("StayVertical", Input.GetAxisRaw("Vertical"));
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
