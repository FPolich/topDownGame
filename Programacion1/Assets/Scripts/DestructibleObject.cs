using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int hitsToDestroy;
    public void GetDamage()
    {
        hitsToDestroy--;
        if (hitsToDestroy <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
