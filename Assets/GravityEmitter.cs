using UnityEngine;
using System.Collections;

public class GravityEmitter : MonoBehaviour {
    public float mass;
    public GameObject me;
    public Color color;
    bool debug;

    // Allows for gravity to be exerted only in one direction, e.g. for a the floor, only in the Y-direction.
    // In the above case, you would set directionMask to a Vector3(0, 1, 0).
    public Vector3 mask;
	// Use this for initialization
	void Start () {
        debug = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            float dist = Vector3.Distance(other.transform.position, me.transform.position);
            Vector3 dir = (me.transform.position - other.transform.position) / dist;
            other.GetComponent<Rigidbody>().AddForce(Vector3.Scale(mask, dir * mass * 100 * Time.deltaTime / (dist * dist)));
        }
    }
}
