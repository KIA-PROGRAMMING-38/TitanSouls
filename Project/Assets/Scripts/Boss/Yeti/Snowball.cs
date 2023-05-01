using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

public class Snowball : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private IObjectPool<Snowball> SnowPool;
    public event Action BossPosition;
    public GameObject Boss;

    private void Awake()
    {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        BossPosition?.Invoke();
    }

    public void SetPool(IObjectPool<Snowball> pool)
    {
        SnowPool = pool;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            SnowPool.Release(this);
        }
    }
}
