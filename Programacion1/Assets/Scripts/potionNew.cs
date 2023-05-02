using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionNew : MonoBehaviour
{
    public float healAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Player>().Heal(healAmount);

            Destroy(gameObject);

        }
    }



}
