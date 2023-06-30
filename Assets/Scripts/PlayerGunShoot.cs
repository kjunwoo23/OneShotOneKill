using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunShoot : MonoBehaviour
{
    public Transform gunShootPos;
    public GameObject bullet, bulletPurple;
    public RawImage[] bulletUI;

    public int shootCnt;

    public float purplePower;

    bool gunUsing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            if (!gunUsing)
                if (shootCnt > 1)
                {
                    gunUsing = true;
                    StartCoroutine(ShootNormal());
                }
                else if (shootCnt > 0)
                {
                    gunUsing = true;
                    StartCoroutine(ShootPurple());
                }
        RefreshBulletUI();
    }


    IEnumerator ShootNormal()
    {
        shootCnt--;
        Player.instance.animator.SetTrigger("shoot");
        Instantiate(bullet, gunShootPos.position, gunShootPos.rotation);
        EffectManager.instance.EffectSoundsPlay(0);

        yield return new WaitForSeconds(0.7f);

        EffectManager.instance.EffectSoundsPlay(2);

        yield return new WaitForSeconds(0.7f);

        gunUsing = false;
    }

    IEnumerator ShootPurple()
    {
        shootCnt--;
        Player.instance.animator.SetTrigger("shoot");

        if (Input.GetKey(KeyCode.DownArrow))
            Player.instance.myRigid.velocity = new Vector2(0, purplePower);
        else if (Player.instance.transform.localScale.x < 0)
            Player.instance.myRigid.velocity = new Vector2(purplePower, 0);
        else
            Player.instance.myRigid.velocity = new Vector2(-purplePower, 0);

        Instantiate(bulletPurple, gunShootPos.position, gunShootPos.rotation);
        EffectManager.instance.EffectSoundsPlay(1);

        yield return new WaitForSeconds(0.7f);

        EffectManager.instance.EffectSoundsPlay(2);

        yield return new WaitForSeconds(0.7f);

        Reload();
        gunUsing = false;
    }
    public void Reload()
    {
        shootCnt = 4;
    }
    public void RefreshBulletUI()
    {
        for (int i = 0; i < bulletUI.Length; i++)
        {
            if (i < shootCnt)
                bulletUI[i].enabled = true;
            else
                bulletUI[i].enabled = false;
        }

    }
}
