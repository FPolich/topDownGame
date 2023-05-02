using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    void Update()
    {
        // Obtenemos la posici�n del mouse en el mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculamos la direcci�n del mouse con respecto al personaje
        Vector3 direction = mousePos - transform.position;

        // Calculamos el �ngulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotamos el sprite del personaje hacia el �ngulo calculado
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}


