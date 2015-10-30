using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Heroi : MonoBehaviour, Personagem {

	public enum TipoDirecao {
		esquerda, direita
	}

	TipoDirecao direcao = TipoDirecao.direita;

	public CharacterController personagem;
	public GameObject mao;
	public Vector3 direcaoAceleracao;
	public Vector3 direcaoRotacao;
	public Rigidbody rigidBody;
	public float gravidade = 9.8f;

	//public float aceleracao;
	public float velocidade;
	public float forcaPulo;
	public float alturaPulo;
	public float velPulo;
	public bool pulo = false;

	//variaveis de pulo considerando fisica
	public float hPulo;
	public float ttPulo = 0.14f;
	public float tpPulo;
	public float viPulo = 1.37f;
	public float framesPulo = 4;
	public float frameTmpPulo;

	//public float rotacao;

	public float vida;
	public EstadoHeroi estado;
	public Arma arma;
	public Arma[] armas;

	public bool escada = false;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		arma = Instantiate(armas [0], mao.transform.position, Quaternion.identity) as Arma;
		arma.PosicaoDaArma (mao);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw ("Horizontal") < 0 && direcao == TipoDirecao.direita) {
			transform.eulerAngles = new Vector3(0, 180, 0);
			direcao = TipoDirecao.esquerda;
			
		} else if (Input.GetAxisRaw ("Horizontal") > 0 && direcao == TipoDirecao.esquerda) {
			transform.eulerAngles = new Vector3(0, 0, 0);
			direcao = TipoDirecao.direita;
			
		}
		
		// Andar para esquerda e direita //
		direcaoAceleracao = new Vector3 (0, 0, Input.GetAxis ("Horizontal") * velocidade * Time.deltaTime);

		if (personagem.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				pulo = true;
				//hPulo = (viPulo * tPulo) + (-gravidade * (tPulo * tPulo))/2;
				//forcaPulo = - viPulo / - tPulo;
				frameTmpPulo=0;
			}
		} 


		if (pulo == true) {
			frameTmpPulo++;
			if(frameTmpPulo < framesPulo){
				tpPulo = ttPulo / framesPulo;
				hPulo = (viPulo * tpPulo) + (-gravidade * (tpPulo * tpPulo))/2;
				direcaoAceleracao.y = hPulo;
			} else { 
				pulo = false;
			}
		}

		if (escada == true) {

			direcaoAceleracao.y = Input.GetAxis ("Vertical") * velocidade * Time.deltaTime;
		
		
		} else {
		
			direcaoAceleracao.y -= gravidade * Time.deltaTime;
		
		}

		personagem.Move(direcaoAceleracao);
		
		if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
			
			atacar();
		}

	}

	void OnTriggerEnter(Collider other){
	
		if (other.transform.tag == "Cenario") {
			pulo = false;
		}

		if (other.transform.tag == "Escada" && Input.GetButtonDown ("Vertical")) {
			escada = true;
		}
	
	}

	void OnTriggerStay(Collider other){
	
		if (other.transform.tag == "Escada" && Input.GetButtonDown ("Vertical")) {
			escada = true;
		}

		if (other.transform.tag == "Escada" && Input.GetButtonDown ("Jump")) {
			escada = false;
		}

	}

	void OnTriggerExit(Collider other){

		if (other.transform.tag == "Escada") {
			escada = false;
		}
	
	}

	void OnCollisionEnter(Collision other){

		if (other.transform.tag == "Escada") {
			escada = true;

		}
	}

	public bool GetEscada(){
		return escada;
	}

	
	#region Personagem implementation
	public void atacar ()
	{
		arma.dispararTiros ();
	}
	public void recebeDano (float dano)
	{
		//throw new System.NotImplementedException ();
	}
	public void movimento ()
	{
		//throw new System.NotImplementedException ();
	}
	public void colisao ()
	{
		//throw new System.NotImplementedException ();
	}
	#endregion
}
