using UnityEngine;
using System.Collections;

public class Torque : MonoBehaviour {

	public Vector3 torque;
	public float torqueTime;

	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (torqueTime >= 0f) {
			myRigidbody.AddTorque (torque);
			torqueTime -= Time.deltaTime;	//physics framerate
		}
	}
}
