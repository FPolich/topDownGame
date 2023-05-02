using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomActivation : MonoBehaviour
{
    public GameObject theRoom;
    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            theRoom.gameObject.SetActive(true);
        }
     

    }

}
