using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gun : MonoBehaviour {

    public GameObject Projectile;
    public float ProjectileSpeed;

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(
                Projectile,
                transform.position + transform.forward * 2f,
                transform.rotation
            );

            go.GetComponent<Rigidbody>().velocity = transform.forward * ProjectileSpeed;
        }

    }
}
