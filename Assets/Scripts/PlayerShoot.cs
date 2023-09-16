using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject yellowBullet;
    public GameObject purpleBullet;
    public Transform bulletPos;

    public int bulletCnt;
    public int maxBulletCnt;

    int direction;
    Coroutine gunUsing;

    public RawImage[] bulletUI;

    // Start is called before the first frame update
    void Start()
    {
        bulletCnt = maxBulletCnt;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            if (gunUsing == null)
            {
                if (bulletCnt > 1)
                    gunUsing = StartCoroutine(YellowBullet());
                else
                    gunUsing = StartCoroutine(PurpleBullet());

            }
        RefreshBulletUI();
    }

    public IEnumerator YellowBullet()
    {
        bulletCnt--;
        Instantiate(yellowBullet, bulletPos.position, bulletPos.rotation);
        EffectManager.instance.EffectSoundsPlay(0);
        yield return new WaitForSeconds(1.4f);
        gunUsing = null;
    }
    public IEnumerator PurpleBullet()
    {
        bulletCnt--;
        Instantiate(purpleBullet, bulletPos.position, bulletPos.rotation);

        if (Player.instance.transform.localScale.x < 0) direction = 1;
        else direction = -1;
        if (Input.GetKey(KeyCode.DownArrow))
            Player.instance.myRigid.velocity = new Vector2(0, 15);
        else
            Player.instance.myRigid.velocity = new Vector3(15 * direction, 0, 0);
        EffectManager.instance.EffectSoundsPlay(1);
        yield return new WaitForSeconds(1.4f);
        bulletCnt = maxBulletCnt;
        gunUsing = null;
    }
    public void RefreshBulletUI()
    {
        for (int i = 0; i < bulletUI.Length; i++)
        {
            if (i < bulletCnt)
                bulletUI[i].enabled = true;
            else
                bulletUI[i].enabled = false;
        }

    }
}




/*
 * 
 * 총알이 생겨나야 됨
 * 방향 총 쏘고있을 때 보는 방향
 * 속도 일정하게, 일직선
 * 쿨타임
 * 충돌하면 없어짐 (적 체력도 깎아야 함)
 * 
 * 
 */