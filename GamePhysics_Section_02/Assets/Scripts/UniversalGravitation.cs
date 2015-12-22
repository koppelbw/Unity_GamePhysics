using UnityEngine;
using System.Collections;

public class UniversalGravitation : MonoBehaviour {

	private const float gravitationalConstant = 6.673e-11f;		// [m^3 / kg * s^2]
	private PhysicsEngine[] physicsEngineArray;

	// Use this for initialization
	void Start () {
		physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine> ();	// finds all the PhysicEngine Objects
	}

	void FixedUpdate() {
		CalculateGravity ();
	}

	// F1 = F2 = G(m1 * m2 / r^2)
	void CalculateGravity() {
		
		foreach (PhysicsEngine physicsEngineA in physicsEngineArray) {
			foreach (PhysicsEngine physicsEngineB in physicsEngineArray) {
				if(physicsEngineA != physicsEngineB && physicsEngineA != this) {
					//Debug.Log ("Calculating Gravitational Force exterted on: " + physicsEngineA.name
					//	       + " due to the gravity of " + physicsEngineB.name);
					
					Vector3 deltaDistance = physicsEngineA.transform.position - physicsEngineB.transform.position;
					float rSquared = Mathf.Pow (deltaDistance.magnitude, 2f);
					float gravitationalMagnitude = gravitationalConstant * ((physicsEngineA.mass * physicsEngineB.mass) / rSquared);
					Vector3 gravitationalForceVector = gravitationalMagnitude * deltaDistance.normalized;
					
					physicsEngineA.AddForce(-gravitationalForceVector);
				}
			}
		}
	}
}
