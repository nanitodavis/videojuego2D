using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private Rigidbody rb;
	public float velocity = 12f;
	public float jumpForce = 180f;
	private int health = 100;
	private bool walk;
	private bool run;
	private bool jump = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.D)&&rb.velocity.x<=9f){
			rb.AddForce(new Vector3(1,0,0)*velocity);
		}
		else if(Input.GetKey(KeyCode.A)&&rb.velocity.x>=-9f){
			rb.AddForce(new Vector3(-1,0,0)*velocity);
		}
		else if(Input.GetKey(KeyCode.A)){
			rb.AddForce(new Vector3(-1,0,0)*velocity);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
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
	}

	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Warp") {
			Vector3 newPos = new Vector3(0,0,0);
			transform.position=newPos;
			//transform.position.x=0f;
			//transform.position.y=0f;
			//transform.position.z=0f;
		}
	}
}
