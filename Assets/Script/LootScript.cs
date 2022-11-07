using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public int total, randomNum;
    public List<item> items = new List<item>();
    
    
    public void LootTable()
    {
        total = 0;
      
        foreach(item item in items)
        {
            total += item.dropWeights;
        }
         randomNum = Random.Range(0, total);
        for(int i =0; i< items.Count; i++)
        {
            if(randomNum<= items[i].dropWeights)
            {
                Debug.Log("drop" + items[i].name);
                return;
            }
            else
            {
                randomNum -= items[i].dropWeights;
            }
        }
    }
   

    [System.Serializable]
    public class item
    {
        public string name;
        public GameObject items;
        public int dropWeights;
    }

}
