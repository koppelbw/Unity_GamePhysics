using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	
	public float launchSpeed;
	public float maxLaunchSpeed;
	public AudioClip windup;
	public AudioClip launch;
	public PhysicsEngine ballToLaunch;

	public float speedIncreasePerFrame;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = windup;	// So we know the length of the clip for next line
		//speedIncreasePerFrame = (maxLaunchSpeed * Time.fixedDeltaTime) / audioSource.clip.length;
		speedIncreasePerFrame = 1.5f;
	}

	void OnMouseDown() {
		launchSpeed = 0f;
		InvokeRepeating ("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
		audioSource.clip = windup;
		audioSource.Play ();
	}

	void OnMouseUp() {
		CancelInvoke ();
		audioSource.Stop ();
		audioSource.clip = launch;

		// Launch Ball
		PhysicsEngine newBall = Instantiate (ballToLaunch) as PhysicsEngine;
		newBall.transform.parent = GameObject.Find ("Launched Balls").transform;
		Vector3 launchVelocity = new Vector3 (1, 1, 0).normalized * launchSpeed;
		newBall.velocityVector = launchVelocity;
	}

	void IncreaseLaunchSpeed() {
		Debug.Log ("Increasing speed");
		if (launchSpeed <= maxLaunchSpeed) {
			launchSpeed += speedIncreasePerFrame;
		}
	}
}
