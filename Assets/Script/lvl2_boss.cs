using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2_boss : MonoBehaviour
{
    [SerializeField] bool canSlam, blinking;
    Transform target;
    [SerializeField] Rigidbody2D slam;
    [SerializeField] float maxspeed = 2f;
    [SerializeField] float blinkTime, jumpForce;
    [SerializeField] Transform left, right;
    [SerializeField] float speedSlam;
    [SerializeField] GameObject slamef;

    

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance.transform;
        InvokeRepeating("Blink", 3f,blinkTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.OverlapCircle(transform.position, 1.5f, LayerMask.GetMask("Ground"))) canSlam = true;
    }
    private void FixedUpdate()
    {
       if(!blinking) Move();
       
    }
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, maxspeed * Time.deltaTime);
    }
    void Blink()
    {
        
        blinking = true;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"&& canSlam==true)
        {
            blinking = false;
            canSlam = false;
            //        Rigidbody2D rigidbody;
            //       rigidbody = Instantiate(slam, left.position, left.rotation);
            //        rigidbody.velocity = new Vector2(-speedSlam, 0);

            //       Rigidbody2D rigidbody2;
            //      rigidbody2 = Instantiate(slam, right.position, right.rotation);
            //       rigidbody2.velocity = new Vector2(speedSlam, 0);
            Instantiate(slamef, transform.position, transform.rotation);
           
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
        Gizmos.color = Color.black;
    }
  
}
