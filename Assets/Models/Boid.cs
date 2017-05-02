using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

	private Vector3 velocity;
	private Vector3 maxVelocity = new Vector3(0.5f, 0.5f, 0.5f);
	private Vector3 maxAcceleration = new Vector3(0.005f, 0.005f, 0.002f);
	private Vector3 initialPosition;
	private float maxDistance = 3.0f;

	// Use this for initialization
	void Start()
	{
		velocity = max(
            new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ),
            maxVelocity
		);
		initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update()
	{
		var distanceFromOrigin = Vector3.Distance(transform.position, initialPosition);
		if (distanceFromOrigin > maxDistance)
		{
			moveTo(initialPosition);
		}
		transform.position += velocity;
	}

	private void moveTo(Vector3 target)
	{
		var acceleration = new Vector3(target.x, target.y, target.z);
		acceleration -= transform.position;
        acceleration = new Vector3(
            acceleration.normalized.x * maxAcceleration.x,
            acceleration.normalized.y * maxAcceleration.y,
            acceleration.normalized.z * maxAcceleration.z
        );
		velocity += acceleration;
		velocity = max(velocity, maxVelocity);
	}

	private Vector3 max(Vector3 v1, Vector3 v2) 
	{
		var maxVector = new Vector3(v1.x, v1.y, v1.z);
		maxVector.x = Mathf.Max(maxVector.x, -v2.x);
		maxVector.y = Mathf.Max(maxVector.y, -v2.y);
		maxVector.z = Mathf.Max(maxVector.z, -v2.z);
		maxVector.x = Mathf.Min(maxVector.x, v2.x);
		maxVector.y = Mathf.Min(maxVector.y, v2.y);
		maxVector.z = Mathf.Min(maxVector.z, v2.z);
		return maxVector;
	}
}
