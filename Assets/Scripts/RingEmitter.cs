using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RingEmitter : MonoBehaviour {

    public GameObject Ring;
    public float InitialScale;
    public float FadeSpeed;
    public float MaxDistance;
    public float MovementSpeed;
    public float GrowthSpeed;
    public float SpawnsPerSec;

    private float animationTimer;
    private List<GameObject> Rings;

	// Use this for initialization
	void Start () {
        Rings = new List<GameObject>();
        InvokeRepeating("SpawnRing", 0, 1f/SpawnsPerSec);        
	}
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnRing()
    {
        GameObject ring;

        if (Rings.Count == 0)
        {
            ring = Instantiate(
                Ring,
                this.transform.position,
                this.transform.rotation,
                this.transform
            );

            ring.transform.localScale *= InitialScale;
        }

        else
        {
            ring = Rings.First();
            Rings.Remove(ring);
        }

        ring.SetActive(false);
        ring.SetActive(true);
        StartCoroutine(Animate(ring));
    }

    

    IEnumerator Animate(GameObject ring)
    {
        MeshRenderer renderer = ring.GetComponent<MeshRenderer>();
        Material material = renderer.material;

        float curDistance = Vector3.Distance(this.transform.position, ring.transform.position);
        Vector3 initLocalScale = ring.transform.localScale;
        Vector3 initPosition = ring.transform.position;
        float initAlpha = renderer.material.color.a;

        while (true)
        {            
            ring.transform.localScale += ring.transform.localScale * (GrowthSpeed * Time.deltaTime);
            ring.transform.position += Vector3.back * (MovementSpeed * Time.deltaTime);

            //float curDistance = Vector3.Distance(transform.position, ring.transform.position);
            float newAlpha = renderer.material.color.a * (1 - FadeSpeed * Time.deltaTime);
            renderer.material.color = new Color(
                renderer.material.color.r,
                renderer.material.color.g,
                renderer.material.color.b,
                newAlpha
            );

            if (curDistance > MaxDistance)
            {
                Destroy(ring);
                break;
                //Rings.Add(ring);
            }

            curDistance = Vector3.Distance(this.transform.position, ring.transform.position);
            yield return null;
        }

        //ring.transform.position = initPosition;
        //ring.transform.localScale = initLocalScale;

        //renderer.material.color = new Color(
        //       renderer.material.color.r,
        //       renderer.material.color.g,
        //       renderer.material.color.b,
        //       initAlpha
        //   );

        //ring.SetActive(false);

        //Rings.Add(ring);
        //Destroy(ring);
    }
}
