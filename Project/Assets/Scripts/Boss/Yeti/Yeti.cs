using AnimId;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Yeti : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerController _player;
    private Vector3 _bossDirection;
    private float ShootSnowPower = 20.0f; // 눈덩이 발사 힘
    private float moveSpeed = 5.0f;

    public Animator _animator;
    public AudioSource audioSource;
    public Snowball snowPrefab;
    public SnowballObjectPool _snowballObjectPool;
    public int rollCount = 0; // 구르는 횟수
    public int maxRollCount = 3;
    public bool isRolling = false; // 보스가 구르고 있는지 아닌지

    public Snowball snow { get; private set; }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        snow = Instantiate(snowPrefab);
        snow.Boss = gameObject;
        snow.gameObject.SetActive(false);
    }

    private void Awake()
    {
        _snowballObjectPool = GetComponent<SnowballObjectPool>();
        _rigid = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void BossDirection()
    {
        Vector3 playerDirection = _player.gameObject.transform.position - transform.position;
        _bossDirection = playerDirection;

        _animator.SetFloat(PlayerAnimId.s_DirectionX, _bossDirection.x);
        _animator.SetFloat(PlayerAnimId.s_DirectionY, _bossDirection.y);
    }

    private void Update()
    {
        BossDirection();

        if (Time.timeScale == 0)
        {
            audioSource.Stop();
        }
    }

    public void ShootSnow()
    {
        Snowball snow = _snowballObjectPool.snowballPool.Get();
        gameObject.SetActive(true);

        Vector3 offset = (_player.gameObject.transform.position - transform.position).normalized * 2f;
        snow.transform.position = transform.position + offset;

        Vector3 targetDirection = _player.gameObject.transform.position - snow.transform.position;
        targetDirection.Normalize();

        snow.GetComponent<Rigidbody2D>().AddForce(targetDirection * ShootSnowPower, ForceMode2D.Impulse);
    }

    public void MoveTowardsPlayer()
    {
        if (_player != null)
        {
            Vector3 targetDirection = (_player.transform.position - transform.position).normalized;
            transform.position += targetDirection * moveSpeed * Time.deltaTime;
        }
    }

    public void ResetRollCount()
    {
        rollCount = 0;
        isRolling = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            _animator.SetTrigger(PlayerAnimId.s_WakeBoss);
            audioSource.Play();
        }
    }
}
