using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour {
    public TextMesh PlayerText, Player2Text;
    public GameObject Player1, Player2;
    static int _score1, _score2;
    public GameObject Ball; 
    bool _player1Scored;



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name !="bomb")
            return;
        _player1Scored = gameObject.name == "Player2DeadZone";
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
