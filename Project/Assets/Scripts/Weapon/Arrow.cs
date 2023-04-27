using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public event Action PlayerPosition;
    public GameObject Player;
    public bool IsRejection; // �߻縦 �ߴ��� ���� �ʾҴ���

    void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Debug.Log($"ArrowTransform : {gameObject.transform.position}");
        PlayerPosition?.Invoke();
        IsRejection = true;
    }

    private void Update()
    {
        if (_rigidBody.velocity == Vector2.zero)
        {
            IsRejection = false;
        }
    }

    public void ShootArrow(Vector3 direction, float power) // �߻�
    {
        gameObject.SetActive(true);
        gameObject.transform.position = Player.gameObject.transform.position;
        _rigidBody.AddForce(direction * power, ForceMode2D.Impulse);
    }

    public void GetBackArrow(Vector3 direction, float power) // ȭ�� ȸ��
    {
        _rigidBody.AddForce(direction * power, ForceMode2D.Impulse);
    }
}
