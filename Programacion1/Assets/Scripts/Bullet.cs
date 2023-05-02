using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime = 4.0F;
    public int bulletDamage;
   

    void Start()
    {
        bulletDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        Destroy(gameObject,lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //aca empezamos a usar la comunicacion entre scripts.
            //cuando obtenemos el collision.GameObject, estamos accediendo a todo el GO que colisionamos. entonces?
            //lo llamamos con la siguiente funcion que se llama "GetComponent<TipoDe>". y el tipo de componente que queremos.
            //Metodos/variables, todo lo que sea publico en ese script.
            //podemos pedir cualquier componente que tenga el game object con el que colisionamos.

            collision.gameObject.GetComponent<DestructibleObject>().GetDamage();

            //por ej que cambie el color. tomando en vez del Script, su componente de Sprite Renderer.
            //lo correcto seria que la wall cambie el color no este codigo. pero es a modo ejemplo
            //para que vean como se maneja.
            collision.gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();


        }
        if (collision.gameObject.layer == 11)
        {
            collision.gameObject.GetComponent<StaticEnemy>().GetDamage(bulletDamage);
        }
        if (collision.gameObject.layer == 12)
        {
            collision.gameObject.GetComponent<PatrolEnemy>().GetDamage(bulletDamage);
        }

        Destroy(this.gameObject);            
    }
}
