using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    public Transform bullet, bullet2;
    public Transform pivot;

    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, pivot.transform.position, this.gameObject.transform.rotation);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet2, pivot.transform.position, this.gameObject.transform.rotation);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
