using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform target;
    public GameObject particle;
    public int life;
    public float speedEn;
    public float stoppingDistance;
    public float visao;


    // Start is called before the first frame update
    void Start()
    {
        life = 30;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance) {
            if (Vector2.Distance(transform.position, target.position) <= (visao))
                transform.position = Vector2.MoveTowards(transform.position, target.position, speedEn * Time.deltaTime);
        }
        if (life<=0)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            life -= 10;
            Destroy(collision.gameObject);
        }
    }
}