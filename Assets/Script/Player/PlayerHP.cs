using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int PlayerMaxHp = 3, playerCurrentHP;
    [SerializeField] float DelayHurt;
    public bool immu;
    void Start()
    {
        immu = false;
        playerCurrentHP = PlayerMaxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if (playerCurrentHP <= 0)
        {
            PlayerManager._instance.m_ani.SetTrigger("die");
        }
    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(DelayHurt);
        immu = false;
    }
    public void PlayerTakerDmg(int dmg)
    {
        if(immu == false)
        {
            playerCurrentHP -= dmg;
            immu = true;
            StartCoroutine(HurtDelay());
            PlayerManager.Instance.m_ani.SetTrigger("gethit");
        }
        
    }
}
