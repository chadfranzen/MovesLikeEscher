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
        Debug.Log("Teleporting");
        if (maintainOrientation)
        {

            if (Math.Abs(this.transform.forward.x - other.transform.forward.x) <= 1 &&
                Math.Abs(this.transform.forward.y - other.transform.forward.y) <= 1 &&
                Math.Abs(this.transform.forward.z - other.transform.forward.z) <= 1)
            {
                Vector3 offSet = this.transform.position - other.transform.position;
                other.transform.position = destination.transform.position + offSet.z * destination.transform.right - offSet.x * destination.transform.forward;

                Quaternion rOff = Quaternion.Inverse(this.transform.rotation) * other.transform.rotation;
                other.transform.rotation = destination.transform.rotation * rOff;

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
