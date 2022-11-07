using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] int EnemyMaxHP, EnemyCurrentHP;
    [SerializeField]GameObject deadEff;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHP = EnemyMaxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDie();
    }

    private void EnemyDie()
    {
        if (EnemyCurrentHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadEff, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyTakeDmg(PlayerManager.Instance.playerAttack.BulletDmg); //singleton Player thong ke tat ca cac loai dmg
        }
        if (collision.gameObject.tag == "SwAtkBox")
        {
            EnemyTakeDmg(PlayerManager.Instance.playerAttack.SwordDmg);
        }
    }


    public void EnemyTakeDmg(int dmg)
    {
        EnemyCurrentHP -= dmg;
    }
    
}
