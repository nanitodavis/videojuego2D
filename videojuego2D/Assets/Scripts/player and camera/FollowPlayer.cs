using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public Vector3 ahead;
	public Vector3 newPos;
	public float offset = 3f;
	// Use this for initialization
	void Start () {
		ahead = new Vector3 (0f, 0f, 0f);
		ahead.x = target.transform.position.x + offset;
		ahead.y = target.transform.position.y;
		ahead.z = target.transform.position.z;
		//newPos = new Vector3 (ahead.x, target.transform.position.y, target.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		if((transform.position.x-target.transform.position.x)<offset&&(transform.position.x-target.transform.position.x)>(offset-1f)){
			ahead.x = transform.position.x;
		}
		else if (transform.position.x-offset>=(target.transform.position.x)){
			ahead.x -= 0.05f;
		}
		else if(transform.position.x-offset<=(target.transform.position.x)){
			ahead.x += 0.05f;
		}
		//ahead.x = target.transform.position.x + offset;
		ahead.y = target.transform.position.y + 4f;
		ahead.z = target.transform.position.z + -5f;
		newPos = new Vector3 (ahead.x, ahead.y, ahead.z);
		transform.position = newPos;
	}
}
