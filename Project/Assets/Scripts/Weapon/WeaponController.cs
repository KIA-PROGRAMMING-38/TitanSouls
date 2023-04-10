using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public float _arrowSpeed = 10f;

    private bool _canFire = true;
    private bool _arrowFired = false;
    private Rigidbody2D _playerRigidbody;
    private Vector2 arrowDirection;
    private GameObject ArrowInstance;
    public GameObject Player;
    public GameObject Weapon;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            if (_canFire)
            {
                FireArrow();
            }
            else if (_arrowFired)
            {
                ReturnArrow();
            }
        }
    }

    private void FixedUpdate()
    {
        if (arrowDirection != Vector2.zero)
        {
            _playerRigidbody.velocity = arrowDirection.normalized * _arrowSpeed;
        }
    }

    private void FireArrow()
    {
        _canFire = false;
        _arrowFired = true;

        ArrowInstance = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
        arrowDirection = Vector2.MoveTowards(Weapon.transform.position, Player.transform.position, _arrowSpeed);
        ArrowInstance.GetComponent<Rigidbody2D>().velocity = arrowDirection * _arrowSpeed;
    }

    private void ReturnArrow()
    {
        _canFire = true;
        _arrowFired = false;

        arrowDirection =- Vector2.MoveTowards(Weapon.transform.position, Player.transform.position, _arrowSpeed);
        ArrowInstance.GetComponent<Rigidbody2D>().velocity = arrowDirection * _arrowSpeed;

        ArrowInstance.GetComponent<Collider2D>().isTrigger = true;
        ArrowInstance.transform.SetParent(transform);
    }
}
