using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] Transform GunPos;
    [SerializeField] float BulletSpeed;
    [SerializeField] Transform Player;
   
    bool isCoolDownGun;
    [SerializeField] float timeCDGun = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerManager.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCoolDownGun==false)
        {
            Rigidbody2D gameObject;
            gameObject = Instantiate(bullet, GunPos.position, GunPos.rotation);
            gameObject.velocity = BulletSpeed * new Vector2(Player.position.x-GunPos.position.x,Player.position.y-GunPos.position.y) ;
            isCoolDownGun = true;
            StartCoroutine(coolDownGun());
        }
        

    }

    IEnumerator coolDownGun()
    {
    yield return new WaitForSeconds(timeCDGun);
    isCoolDownGun = false;
    }
    
}
