using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TesouraParabola : MonoBehaviour, Tiro {
	public float dano;
	public Vector3 direcao;
	public float velocidade;
	private bool mostra = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnColisionEnter(Collision other){
		colisao (other);
	}
	
	#region implemented abstract members of Tiro
	public void colisao (Collision other)
	{
		throw new System.NotImplementedException ();
	}
	
	public void comportamento ()
	{
		// Verifica se saiu da Camera // 
		
		if (!mostra) {
			Destroy(this);
		}
	}
	#endregion
}
