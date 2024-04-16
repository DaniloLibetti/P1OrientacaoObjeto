using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D fisica;
    public float velocidade = 10f;
    float inputHorizontal;
    [SerializeField] GameObject bulletPreFab;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");

        //playerRB.velocity = new Vector2(moveX, moveY) * speed;
        
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        fisica.velocity = new Vector2(inputHorizontal * velocidade, fisica.velocity.y);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPreFab, fisica.position, Quaternion.identity);
        }

    }

    private void OnDestroy()
    {
        gameOverScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            winScreen.SetActive(true);
        }      
    }

}