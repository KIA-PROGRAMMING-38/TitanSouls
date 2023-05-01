using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private Yeti boss;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            boss._animator.SetTrigger("IsDie");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
