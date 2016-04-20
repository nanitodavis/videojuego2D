using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private Rigidbody rb;
	private GameObject player;
	public float velocity = 15f;
	public float jumpForce = 180f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		player = gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.D)){
			rb.AddForce(new Vector3(1,0,0)*velocity);
		}
		else if(Input.GetKey(KeyCode.A)){
			rb.AddForce(new Vector3(-1,0,0)*velocity);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(new Vector3(0,1,0)*jumpForce);
		}
	}

	void OnCollisionEnter(Collision collision){
		//if()
	}
}
