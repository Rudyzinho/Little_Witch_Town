using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer MyspriteR;
    //public bool flipX;

    public float moveSpeed;
    public float vasMs;
    float moveSpeedbc;
    float moveX;
    float moveY;

    private Vector2 moveDirection;

    Collider2D m_Collider;

    //float side = 1;

    public GameObject vaS;

    private void Awake()
    {
        MyspriteR = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeedbc = moveSpeed;

    }


    void Update()
    {
        
        Voo();
        //DesativarVass();
        //StartCoroutine(DesativarVass());

        ProcessInputs();

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            MyspriteR.flipX = true;
            //side = -1;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            MyspriteR.flipX = false;
            //side = 1;
        }

        //transform.right = Vector2.right * side;

    }

    private void FixedUpdate()
    {

        Move();
        OnAnimatorMove();

    }

    void ProcessInputs()
    {
         moveX = Input.GetAxisRaw("Horizontal");
         moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void OnAnimatorMove()
    {

        if (moveX != 0 || moveY != 0)
        {
            anim.SetBool("Run", true);
        }
       else
        {
            anim.SetBool("Run", false);
        }

    }

    void Voo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Liga e desliga o Collider ao pressionar a barra de espaço
            m_Collider.enabled = !m_Collider.enabled;

            if (vaS.activeSelf == true) {
                vaS.SetActive(false);
                 moveSpeed = moveSpeedbc;
                anim.SetBool("Fly", false);
            }  
            else { 
                vaS.SetActive(true);
                moveSpeed = vasMs;
                anim.SetBool("Fly", true);
            }
        }
    }

    /*IEnumerator DesativarVass()
    {
        yield return new WaitForSeconds(3f);
        vaS.SetActive(false);
        m_Collider.enabled = !m_Collider.enabled;
    }*/
}
