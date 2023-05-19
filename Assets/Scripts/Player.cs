using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Rigidbody2D myRigid;
    public Animator animator;

    public float moveSpeed;

    public float jumpPower;
    public int jumpChance;
    public int maxJumpChance;

    bool isGround;
    public Transform pos, pos2;
    public float checkRadius;
    public LayerMask islayer;

    void Awake()
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
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer) || Physics2D.OverlapCircle(pos2.position, checkRadius, islayer);
        if (isGround) jumpChance = maxJumpChance;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0);
            animator.SetBool("move", true);
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(moveSpeed * Time.fixedDeltaTime, 0, 0);
            animator.SetBool("move", true);
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("move", false);
        }
    }

    public void Jump()
    {
        if (jumpChance > 0)
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, jumpPower);
            jumpChance--;
        }
    }
}
