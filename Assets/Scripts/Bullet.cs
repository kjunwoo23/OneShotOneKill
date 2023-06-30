using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPurple;
    public float bulletSpeed;
    int direction;
    // Start is called before the first frame update
    void Start()
    {
        if (Player.instance.transform.localScale.x > 0) direction = 1;
        else direction = -1;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = 0;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        Invoke("DestroyBullet", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (direction != 0)
            transform.position += new Vector3(bulletSpeed * Time.fixedDeltaTime * direction, 0, 0);
        else
            transform.position -= new Vector3(0, bulletSpeed * Time.fixedDeltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
            Destroy(gameObject);
        if (collision.CompareTag("enemy"))
        {
            if (!isPurple)
            {
                collision.GetComponent<Enemy>().hp--;
            }
            else
            {
                collision.GetComponent<Enemy>().hp -= 99;
                collision.GetComponent<Enemy>().enemyRIgid.velocity = new Vector2(direction * 5, 0);

            }
            Destroy(gameObject);

        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
