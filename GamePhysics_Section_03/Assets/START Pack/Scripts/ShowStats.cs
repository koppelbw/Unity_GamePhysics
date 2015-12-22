using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ShowStats : MonoBehaviour {
	
	private Rigidbody rigibody;

	// Use this for initialization
	void Start () {
		rigibody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (name + " Inertia Tensor: " + this.rigibody.inertiaTensor);
		Debug.Log (name + " COM: " + this.rigibody.centerOfMass);
	}
}
