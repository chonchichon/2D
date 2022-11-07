using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] Transform GunPos;
    [SerializeField] Vector2 BulletSpeed;
    [SerializeField] bool isCoolDownGun;
    [SerializeField] bool holdGun;
    [SerializeField] float timeCDGun;
    public int BulletDmg =1 ;

    [SerializeField] GameObject AttackBoxSw;
    [SerializeField] float attackBoxDur;
    [SerializeField] bool holdSword;
    public int SwordDmg =2;

    [SerializeField] bool holdWand;
    public int MagicDmg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackWithGun();
        AttackWithSword();
        AttackWithWand();
    }

    private void AttackWithWand()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && holdWand)
        {
            transform.position = new Vector2(transform.position.x + 3, transform.position.y);
        }
    }

    void AttackWithGun()
    {
        if(Input.GetKeyDown(KeyCode.RightControl) &&!isCoolDownGun && holdGun)
        {
            Rigidbody2D gameObject;
            gameObject= Instantiate(bullet, GunPos.position, GunPos.rotation);
            gameObject.velocity = BulletSpeed* new Vector2(transform.localScale.x, 1f);
            isCoolDownGun = true;
            StartCoroutine(coolDownGun());
            PlayerManager.Instance.m_ani.SetTrigger("atkGun");
          
        }
    }
    IEnumerator coolDownGun()
    {
        yield return new WaitForSeconds(timeCDGun);
        isCoolDownGun = false;
    }
        
    void AttackWithSword()
    {
        if(Input.GetKeyDown(KeyCode.RightControl)&&holdSword)
        {
            AttackBoxSw.SetActive(true);
            StartCoroutine(deactiveAttackBox());
            PlayerManager.Instance.m_ani.SetTrigger("atkSw");
            GameObject.Find("SwordBox").GetComponent<Animator>().SetTrigger("atk");
        }
    }
    IEnumerator deactiveAttackBox()
    {
        yield return new WaitForSeconds(attackBoxDur);
        AttackBoxSw.SetActive(false);
    }
}
