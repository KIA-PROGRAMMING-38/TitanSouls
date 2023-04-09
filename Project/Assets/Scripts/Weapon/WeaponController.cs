using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public float arrowSpeed = 10f;

    private bool canFire = true;
    private bool arrowFired = false;
    private Rigidbody2D playerRigidbody;
    private Vector2 arrowDirection;
    private GameObject arrowInstance;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (canFire)
            {
                FireArrow();
            }
            else if (arrowFired)
            {
                ReturnArrow();
            }
        }
    }

    private void FixedUpdate()
    {
        if (arrowDirection != Vector2.zero)
        {
            playerRigidbody.velocity = arrowDirection.normalized * arrowSpeed;
        }
    }

    private void FireArrow()
    {
        canFire = false;
        arrowFired = true;

        arrowInstance = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
        arrowDirection = transform.right;
        arrowInstance.GetComponent<Rigidbody2D>().velocity = arrowDirection * arrowSpeed;
    }

    private void ReturnArrow()
    {
        canFire = true;
        arrowFired = false;

        arrowDirection = -transform.right;
        arrowInstance.GetComponent<Rigidbody2D>().velocity = arrowDirection * arrowSpeed;

        arrowInstance.GetComponent<Collider2D>().isTrigger = true;
        arrowInstance.transform.SetParent(transform);
    }
}
