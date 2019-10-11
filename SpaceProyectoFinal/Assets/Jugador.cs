using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
    [SerializeField]
    public float speed;
    float height;

    string input;
    public bool isRight;

	// Use this for initialization
	void Start () {
        height = transform.localScale.y;
        speed = 5f; 
	}

    public void Init(bool isRightJugador) {
        isRight = isRightJugador; 
        Vector2 pos = Vector2.zero;

        if (isRightJugador)
        {
            //Jugador de la derecha
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "JugadorLeft";
        }
        else {
            //Jugador de la izquierda
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "JugadorRight";
        }
        transform.position = pos;

        transform.name = input; 

    }

	// Update is called once per frame
	void Update () {
        //Mover Jugador
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }

        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
	}
}
