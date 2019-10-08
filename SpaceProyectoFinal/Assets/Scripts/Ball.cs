using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float VelocidadInicial = 5;

    Rigidbody2D rb; 

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Iniciar(); 

    }
	
	// Update is called once per frame
	void Iniciar () {
        
        rb.velocity = (Random.value > 0.5f ? 1 : -1) * Vector3.right * VelocidadInicial;
	}
}
