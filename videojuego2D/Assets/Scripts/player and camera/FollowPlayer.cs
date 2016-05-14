using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public Vector3 ahead;
	public Vector3 newPos;
	// Use this for initialization
	void Start () {
		ahead = new Vector3 (0f, 0f, 0f);
		ahead.x = target.transform.position.x + 3f;
		ahead.y = transform.position.y;
		ahead.z = transform.position.z;
		newPos = new Vector3 (ahead.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		ahead.x = target.transform.position.x + 3f;
		ahead.y = target.transform.position.y + 4f;
		newPos = new Vector3 (ahead.x, ahead.y, ahead.z);
		transform.position = newPos;
		
	}
}
