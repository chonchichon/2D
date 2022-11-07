using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterController2D
{

//sets values for animator
public class AnimUpdator : MonoBehaviour
{
    [SerializeField]
    CharacterMovementScript m_moveScript;

    [SerializeField]
    Animator m_animator;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInfo moveInfo = m_moveScript.GetMovementInfo();


        m_animator.SetFloat("Speed", Mathf.Abs(moveInfo.directionNormal));//left right directional input

        m_animator.SetBool("HitApex", moveInfo.hitApex);//if apex of jump was hit
        m_animator.SetBool("IsGrounded", moveInfo.isGrounded);//if on ground
        m_animator.SetBool("IsCrouching", moveInfo.isCrouching);//crouching
        m_animator.SetBool("IsSliding", moveInfo.isSliding);//sliding down a slope
        m_animator.SetBool("IsDodging", moveInfo.isDodging);//dodging
        m_animator.SetBool("IsJumping", moveInfo.isJumping);//true if ascending and jump wa called, can be used to see if falling or jumping
        m_animator.SetBool("IsNearWall", moveInfo.isNearWall);//if near a wall, used with "isGrounded" to find if wall sliding
    }
}

}