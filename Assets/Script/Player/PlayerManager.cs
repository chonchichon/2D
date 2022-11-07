using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public PlayerHP playerHP;
    public PlayerAttack playerAttack;
    public Animator m_ani;
    public static PlayerManager _instance;
    public static PlayerManager Instance
    
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Player");
                    _instance = container.AddComponent<PlayerManager>();
                }
            }

            return _instance;
        }
    }
    private void Start()
    {
        playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        m_ani = GetComponent<Animator>();
       
    }
}
