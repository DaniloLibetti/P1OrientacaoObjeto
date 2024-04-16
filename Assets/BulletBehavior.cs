using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRb;
    int speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
