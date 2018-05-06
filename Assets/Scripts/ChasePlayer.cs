using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public float MoveSpeed;
    //public Transform Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(
            this.transform.position, 
            Camera.main.transform.position, 
            MoveSpeed * Time.deltaTime
        );
	}
}
