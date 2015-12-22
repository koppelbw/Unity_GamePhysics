using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/* 
	 * Newton's First Law
	 * 		An object either remains at rest or continues to move at a constant velocity, unless acted upon by an external Force
	 * 		if( SumForces == 0 ) then deltaVelocity = 0
	 * 
	 * Velocity
	 * 		Velocity is a vector, calculated by the change in Distance divided by the change in Time
	 *  	v = (df - di) / (tf - ti)
	 * 
	 * Newton's Second Law (F = ma)
	 * 		F: The Vector Net Force on the entire object
	 * 		m: mass
	 * 		a: Acceleration is the change in velocity divided by the change in time
	 *			a = (vf - vi) / (tf - ti)
	 *
	 * Velocity & Acceleration
	 * 		a = v / t    ==>   v = a * t
	 * 
	 * Newton's Third Law
	 * 		forceA on B = -forceB on A
 */
public class PhysicsEngine : MonoBehaviour {
	
	public Vector3 velocityVector;	// [m/s] average velocity this FixedUpdate()
	public Vector3 netForceVector;	// [N -> [kg/(m/s/s)]] Net Force = Mass * Acceleration(dv/dt)
	public float mass;				// [kg]

	private List<Vector3> forceVectorList = new List<Vector3>();
	private UniversalGravitation universalGravitation;

	// Use this for initialization
	void Start () {
		//mass = 1f;
		SetupThrustTrails ();

	}
	
	void FixedUpdate () {
		RenderTrails ();
		UpdatePosition ();
	}

	public void AddForce(Vector3 forceVector) {
		forceVectorList.Add (forceVector);
	}

	void UpdatePosition() {

		// Sum the forces of the vectorList
		netForceVector = Vector3.zero;
		foreach (Vector3 forceVector in forceVectorList) {
			netForceVector += forceVector;
		}

		// Clear the vector List
		forceVectorList.Clear ();

		// Calculate the Delta Velocity of the object
		Vector3 accelerationVector = netForceVector / mass;		// (a = F / mass)  ->  (a = dv/dt) -> (dv = a * dt)
		velocityVector += accelerationVector * Time.deltaTime;	// v(m/s) = a(m/s/s) * t(s/1)

		
		// Update position based on calculated velocity due to the Net Force on the object
		this.gameObject.transform.position += velocityVector * Time.deltaTime;	// distance = v * t
	}




	// DrawForces.cs
	// Draws thrust trails
	// I don't know why the instructor had us take this code from the other file, but w.e
	public bool showTrails = true;
	private LineRenderer lineRenderer;
	private int numberOfForces;

	void SetupThrustTrails() {
		lineRenderer = gameObject.AddComponent<LineRenderer> ();
		lineRenderer.material = new Material (Shader.Find ("Sprites/Default"));
		lineRenderer.SetColors (Color.yellow, Color.yellow);
		lineRenderer.SetWidth (0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}

	void RenderTrails() {
		// DrawForces.cs
		if (showTrails) {
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.SetVertexCount (numberOfForces * 2);
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList) {
				lineRenderer.SetPosition (i, Vector3.zero);
				lineRenderer.SetPosition (i + 1, -forceVector);
				i = i + 2;
			}
		} else {
			lineRenderer.enabled = false;
		}
	}

}
