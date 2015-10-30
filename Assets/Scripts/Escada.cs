using UnityEngine;
using System.Collections;

public class Escada : MonoBehaviour {

	GameObject Player;
	Heroi heroi;
	Collider collider;

	// Use this for initialization
	void Start () {

		Player = GameObject.Find("Player");
		heroi = Player.GetComponent<Heroi> ();
		collider = GetComponent<BoxCollider> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (heroi.GetEscada ()) {

			collider.isTrigger = true;
		
		} else {

			collider.isTrigger = false;
		
		}
	
	}
}
