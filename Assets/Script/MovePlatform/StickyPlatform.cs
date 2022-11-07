using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerManager.Instance.gameObject)
        {
            if (collision.transform.position.y > transform.position.y)
            {
              
            collision.gameObject.transform.SetParent(transform);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerManager.Instance.gameObject)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    private void Update()
    {

       
    }
}
