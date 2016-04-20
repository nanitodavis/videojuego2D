using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float ahead;
	public Vector3 newPos;
	// Use this for initialization
	void Start () {
		ahead = target.transform.position.x + 3f;
		newPos = new Vector3 (ahead, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		ahead = target.transform.position.x + 3f;
		newPos = new Vector3 (ahead, transform.position.y, transform.position.z);
		transform.position = newPos;
		
	}
}
