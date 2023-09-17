using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            speed = 0;
            animator.SetTrigger("die");
            Destroy(gameObject, 1);
            SoundManager.instance.ChangeBGM(3);
            EventManager.instance.bossCleared = true;
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }
}
