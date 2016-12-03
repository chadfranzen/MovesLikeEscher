using UnityEngine;
using System.Collections;

public class MovePath : MonoBehaviour, PhysicsButtonTarget {
    public Transform endPoint;
    public float travelTime = 6.0f;

    private bool active = false;
    private bool hitPointOne = false;
    private bool hitPointTwo = false;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3[] points = new Vector3[2];

    private float t = 0;
    private float rotationT = 0;

    private Quaternion startRotation;
    private Quaternion endRotation;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        endPosition = endPoint.position;
        points[0] = new Vector3(endPosition.x, startPosition.y, startPosition.z);
        points[1] = new Vector3(endPosition.x, endPosition.y, startPosition.z);

        startRotation = transform.rotation;
        endRotation = endPoint.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!active)
        {
            return;
        }
        rotationT += Time.deltaTime / travelTime;
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, rotationT);
        if (!hitPointOne)
        {
            t += Time.deltaTime / (travelTime / 3);
            transform.position = Vector3.Lerp(startPosition, points[0], t);
            if (Mathf.Approximately(0f, Vector3.Distance(transform.position, points[0])))
            {
                hitPointOne = true;
                t = 0;
            }
        } else if (!hitPointTwo)
        {
            Debug.Log("Point two");
            t += Time.deltaTime / (travelTime / 3);
            transform.position = Vector3.Lerp(points[0], points[1], t);
            if (Mathf.Approximately(0f, Vector3.Distance(transform.position, points[1])))
            {
                hitPointTwo = true;
                t = 0;
            }
        } else if (hitPointTwo)
        {
            t += Time.deltaTime / (travelTime / 3);
            transform.position = Vector3.Lerp(points[1], endPosition, t);
            if (Mathf.Approximately(0f, Vector3.Distance(transform.position, endPosition)))
            {
                active = false;
                hitPointOne = false;
                hitPointTwo = false;
                t = 0;
                Vector3 temp = startPosition;
                startPosition = endPosition;
                endPosition = temp;
                temp = points[0];
                points[0] = points[1];
                points[1] = temp;

                Quaternion tempR = startRotation;
                startRotation = endRotation;
                endRotation = tempR;
                rotationT = 0;
            }
        }
	}

    public void activate()
    {
        if (active)
        {
            return;
        }
        t = 0;
        rotationT = 0;
        active = true;
    }
}
