using UnityEngine;
using System.Collections;

public class CameraPrincipal : MonoBehaviour {

	private GameObject player;
	private Vector3 posicao;
	public float x = 13;
	public float y = 3.09f;
	public float velocidade = 5;
	private float dist = 1f;
	private float distAtual;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Player");

	
	}
	
	// Update is called once per frame
	void Update () {

		distAtual = Mathf.Abs (player.transform.position.z - transform.position.z);

		if (distAtual > dist) {

			posicao = Vector3.Lerp (posicao, new Vector3 (x, y, player.transform.position.z), velocidade * Time.deltaTime);
			transform.position = posicao;

		}
	
	}
}
