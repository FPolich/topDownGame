using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerAction : MonoBehaviour
{
    public GameObject door;
    public bool onTrigger = false;    
    public int speed;

    public Vector3 posInicial;

    private void Start()
    {
        posInicial = door.transform.position;
    }
    public void Update()
    {

     /*   if (onTrigger)
        {
          // Debug.Log("estoy en trigger");

            if (Input.GetKey(KeyCode.Space))
            {
                door.transform.Translate(0, 1 * Time.deltaTime * speed, 0);
               
            }
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("estoy en trigger");
           // onTrigger = true;
            if (Input.GetKey(KeyCode.Space))
            {
                //para que funcione se resuelve con ponber el rigidbody en neversleep
                door.transform.Translate(0, 1 * Time.deltaTime * speed, 0);
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("sali del trigger");
            onTrigger= false;

            door.transform.position = posInicial;
        }
    }
}
