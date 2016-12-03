using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    private float spawnTime;
    public float lifetime;
	// Use this for initialization
	void Start () {
        spawnTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.fixedTime - spawnTime > lifetime)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
        }
    }
}
