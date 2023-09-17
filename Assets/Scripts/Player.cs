using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float moveSpeed;

    public Rigidbody2D myRigid;
    public float jumpPower;

    int jumpChance;
    public int maxJumpChance;

    bool isGround;
    public Transform pos, pos2;
    public float checkRadius;
    public LayerMask islayer;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -30) StartCoroutine(LoadManager.instance.GameOver());
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer) || Physics2D.OverlapCircle(pos2.position, checkRadius, islayer);
        if (isGround && myRigid.velocity.y == 0) jumpChance = maxJumpChance;

        if (Input.GetKeyDown(KeyCode.Space) && jumpChance > 0)
        {
            jumpChance--;
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0);
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0);
            transform.localScale = new Vector3(0.5f, transform.localScale.y, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            animator.SetBool("move", true);
        else
            animator.SetBool("move", false);


    }

    public void Jump()
    {
        myRigid.velocity = new Vector2(myRigid.velocity.x, jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) 
            StartCoroutine(LoadManager.instance.GameOver());
            //게임오버
        if (collision.gameObject.CompareTag("bulb"))
            if (EventManager.instance.bossCleared)
            {
                StartCoroutine(EventManager.instance.GameClear());
            }
    }

}
