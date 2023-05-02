using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolEnemy : MonoBehaviour
{
    //
    //creamos variable direction. y movemos hacia el target.
    //

    public int life;

    public Transform target;
    public float speed;
    Rigidbody2D rb;
    Vector3 direction;


    //sistema de patrullaje con Waypoints.//

    public Transform[] wayPoints;
    //pra sabr por que index de wp vamos.
    int waypointINdex = 0;
    //para hacer un back
    int directionArray = 1;

    public float offset = 0.5F;


    //gizmos
    public int distanceRange = 12;




    void Start()
    {
        life = 20;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // vamos a sacar la direccion a la que tiene que ir como dijimos antes es B-A (posFinal menos pos inicial ). y la normalizamos.
        direction = (target.position - transform.position).normalized;


        if (Vector3.Distance(transform.position, target.position) < distanceRange)
        {
            //movimiento por transform persiguiendo al jugador/target.

            // transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            MoveByWaypoints();

        }


    }

    private void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, target.position) < distanceRange * 0.5f) return;
        if (!(Vector3.Distance(transform.position, target.position) < distanceRange)) return;

        //movimiento por RB. persiguiendo al jugador/target.
        rb.MovePosition(rb.position +new Vector2(direction.x, direction.y) * speed * Time.fixedDeltaTime);

        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }


    void MoveByWaypoints()
    {
        //hacemos un if de control.
        //chequeamos que hallan waypoints. sino va a dar errores.
        if (wayPoints.Length <= 0)
        {
            return; //si no hay waypoints, cortamos la ejecucion. y retornamos.
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointINdex].position, speed * Time.deltaTime);

        //le ponemos un offset, por que si ponemos de valor 0. siempre se va a pasar nunca va a estar en 0. en cada frame se va a mover y va a estar girando siempre
        //al rededor.
        if (Vector3.Distance(transform.position, wayPoints[waypointINdex].position) < offset)
        {
            //por que le sumamos la direction array, ( si en este momento vale -1) le va a restar 1. y pasaria al waypoint anterior.
            //ya que nos va a indicar a donde es la direccion el directionArray.
            waypointINdex += directionArray;


            //para hacer que vuelva por el mismo camino simulano un "pathfinding".
            //chequeamos no pasarnos de los limites.
            //en este caso es para que cuando llega al final del array empiece a volver para atras.

            // if (waypointINdex >= wayPoints.Length)
            // {
            //     //por que -2? por que se supone que estamos pasados.
            //     //si estabamos en el 4. volvemos al 3 ( que era el ultimo waypoint) y movete 1 mas anda al 2.
            //     waypointINdex = wayPoints.Length - 2;
            //     //directArray valia 1. osea sumaba iba para adelante. ahora lo invertimos a -1 para q empiece a ir para atras. cuando?
            //     //una vez que llegamos al final del array.
            //     directionArray = -1;
            // }
            //
            // if (waypointINdex < 0)
            // {
            //     waypointINdex = 0;
            //     directionArray = 1;
            // }

            if (waypointINdex >= wayPoints.Length)
            {
                waypointINdex = 0;
            }
        }
    }


    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        Gizmos.color = new Vector4(1, 0, 1, 0.5f);

        Gizmos.DrawWireSphere(transform.position, distanceRange);
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
