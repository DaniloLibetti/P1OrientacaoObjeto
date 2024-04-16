using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject pontoA;
    public GameObject pontoB;

    private Rigidbody2D enemyRb;

    private Transform pontoAtual;

    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        pontoAtual = pontoB.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ponto = pontoAtual.position - transform.position;
        if(pontoAtual == pontoB.transform)
        {
            enemyRb.velocity = new Vector2(velocidade, 0);
        }
        else
        {
            enemyRb.velocity = new Vector2(-velocidade, 0);
        }

        if (Vector2.Distance(transform.position, pontoAtual.position) < 0.5f && pontoAtual == pontoB.transform)
        {
            pontoAtual = pontoA.transform;
        }

        if (Vector2.Distance(transform.position, pontoAtual.position) < 0.5f && pontoAtual == pontoA.transform)
        {
            pontoAtual = pontoB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

}
