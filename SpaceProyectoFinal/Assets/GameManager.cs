using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Ball ball;
    public Jugador jugador;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Use this for initialization
    void Start () {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        Instantiate(ball);

        Jugador jugador1 = Instantiate(jugador) as Jugador;
        Jugador jugador2 = Instantiate(jugador) as Jugador;

        jugador1.Init(true);
        jugador2.Init(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
