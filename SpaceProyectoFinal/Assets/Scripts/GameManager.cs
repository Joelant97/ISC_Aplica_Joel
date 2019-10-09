using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public Ball ball;
    public Barra barra;
    public static Vector2 botonLeft;
    public static Vector2 supRight; 

	// Use this for initialization
	void Start () {
        botonLeft = Camera.main.ScreenToWorldPoint(new Vector2 (0, 0));
        supRight = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));

        //Instantiate de los objetos.
        Instantiate (ball);

        Barra barra1 = Instantiate(barra) as Barra;
        Barra barra2 = Instantiate(barra) as Barra;

        barra1.Iniciar (true); 
        barra2.Iniciar (false); 


    }
	
	
}
