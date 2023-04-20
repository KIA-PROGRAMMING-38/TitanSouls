using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float _arrowSpeed = 10f;

    private bool _canFire = true;
    private bool _arrowFired = false;
    private Rigidbody2D _playerRigidbody;
    private Vector2 arrowDirection;

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
        _canFire = true;
        _arrowFired = false;

        arrowDirection = Vector2.MoveTowards(Weapon.transform.position, Player.transform.position, _arrowSpeed);
    }

    private void ReturnArrow()
    {
        _canFire = false;
        _arrowFired = true;

        arrowDirection =- Vector2.MoveTowards(Weapon.transform.position, Player.transform.position, _arrowSpeed);
    }
}
