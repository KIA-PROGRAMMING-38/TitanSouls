using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    
    public Vector2 motionVec;
    public Vector2 lookDirection = new Vector2(0, 0); // �÷��̾ �ٶ󺸴� ���� ����
    public float speed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        motionVec = new Vector2(Horizontal, Vertical); 

        if (motionVec != Vector2.zero)
        {
            lookDirection.Set(motionVec.x, motionVec.y);
            lookDirection.Normalize(); // ���̸� 1�� ����
        }

        _animator.SetFloat("Look X", lookDirection.x);
        _animator.SetFloat("Look Y", lookDirection.y);
        _animator.SetFloat("Speed", motionVec.magnitude);
      
        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetTrigger("Roll");          
        }
    }
}
