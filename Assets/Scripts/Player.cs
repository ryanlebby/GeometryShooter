using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Health;
    
    public float HitBoxRadius;
    public LayerMask mask = 1 << 8;
    
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        if (Physics.SphereCast(transform.position, HitBoxRadius, transform.forward, out hit, HitBoxRadius + 1f, mask))
        {
            if (hit.transform.gameObject.tag == "Unit")
            {
                Health -= 1;
                Destroy(hit.transform.gameObject);
            }
        }
        
	}
}
