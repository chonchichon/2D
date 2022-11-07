using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAble : MonoBehaviour
{
     enum ItemType { Heath,MaxHeath,Coin,BulletDmgUp}
    [SerializeField]private ItemType itemType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerManager.Instance.gameObject)
        {
            if(itemType == ItemType.Coin)
            {
                Debug.Log("im coin");
            }
            if(itemType == ItemType.MaxHeath)
            {
                PlayerManager.Instance.playerHP.PlayerMaxHp += 1;
                PlayerManager.Instance.playerHP.playerCurrentHP += 1;
            }
            if (itemType == ItemType.Heath)
            {
                if(PlayerManager.Instance.playerHP.playerCurrentHP < PlayerManager.Instance.playerHP.PlayerMaxHp)
                {

                PlayerManager.Instance.playerHP.playerCurrentHP += 1;
                }
            }
            if(itemType == ItemType.BulletDmgUp)
            {
                PlayerManager.Instance.playerAttack.BulletDmg += 1;

            }

            Destroy(gameObject);
        }
    }
}
