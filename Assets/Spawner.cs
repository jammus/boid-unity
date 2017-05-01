using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject boid;

	// Use this for initialization
	void Start () {
        for (var i = 0; i < 30; i++)
        {
            Instantiate(boid, new Vector3(0, 0, 0), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
