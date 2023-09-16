using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyRIgid;
    public Canvas canvas;
    public Slider slider;

    public int hp;
    public float moveSpeed;
    public float movePatternTime, maxMovePatternTime;
    public int movePatternDirection;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = hp;
        movePatternDirection = -1;
        movePatternTime = maxMovePatternTime;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)hp;
        if (hp <= 0)
            EnemyDie();
    }

    void FixedUpdate()
    {
        if (maxMovePatternTime == 0) return;


        if (movePatternTime > 0)
            movePatternTime -= Time.fixedDeltaTime;
        else
        {
            movePatternDirection *= -1;
            movePatternTime = maxMovePatternTime;
        }
        transform.position += new Vector3(moveSpeed * movePatternDirection * Time.fixedDeltaTime, 0, 0);
        transform.localScale = new Vector3(-movePatternDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);


        canvas.transform.localScale = new Vector3(-movePatternDirection * Mathf.Abs(canvas.transform.localScale.x), canvas.transform.localScale.y, 1);
    }
    public void EnemyDie()
    {
        animator.SetTrigger("die");
        EffectManager.instance.EffectSoundsPlay(2);
        StartCoroutine(DestroyCor());
    }

    IEnumerator DestroyCor()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}