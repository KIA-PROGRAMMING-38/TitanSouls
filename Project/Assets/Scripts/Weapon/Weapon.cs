using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D _rigidBody;
    private float _arrowForce = 120.0f;

    public GameObject Player;
    public bool isGetArrow = true; // 화살을 가지고 있는지 아닌지

    void Awake()
    {
        _playerController = Player.GetComponent<PlayerController>();
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && isGetArrow == true)
        {
            isGetArrow = false;
            _rigidBody.AddForce(_playerController.lookDirection * _arrowForce);
        }

        //if (Input.GetKeyUp(KeyCode.C) && isGetArrow == false)
        //{
        //    isGetArrow = true;
        //    _rigidBody.AddForce(_playerController.lookDirection * -1 * _arrowForce);
        //}
    } 

    // 화살의 힘의 최대치, 최소치를 정한다.
    public void Shoot()
    {
        // 화살이 날아가기위해 필요한 구문들
        // ex. AddForce, 목적지를 지정해주고 거기까지 이동하기
        // 멈추는 위치에 멈추는 구문 ex. shoot 한 위치에서 그 방향으로 얼마만큼 떨어진 위치까지
        // Lerp
    }

    public void GetBack()
    {
        // 화살이 플레이어에게 돌아가기 위해 필요한 구문들
        // ex. 플레이어 위치를 알아야되고, 그 방햐으로 날아가기 위한 AddForce or transform.Translate
    }
}
