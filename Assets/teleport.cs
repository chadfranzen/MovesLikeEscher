using UnityEngine;
using UnityEngine;
using System.Collections;
using System;

public class teleport : MonoBehaviour
{
    public GameObject destination;
    public bool maintainOrientation = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Teleporter entered...");
    }
    void OnTriggerStay(Collider other)
    {

        if (maintainOrientation)
        {

            if (Math.Abs(this.transform.forward.x - other.transform.forward.x) <= 1 &&
                Math.Abs(this.transform.forward.y - other.transform.forward.y) <= 1 &&
                Math.Abs(this.transform.forward.z - other.transform.forward.z) <= 1)
            {
                Vector3 offSet = other.transform.position - this.transform.position;
                Debug.Log(offSet);

                Quaternion rOff = Quaternion.Inverse(this.transform.rotation) * other.transform.rotation;
                other.transform.rotation = destination.transform.rotation * rOff;

                other.transform.position = destination.transform.position;
                //other.transform.Translate(offSet);
                other.transform.Translate(new Vector3(offSet.x, 0, offSet.z), destination.transform);

            }
        }
        else
        {
            other.transform.position = destination.transform.position + -1.5f * destination.transform.forward;

            other.transform.eulerAngles = destination.transform.rotation.eulerAngles;
            other.transform.Rotate(0, 180, 0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Teleporter exited...");
    }
}
