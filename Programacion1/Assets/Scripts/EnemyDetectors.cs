using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectors : MonoBehaviour
{
    //para dsp buscar el objeto hijo puerta dentro.
   // public GameObject theRoom;

    //podes arrastrar el objeto. o llamarlo por codigo.
   public  GameObject doorToOpen;

    public List<GameObject> enemiesInArea;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {       
        //tb podemos  buscar el child con nombre Puerta.
      //  doorToOpen = theRoom.transform.Find("puerta").gameObject;
    }

 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            enemiesInArea.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 12)
        {
            enemiesInArea.Remove(collision.gameObject);

            if (enemiesInArea.Count == 0)
            {
                doorToOpen.SetActive(false);
            }
        }

    }
}
