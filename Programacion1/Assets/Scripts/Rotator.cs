using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject Target;
    public GameObject Target2;


    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Target.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Target.transform.localScale = new Vector3(-1, 1, 1);
            Target2.transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Target.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Target.transform.localScale = new Vector3(1, 1, 1);
            Target2.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Target.transform.localRotation = Quaternion.Euler(0,0,-90);
            Target.transform.localScale = new Vector3(-1,1,-1);
            Target2.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
           Target.transform.localRotation = Quaternion.Euler(0,0,90);
           Target.transform.localScale = new Vector3(-1,-1,-1);
           Target2.transform.localRotation = Quaternion.Euler(0, 0, -180);
        }
    }
}
