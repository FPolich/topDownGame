using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    //creamos el enemigo.
    //hacemos que mire al personaje
    //detectamos rango con trigger
    //detectamos rango con distancia minima
    //creamos bullet enemy
    //disparamos cuando este en rango al target.
    public int life;
    public Transform target;
    public bool canRotate;
    public float minDistance;
    public GameObject EnemyBullet;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public float fireTimer;

    void Start()
    {
        life = 20;
        //para que el primer disparo siempre salga. si asi se desea.
        fireTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //para que no sume indefinidamente.
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }       

        //calculamos la distancia.
       float actualDistance = Vector3.Distance(transform.position, target.position);

        if (actualDistance <= minDistance)
        {
            canRotate = true;
        }
        else 
        {
            canRotate = false;
        }

        if (canRotate)
        {
           LookTarget();
            if (fireTimer>=fireRate)
            {
                Shoot();
            }
        }
        
    }

    public void LookTarget() 
    {
        //aca viene un poco de matematica pura.
        //vamos a determinar el vector entre el enemigo y el target.
        //si hacemos la resta de vectores, nos devuelve el vector q nos devuelve los dos puntos.
        //seria B-A. posicion final menos posicion inicial.

        Vector3 vectorToTarget = target.position - transform.position;

        //vamos a usar el arco tangente de un vector nos devuelve el angulo de ese Vector.
        //usamos la funcion Atan2( que seria "atan to")
        //y que es lo que estamos haciendo?, le estamos pasando cuantas posiciones en "Y" y cuantas posiciones en "X". forman este vector.
        //y dado eso determina el angulo el vector. pero hay un problema. nos lo devuelve en radianes.. entopnces lo tranformamos de radianes a grados.
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        //quaterion maneja las rotaciones.
        // utilizamos el AngleAxis. que maneja el angulo segun el eje en el que me quiera mover.
        //entonces le pasamos. el angulo que resolvimos recien. y en que eje. en este caso sabemos que en el mundo en Vector3 el "Z" es el forward,
        //y en 2d el "Z" es el eje X para rotacion.

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //esta opcion es si lo queremos hacer por trigger que Detecte el rango.

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 7)
    //     {
    //         canRotate = true;
    //     }
    // }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 7)
    //     {
    //         canRotate = false;
    //     }
    //
    // }

    private void OnDrawGizmos()
    {
       // Gizmos.color = Color.red;
        Gizmos.color = new Vector4(1,0,1,0.5f);
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }

    void Shoot() 
    {
        Instantiate(EnemyBullet, bulletSpawn.position, bulletSpawn.rotation);
        fireTimer = 0;
    }

    public void GetDamage(int amount) 
    {
        life -= amount;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
