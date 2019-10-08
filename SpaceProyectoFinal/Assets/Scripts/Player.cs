using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Velocidad;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame(Esto es del Pong Player Bihaviour)
    void Update()
    {
        rb.velocity = Vector3.up * Input.GetAxis("Vertical") * Velocidad;

    }
}
