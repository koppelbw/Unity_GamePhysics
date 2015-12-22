using UnityEngine;
using System.Collections;


public class InitialVelocity : MonoBehaviour {

	public Vector3 initialVelocity;
	public Vector3 initialAngularVelocity;

	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		myRigidbody.velocity = initialVelocity;
		myRigidbody.angularVelocity = initialAngularVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
