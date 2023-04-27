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

    public Arrow ArrowPrefab;
    public Arrow Arrow { get; private set; }
    public Vector3 motionVec;
    public Vector3 lookDirection = new Vector3(0, 0, 0); // 플레이어가 바라보는 방향 지정
    [SerializeField] float normalSpeed, runSpeed;
    public float speed;
    public float MaxPower = 160f;
    public float ChargingDuration = 7f;
    public bool isGetArrow = true; // 화살을 가지고 있는지 아닌지

    private void Start()
    {
        Arrow = Instantiate(ArrowPrefab);
        Arrow.Player = gameObject;
        Arrow.gameObject.SetActive(false);
        // Debug.Log(Arrow.transform.position);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Arrow.PlayerPosition -= CheckPosition;
        // Arrow.PlayerPosition += CheckPosition;

        if (Input.GetKeyDown(KeyCode.C) && isGetArrow == true)
        {
            _animator.SetTrigger(PlayerAnimId.s_ShootReady);
        }

        if (Input.GetKeyDown(KeyCode.C) && isGetArrow == false)
        {
            _animator.SetTrigger(PlayerAnimId.s_RetrieveReady);

        }
    }

    void FixedUpdate()
    {
        ProcessMove();
    }

    //public void CheckPosition()
    //{
    //    Debug.Log($"PlayerTransfrom : {transform.position}");
    //}

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
            lookDirection.Set(motionVec.x, motionVec.y, motionVec.z);
        }

        _rigidbody.velocity = motionVec.normalized * speed;

        Vector3 position = _rigidbody.position;
        position = position + motionVec * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(position);

        _animator.SetFloat(PlayerAnimId.s_Look_X, lookDirection.x);
        _animator.SetFloat(PlayerAnimId.s_Look_Y, lookDirection.y);
        _animator.SetFloat(PlayerAnimId.s_Speed, _rigidbody.velocity.sqrMagnitude);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {      
        if (collision.CompareTag("Arrow") )
        {
            if( Arrow.IsRejection == false)
            {
                Debug.Log("화살 먹음");
                Arrow.gameObject.SetActive(false);
                isGetArrow = true;

            }
        }
    }
}
