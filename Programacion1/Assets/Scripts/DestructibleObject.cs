using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int hitsToDestroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage()
    
    {
        hitsToDestroy--;
        if (hitsToDestroy <=0)
        {
            Destroy(this.gameObject);
        }
    }
   
}
