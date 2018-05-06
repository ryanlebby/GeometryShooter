using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> Prefabs;
    public float SpawnRate = 3f;

    private float timer;

	// Use this for initialization
	void Start () {
        timer = SpawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 0)
        {
            timer = SpawnRate;

            int rand = Random.Range(0, Prefabs.Count);
            var prefab = Prefabs[rand];

            GameObject go = Instantiate(
                prefab, 
                this.transform.position, 
                this.transform.rotation, 
                this.transform);
        }

        else
        {
            timer -= Time.deltaTime;
        }
	}
}
