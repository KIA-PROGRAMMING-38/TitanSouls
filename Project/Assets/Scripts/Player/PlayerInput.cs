using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 InputVec;
    Rigidbody2D _rigid;
    public float speed;
    public float runspeed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        InputVec.x = Input.GetAxisRaw("Horizontal");
        InputVec.y = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = InputVec.normalized * speed * Time.fixedDeltaTime;        
        _rigid.MovePosition(_rigid.position + moveVec);

        if (Input.GetKey(KeyCode.X))
        {
            Run();
        }
    }

    void Run()
    {
        Vector2 moveVec = InputVec.normalized * runspeed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + moveVec);
    }
}
