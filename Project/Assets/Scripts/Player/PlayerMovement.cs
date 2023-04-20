using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigid;
    Animator _animator;
    Vector2 _motionVec;
    Vector2 lookDirection = new Vector2(1, 0); // �÷��̾ �ٶ󺸴� ���� ����

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
            lookDirection.Normalize(); // ���̸� 1�� ����
        }

        _animator.SetFloat("Look X", lookDirection.x);
        _animator.SetFloat("Look Y", lookDirection.y);
        _animator.SetFloat("Speed", _motionVec.magnitude);

        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetTrigger("Roll"); 

            
        }

        // ������ŭ ������ ������ �Ϸ���?

    }
}
