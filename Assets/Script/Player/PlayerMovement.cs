using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PhysicsObject
{
 
    [SerializeField] public float jumpPower = 10;
    [SerializeField] public float maxSpeed = 1;
    [SerializeField] public int maxJumps = 2;
    [SerializeField] public float dashForce,dashDuration;
    int jumps;
    bool cdBwJump = false;
    bool isDash;
    float currentDashTimer;
    [SerializeField] float cdJump = 0.3f;
   
    private void Start()
    {
    
        
    }


    private void Update()
    {
        if (grounded == true) jumps = maxJumps;
        Dash();     
        Movement();    
        Flip();
        SetAnimation();
      
    }
    private void LateUpdate()
    {
        
            Jumb();
        
    }
    private void Movement()
    {     
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        
    }



    private void Jumb()
    {

        if (Input.GetButtonDown("Jump") && jumps > 1&& cdBwJump ==false)
        {
            
            cdBwJump = true;
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            jumps -= 1;
            StartCoroutine(cooldownJump());
        }    
    }
    IEnumerator cooldownJump()
    {
        yield return new WaitForSeconds(cdJump);
        cdBwJump = false;
    }
    private void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDash = true;
            currentDashTimer = dashDuration;
            rb2d.velocity = Vector2.zero;
        }
        if(isDash == true)
        {
            rb2d.velocity=new Vector2(dashForce*transform.localScale.x,1) ;
            currentDashTimer -= Time.deltaTime;
          
            if(currentDashTimer<=0)
            {
                isDash = false;
                rb2d.velocity = Vector2.zero;
            }
        }
    }
    private void Flip()
    {
        if (targetVelocity.x > 0) { transform.localScale = new Vector3(1, 1, 1); }
        if (targetVelocity.x < 0) { transform.localScale = new Vector3(-1, 1, 1); }
    }
    void SetAnimation()
    {
        PlayerManager.Instance.m_ani.SetFloat("velocityX", Mathf.Abs(targetVelocity.x));
        if(rb2d.velocity.y>0) PlayerManager.Instance.m_ani.SetBool("jump", true);
     if(grounded==true)  PlayerManager.Instance.m_ani.SetBool("jump", false);
    }
}
