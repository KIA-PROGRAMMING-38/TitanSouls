using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigid;
    Animator _animator;
    Vector2 _motionVec;
    Vector2 lookDirection = new Vector2(1, 0); // 플레이어가 바라보는 방향 지정

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

        if (!Mathf.Approximately(_motionVec.x, 0.0f) || !Mathf.Approximately(_motionVec.y, 0.0f))
        {
            lookDirection.Set(_motionVec.x, _motionVec.y);
            lookDirection.Normalize(); // 길이를 1로 지정
        }

        _animator.SetFloat("Look X", lookDirection.x);
        _animator.SetFloat("Look Y", lookDirection.y);
        _animator.SetFloat("Speed", _motionVec.magnitude);

        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetTrigger("Roll"); 

            
        }

        // 구른만큼 앞으로 나가게 하려면?

    }
}
