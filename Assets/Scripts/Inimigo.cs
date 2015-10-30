using UnityEngine;
using System.Collections.Generic;
using AssemblyCSharp;

public class Inimigo : MonoBehaviour, Personagem {

	public float vida;
	public EstadoInimigo estado;
	public Arma arma;
	public List<GameObject> habilidades;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	#region Personagem implementation
	public void atacar ()
	{
		arma.dispararTiros ();
	}
	public void recebeDano (float dano)
	{
		throw new System.NotImplementedException ();
	}
	public void movimento ()
	{
		throw new System.NotImplementedException ();
	}
	public void colisao ()
	{
		throw new System.NotImplementedException ();
	}
	#endregion
}
