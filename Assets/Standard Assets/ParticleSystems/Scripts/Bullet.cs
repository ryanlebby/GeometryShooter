using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Velocity = 10f;
    public float MaxRange;

    private Vector3 origin;

	// Use this for initialization
	void Start () {
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Velocity * Time.deltaTime;

        if (Vector3.Distance(transform.position, origin) > MaxRange)
        {
            Destroy(gameObject);
        }
	}
}
