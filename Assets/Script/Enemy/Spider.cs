using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 5f;
    Transform target;
  
    // Start is called before the first frame update
    void Start()
    {
    
        target = PlayerManager.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if distance < radius =>flow player
        float distance = Vector2.Distance(target.position, transform.position);
        if(distance<radius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime*speed);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
