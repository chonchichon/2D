using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_boss : MonoBehaviour
{
    int derection;
    [SerializeField] float maxspeed, coolDown;
    [SerializeField]Transform Player;
    [SerializeField] private Vector2 rayCastOffset;
    bool isCooldown;
    private RaycastHit2D rightRaycastHit;
    private RaycastHit2D leftRaycastHit;
    [SerializeField] float JumbForceX,JumbForceY;
    [SerializeField] private float rayCastLength = 2;
    [SerializeField] private LayerMask rayCastLayerMask;
   
    Animator m_ani;
    bool canMove;
   
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerManager.Instance.transform;
        m_ani = GetComponent<Animator>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(!isCooldown&&canMove)
        {
        CheckJumb();
        Move();
        }
        checkDerection();  
    }

    private void Move()
    {
      
     
        transform.position = Vector2.MoveTowards(transform.position, Player.position, maxspeed * Time.deltaTime);
    }

    void checkDerection()
    {
        if ((transform.position.x - Player.position.x) > 0)
        {
            derection = -1;
        }
        else derection = 1;
    }
    void CheckJumb()
    {
        rightRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.right, rayCastLength, rayCastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.right * rayCastLength, Color.black);
        leftRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y - rayCastOffset.y), Vector2.left, rayCastLength , rayCastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y - rayCastOffset.y), Vector2.left * rayCastLength, Color.black);
        if (rightRaycastHit.collider != null || leftRaycastHit.collider != null)
        {
            canMove = false;
            m_ani.SetTrigger("jump");
            Invoke("Jump", 0.5f);
        }
     
    }
    public void Jump()
    {
        if (!isCooldown)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(derection * JumbForceX, JumbForceY), ForceMode2D.Impulse);
            isCooldown = true;
            StartCoroutine(coolDownJumb());
        }
      

    }
    IEnumerator coolDownJumb()
    {
        yield return new WaitForSeconds(coolDown);
        isCooldown = false;
        canMove = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !PlayerManager.Instance.playerHP.immu)
        {
              if (derection > 0)
              { PlayerManager.Instance.transform.position = new Vector2(PlayerManager.Instance.transform.position.x + 2, PlayerManager.Instance.transform.position.y); }
              if(derection<0)
              { PlayerManager.Instance.transform.position = new Vector2(PlayerManager.Instance.transform.position.x - 2, PlayerManager.Instance.transform.position.y); } 
            
        }
    }
        
}
