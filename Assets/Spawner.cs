using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject boid;
    private int BOID_COUNT = 30;
    private Boid[] boids;

	// Use this for initialization
	void Start () {
        boids = new Boid[BOID_COUNT];
        for (var i = 0; i < BOID_COUNT; i++)
        {
            var createdBoid = Instantiate(boid, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Boid>();
            createdBoid.Initialise(boids);
            boids[i] = createdBoid;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
