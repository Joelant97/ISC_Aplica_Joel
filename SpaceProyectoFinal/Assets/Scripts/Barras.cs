using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barras : MonoBehaviour {
    public float MagnitudVelocidad = 5;
    public Vector2 Velocidad; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Ball")) {
            col.GetComponent<Rigidbody2D>().velocity = Velocidad.normalized * MagnitudVelocidad;
        }
		
	}
}
