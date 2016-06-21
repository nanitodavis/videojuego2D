using UnityEngine;
using System.Collections;

public class EnemyBasic : MonoBehaviour {

	public Transform targePlayer;
	//private Transform myTransform;
	private float moveSpeed;
	private Rigidbody rbe;
	public Animator anim;

	// Use this for initialization
	void Start () {
		moveSpeed = 1.5f;
		GameObject temp = GameObject.FindGameObjectWithTag ("Player");
		targePlayer = temp.transform;
		//yTransform = transform;
		rbe = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//condicional para caminar hacia el targetPlayer, es decir hacia el jugador en sentido derecha-izquierda
		if (transform.position.x > (targePlayer.position.x + 2.5f)) {
			//rota al enemigo para que siempre este mirando al jugador, toma como parametros el la rotacion del objeto que se afecta, una posicion inicial y final para realizar la rotacion y una velocidad de rotacion
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (targePlayer.position - transform.position), 1f*Time.deltaTime/*para normalizar la rotacion*/);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			anim.Play ("walk");
		}

		//condicional para caminar hacia el targetPlayer, es decir hacia el jugador en sentido izquierda-derecha
		else if (transform.position.x < (targePlayer.position.x - 2.5f)) {
			//rota al enemigo para que siempre este mirando al jugador, toma como parametros el la rotacion del objeto que se afecta, una posicion inicial y final para realizar la rotacion y una velocidad de rotacion
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (targePlayer.position - transform.position), 1f*Time.deltaTime);
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			anim.Play ("walk");
		} else {
			anim.Play ("idle");

		}
	}

	public float MoveSpeed{
		get;
		set;
	}
}
