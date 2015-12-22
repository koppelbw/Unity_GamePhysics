using UnityEngine;
using System.Collections;

public class MagnusEffect : MonoBehaviour {

	public float magnusConstant = 1f;

	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		myRigidbody.AddForce (magnusConstant * Vector3.Cross (myRigidbody.angularVelocity, myRigidbody.velocity));
	}
}
