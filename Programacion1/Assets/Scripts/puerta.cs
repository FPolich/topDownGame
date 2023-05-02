using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class puerta : MonoBehaviour
{
    // Se obtiene la referencia al componente SpriteRenderer en el objeto actual
    private SpriteRenderer spriteRenderer;
    //duracion del fade.
    public float fadeOutDuration = 1.0f;

  //  public GameObject potion;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            var target = collision.gameObject.GetComponent<Player>();
          if (target != null) 
          { 
            if (target.llaves > 0)
            {
                StartCoroutine(FadeOutColor()); // comienza la rotación de la puerta
                collision.gameObject.GetComponent<Player>().llaves = 0;

                 //  Instantiate(potion,transform.position,transform.rotation);

                //en caso que quiera que al collisionar la puerta se vuelva trigger el boxcollider. y se pueda traspasar.
                //buscamos el componente del boxcollider y llamamos a su variable "isTrigger".
                // this.gameObject.GetComponent<BoxCollider2D>().isTrigger= true;
            }
          }
        }
    }

    private IEnumerator FadeOutColor()
    {    
        #region explicacionDetalladaDelLerp

        /*En este código, se utiliza la función Color.Lerp para interpolar gradualmente entre dos colores en función del progreso de la transición.

        La función Color.Lerp toma tres argumentos: el primer color, el segundo color y un valor t que representa el progreso de la transición. 
        Cuando t es 0.0, el color resultante será igual al primer color. Cuando t es 1.0, el color resultante será igual al segundo color. 
        Cuando t está en algún punto intermedio entre 0.0 y 1.0, el color resultante será una mezcla entre los dos colores.

        En el código que proporcionaste, initialColor representa el color inicial del objeto (antes de que se desvanezca) 
        y fadedColor representa el color que se desea alcanzar cuando la transparencia del objeto llegue a 0.0.

        Dentro del bucle while, el progreso de la transición se calcula como un valor t entre 0.0 y 1.0, 
        en función del tiempo transcurrido y la duración total del desvanecimiento. A continuación, 
        se utiliza la función Color.Lerp para interpolar gradualmente entre initialColor y fadedColor, 
        en función de t, y se establece el resultado como el nuevo color del objeto (spriteRenderer.color).

        De esta manera, el objeto cambiará gradualmente de su color original a un color desvanecido, 
        a medida que su transparencia disminuy

         */
        #endregion


        //fadeOut de color a 0 su alpha.

        // Se define la transparencia inicial del objeto
        Color initialColor = spriteRenderer.color;

    // Se crea un nuevo color que tiene los mismos valores de rojo, verde y azul que el color inicial, pero con una transparencia de 0.0f
    Color fadedColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0.0f);
    
    // Se define el tiempo total que tomará desvanecer el objeto (en segundos)
    float fadeOutDuration = 1.0f;
    
    // Se define el tiempo transcurrido desde el inicio del desvanecimiento
    float elapsedTime = 0.0f;
    
    // Se utiliza un bucle while para cambiar gradualmente la transparencia del objeto hasta 0.0f
       while (elapsedTime < fadeOutDuration)
       {
           // Se calcula el progreso de la transición como un valor entre 0.0f y 1.0f, en función del tiempo transcurrido y la duración total del desvanecimiento
           float t = elapsedTime / fadeOutDuration;
       
           // Se utiliza la función Color.Lerp para interpolar entre el color inicial y el color desvanecido en función del progreso de la transición
           spriteRenderer.color = Color.Lerp(initialColor, fadedColor, t);
       
           // Se actualiza el tiempo transcurrido y se espera al siguiente frame
           elapsedTime += Time.deltaTime;
           yield return null;
       }
       
      // Una vez que se ha alcanzado la transparencia deseada, se establece el color del objeto en el color desvanecido para asegurarse de que su transparencia sea exactamente 0.0f
      spriteRenderer.color = fadedColor;
    
       // Se desactiva el objeto
      gameObject.SetActive(false);
    }
}
    