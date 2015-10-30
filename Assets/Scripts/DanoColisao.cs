using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class DanoColisao : MonoBehaviour, Habilidade {
	public float dano;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnColisionEnter(Collision other){
		colisao (other.gameObject);
	}

	#region Habilidade implementation

	public void colisao (GameObject objeto)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
