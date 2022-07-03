using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vassoura : MonoBehaviour
{
    //private SpriteRenderer MyspriteR;
    float side = -1;

    

    // Start is called before the first frame update
    void Start()
    {
        //MyspriteR = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //MyspriteR.flipX = true;
            side = 1;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //MyspriteR.flipX = false;
            side = -1;
        }
        transform.right = Vector2.right * side;
    }

    
}
