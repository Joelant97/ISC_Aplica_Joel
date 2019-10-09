using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    float velocidad;
    float radio;

    Vector2 dir;

    // Use this for initialization
    public void Start()
    {
        dir = Vector2.one.normalized;
        radio = transform.localScale.x / 2;
    }

    // Update is called once per frame
    public void Update()
    {

        transform.Translate(dir * velocidad * Time.deltaTime);

        if (transform.position.y < GameManager.botonLeft.y + radio && dir.y < 0)
        {
            dir.y = -dir.y;
        }

        if (transform.position.y > GameManager.supRight.y - radio && dir.y > 0)
        {
            dir.y = -dir.y;
        }

        //Fin del Juego
        if (transform.position.x < GameManager.botonLeft.x + radio && dir.x < 0) {
            Debug.Log("Jugador1 (Der) ha ganado. ");

            Time.timeScale = 0;
            enabled = false;
        }

        if (transform.position.x > GameManager.supRight.x - radio && dir.x > 0)
        {
            Debug.Log("Jugador2 (Izq) ha ganado. ");
            Time.timeScale = 0;

            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Barra") 
        {
            bool isRight = other.GetComponent<Barra>().isRight;

            if (isRight == true && dir.x > 0) {
                dir.x = -dir.x;
            }
            if (isRight == false && dir.x < 0)
            {
                dir.x = -dir.x;
            }
        }
    }


  
}
