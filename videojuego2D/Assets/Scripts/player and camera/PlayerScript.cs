using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private Rigidbody rb;
	public float velocity = 2f;
	public float jumpForce = 250;
	private int health = 100;
	private bool walk;
	private bool run;
	public bool jump = false;
	private Transform modelTransform;
	private GameObject childModel;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		modelTransform = gameObject.transform.GetChild (0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//rb.velocity = velocity;
		if(Input.GetKey(KeyCode.D)){
			transform.position += transform.right * velocity * Time.deltaTime;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (new Vector3(0f,0f,0f)), 1f);
			//rb.AddForce(new Vector3(1,0,0)*velocity);
		}
		else if(Input.GetKey(KeyCode.A)){
			transform.position -= transform.right * velocity * Time.deltaTime;
			//rb.AddForce(new Vector3(-1,0,0)*velocity);
		}
		if(Input.GetKey(KeyCode.W)){
			transform.position += transform.forward * velocity * Time.deltaTime;
			//rb.AddForce(new Vector3(0,0,1)*velocity);
		}
		else if(Input.GetKey(KeyCode.S)){
			transform.position -= transform.forward * velocity * Time.deltaTime;
			//rb.AddForce(new Vector3(0,0,-1)*velocity);
		}
		if(Input.GetKeyDown(KeyCode.Space)&&jump){
			rb.AddForce(new Vector3(0,1,0)*jumpForce);
			//jump=false;
		}
		if(health<=0){
			GameObject.Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Enemy") {
			health-=10;
		}
		if (collision.gameObject.tag == "Floor") {
			jump = true;
		}
	}

	void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "Floor") {
			jump = false;
		}
	}

	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Warp") {
			Vector3 newPos = new Vector3(53.34f,9.48f,-38f);
			transform.position=newPos;
		}
	}
}
