using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreJugador : MonoBehaviour {
    public static ScoreJugador instance;

    public Text JugadorUnoScoreText;
    public Text JugadorDosScoreText;
    
    public int JugadorUnoScore;
    public int JugadorDosScore;


	// Use this for initialization
	void Start () {
        instance = this;

        JugadorUnoScore = JugadorDosScore = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GiveJugadorUnoPuntos() {
        JugadorUnoScore += 1;
        JugadorUnoScoreText.text = JugadorUnoScore.ToString();

    }

    public void GiveJugadorDosPuntos()
    {
        JugadorDosScore += 1;
        JugadorDosScoreText.text = JugadorDosScore.ToString();

    }

}
