using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    public int speedRotation;
    public int speed;
    public int llaves;
    public float life;

    public Transform BulletSpawner;
    public GameObject bulletPrefab;

    //timer
    public float fireTimer;
    public float FireCD;

    void Start()
    {
        fireTimer = 0;
    
    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        /*

        //Movimiento 4 direcciones.
         if (Input.GetAxisRaw("Horizontal") != 0)
         {

             rb.MovePosition(rb.position + new Vector2((movement.x * speed * Time.fixedDeltaTime), 0));

            if (Input.GetAxisRaw("Vertical") != 0)
             {              

                 rb.MovePosition(rb.position + new Vector2(0, (movement.y * speed * Time.fixedDeltaTime)));

             }

         }
         else if (Input.GetAxisRaw("Vertical") != 0)
         {

             rb.MovePosition(rb.position + new Vector2(0, (movement.y * speed * Time.fixedDeltaTime)));

             if (Input.GetAxisRaw("Horizontal") != 0)
             {

                 rb.MovePosition(rb.position + new Vector2((movement.x * speed * Time.fixedDeltaTime), 0));

             }

         }*/
         //////////////////////////////////////////////////////////////////
         
        

        rb.MovePosition(transform.position + new Vector3(movement.x, movement.y,0) * speed * Time.fixedDeltaTime);

       rb.MoveRotation(rb.rotation + Input.GetAxisRaw("Horizontal") * -speedRotation * Time.fixedDeltaTime);
    }


    public void Heal(float amount) 
    {
        life+= amount;
    }

    void Shoot()
    {
        if (fireTimer < FireCD)
        {
            fireTimer += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0) && fireTimer >= FireCD)
        {

            Instantiate(bulletPrefab, BulletSpawner.position, BulletSpawner.rotation);

            fireTimer = 0;
        }
    }

    public void TakeDamage(int amount) 
    {
        life -= amount;
        Debug.Log("vida actual :" + life);
    }
/*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11  || collision.gameObject.layer == 12)
        {
            //si nos choca un enemigo capamos nuestra velocidad a cero. para evitar movimientos inesperados.
            rb.velocity = Vector2.zero;
        }
    }*/

}
