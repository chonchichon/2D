using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
    
{
    public GameObject ShopPanel;
    [SerializeField] Button shop1, shop2, shop3,x;
    
    // Start is called before the first frame update
    void Start()
    {
        ShopPanel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        x.onClick.AddListener(() => CloseShop());
        Shop1();
    }

    private void Shop1()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerManager.Instance.gameObject)
        {
            ShopPanel.SetActive(true);
        }
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
}
