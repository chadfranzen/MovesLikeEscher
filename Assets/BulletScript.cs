using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    private float spawnTime;
    public float lifetime;
    public float speed;
    private Vector3 lastpos;
    public bool teleported = false;

    // Use this for initialization
    void Start () {
        spawnTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
        speed = (transform.position - lastpos).magnitude / Time.deltaTime;
        lastpos = transform.position;
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
