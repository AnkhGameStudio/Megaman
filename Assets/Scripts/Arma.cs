using UnityEngine;
using System.Collections.Generic;
using AssemblyCSharp;

public class Arma : MonoBehaviour {
	public List<GameObject> tiros;
	public GameObject canoDaArma;
	public GameObject posicao;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = posicao.transform.position;
		transform.eulerAngles = posicao.transform.eulerAngles;
	
	}

	public void dispararTiros(){

		foreach (GameObject tiro in tiros) {
			Instantiate (tiro, canoDaArma.transform.position, transform.rotation);
		}
	}

	public void PosicaoDaArma(GameObject obj){
		posicao = obj;
	}
}
