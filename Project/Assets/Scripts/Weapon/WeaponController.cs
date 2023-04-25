using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D _rigidBody;
    private float _arrowForce; // ȭ���� �ּ�ġ, �ִ�ġ

    public GameObject Player;
    public bool isGetArrow = true; // ȭ���� ������ �ִ��� �ƴ���

    void Awake()
    {
        _playerController = Player.GetComponent<PlayerController>();
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.C) && isGetArrow == false)
        //{
        //    isGetArrow = true;
        //    _rigidBody.AddForce(_playerController.lookDirection * -1 * _arrowForce);
        //}
    }

    void ShootArrow() // �߻�
    {
        if (Input.GetKeyDown(KeyCode.C) && isGetArrow == true)
        {
            if (Time.time > 2.0)
            {
                isGetArrow = false;
                _rigidBody.AddForce(_playerController.lookDirection * _arrowForce);
            }

            else if (Time.time < 2.0)
            {

            }
        }
    }

    // ȭ���� ���� �ִ�ġ, �ּ�ġ�� ���Ѵ�.
    public void Shoot()
    {
        // ȭ���� ���ư������� �ʿ��� ������
        // ex. AddForce, �������� �������ְ� �ű���� �̵��ϱ�
        // ���ߴ� ��ġ�� ���ߴ� ���� ex. shoot �� ��ġ���� �� �������� �󸶸�ŭ ������ ��ġ����
        // Lerp
    }

    public void GetBack()
    {
        // ȭ���� �÷��̾�� ���ư��� ���� �ʿ��� ������
        // ex. �÷��̾� ��ġ�� �˾ƾߵǰ�, �� �������� ���ư��� ���� AddForce or transform.Translate
    }
}
