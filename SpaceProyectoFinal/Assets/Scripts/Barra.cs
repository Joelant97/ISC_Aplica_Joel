using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {
    [SerializeField]
    float velocidad;
    float altura;
    string input;
    public bool isRight; 

	// Use this for initialization
	void Start () {
        altura = transform.localScale.y;
        //velocidad = 5f;
	}

    public void Iniciar (bool isRightBarra)
    {
        isRight = isRightBarra;
        Vector2 pos = Vector2.zero;

        if (isRightBarra)
        {
            //Barra en la Izquierda de la pantalla
            pos = new Vector2(GameManager.supRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "BarraDer";

        }
        else {
            //Barra en la Derecha de la pantalla
            pos = new Vector2(GameManager.botonLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "BarraIzq";
        }
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update () {
        float move = Input.GetAxis(input) * Time.deltaTime * velocidad;

        if (transform.position.y < GameManager.botonLeft.y + altura / 2 && move <0)
        {
            move = 0; 
        }

        if (transform.position.y > GameManager.supRight.y - altura / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);



    }
}
