using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour {

	public float fuelMass;				// [kg]
	public float maxThrust;				// [kN -> [kg * m /s/s]]

	[Range (0, 1f)]
	public float thrustPercent;			// [none]
	public Vector3 thrustUnitVector;	// [none]

	private PhysicsEngine physicsEngine;
	private float currentThrust;		// [N]


	// Use this for initialization
	void Start () {
		physicsEngine = GetComponent<PhysicsEngine>();
		physicsEngine.mass += fuelMass;
	}

	void FixedUpdate () {
		if (fuelMass > FuelThisUpdate ()) {
			fuelMass -= FuelThisUpdate ();
			physicsEngine.mass -= FuelThisUpdate ();
			ExertForce ();
		} else {
			Debug.Log ("Out of Rocket Fuel!!!");
		}
	}

	void ExertForce() {
		currentThrust = thrustPercent * (maxThrust * 1000f);	// N = kN * 1000
		Vector3 thrustVector = thrustUnitVector.normalized * currentThrust;	// [N]
		physicsEngine.AddForce (thrustVector);
	}

	float FuelThisUpdate() {
		float exhaustMassFlowRate;		// [kg/s]
		float effectiveExhaustVelocity;	// [m/s]

		effectiveExhaustVelocity = 4462f;		// found on wiki page for "Rocket Engine" liquid O/H

		/* Equation from Wiki "Rocket Engine"
		 net Thrust = exhaust gas mass flow * effective exhaust velocity
		 exhaustMassFlowRate = netThrust / effectiveExhaustVelocity */
		exhaustMassFlowRate = currentThrust / effectiveExhaustVelocity;		// kg/s = N(kg/m/s/s) * m/s

		return exhaustMassFlowRate * Time.deltaTime;		// [kg]
	}
}
