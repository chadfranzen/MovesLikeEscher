using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour, PhysicsButtonTarget {
    bool active = false;

    public Transform target;
    public float travelTime = 3.0f;

    private Vector3 endPosition;
    private Vector3 startPosition;
    private float t = 0;
	// Use this for initialization
	void Start () {
        endPosition = target.position;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Approximately(0f, Vector3.Distance(transform.position, endPosition)))
        {
            return;
        }
        if (active)
        {
            t += Time.deltaTime * travelTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }
	}

    public void activate()
    {
        Debug.Log("Activated");
        active = true;
    }
}
