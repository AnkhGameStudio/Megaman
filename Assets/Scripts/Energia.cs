using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Energia : MonoBehaviour, Tiro {

	public float dano;
	public float velocidade = 20;
	private bool mostra = true;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(0, 0, velocidade * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Cenario") {
		
			Destroy(gameObject);
		
		}
	}

	#region Tiro implementation
	public void colisao (Collision other)
	{
		//throw new System.NotImplementedException ();
	}
	public void comportamento ()
	{
		// Verifica se saiu da Camera // 
		
		if (!mostra) {
			Destroy (gameObject);
		}
	}
	#endregion
}