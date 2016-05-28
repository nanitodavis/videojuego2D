using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private Rigidbody rb;
	public float velocity = 13f;
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
		if(Input.GetKey(KeyCode.D)&&rb.velocity.x<=5f){
			rb.AddForce(new Vector3(1,0,0)*velocity);
		}
		else if(Input.GetKey(KeyCode.A)&&rb.velocity.x>=13f){
			rb.AddForce(new Vector3(-1,0,0)*velocity);
		}
		else if(Input.GetKey(KeyCode.A)){
			rb.AddForce(new Vector3(-1,0,0)*velocity);
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
