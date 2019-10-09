using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour {
    public int puntos;
    public Text text;

    // Use this for initialization
    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Ball")) {
            puntos++;
            ActualizarTexto();
            col.GetComponent<Ball>().Iniciar(); ;
            
        }
    
		
	}
	
	// Update is called once per frame
	void ActualizarTexto () {
        text.text = puntos.ToString();
	}
}
