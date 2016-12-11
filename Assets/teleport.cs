using UnityEngine;
using UnityEngine;
using System.Collections;
using System;

public class teleport : MonoBehaviour
{
    public GameObject destination;
    public bool maintainOrientation = true;
    public GameObject setVisible;
    public GameObject setInvisible;
    public float cooldown;
    public GameObject BulletPrefab;

    private float time = -1;
	public bool newMode = true;
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
        if (cooldown <= 0 || Time.fixedTime - time > cooldown)
        {
            Debug.Log("Teleporting...");
            if (setVisible != null)
            {
                setVisible.SetActive(true);
            }
			if (newMode)
            {
                var player = other.transform;
                var from = transform;
                var to = destination.transform;


				player.position += to.position-from.position;
                player.rotation *= to.rotation*Quaternion.Inverse(from.rotation);
			}
			else if (maintainOrientation)
            {
                if(other.tag == "Bullet" && !other.GetComponent<BulletScript>().teleported)
                {
                    Debug.Log("Found bullet!");
                    Vector3 direction = other.transform.forward;
                    Vector3 pos = other.transform.position;
                    float vel = other.GetComponent<BulletScript>().speed;
                    GameObject bullet = Instantiate(BulletPrefab);
                    bullet.GetComponent<BulletScript>().teleported = true;
                    bullet.transform.position = pos;
                    bullet.GetComponent<Rigidbody>().velocity = direction * vel;
                    bullet.transform.forward = direction;
                }

                if (Math.Abs(this.transform.forward.x - other.transform.forward.x) <= 1 &&
                    Math.Abs(this.transform.forward.y - other.transform.forward.y) <= 1 &&
                    Math.Abs(this.transform.forward.z - other.transform.forward.z) <= 1 
                    || (other.tag == "Bullet" && !other.GetComponent<BulletScript>().teleported))
                {
                    Transform oldParent = other.transform.parent;
                    other.transform.parent = this.transform;
							
					
                    Vector3 offSet = other.transform.localPosition;
                    //Vector3 offSet = this.transform.InverseTransformPoint(other.transform.position);

                    Quaternion rOff = Quaternion.Inverse(this.transform.rotation) * other.transform.rotation;
                    other.transform.rotation = destination.transform.rotation * rOff;

                    other.transform.parent = destination.transform;
                    other.transform.localPosition = offSet;
                    other.transform.parent = oldParent;
                    if (other.tag != "Bullet")
                    {
                        other.transform.localScale = new Vector3(1, 1, 1);
                    }
                    //other.transform.position = destination.transform.position;
                    //other.transform.Translate(offSet);

                    //other.transform.Translate(new Vector3(offSet.x, 0, offSet.z), destination.transform);

                }
            }
            else
            {
                other.transform.position = destination.transform.position + -1.5f * destination.transform.forward;

                other.transform.eulerAngles = destination.transform.rotation.eulerAngles;
                other.transform.Rotate(0, 180, 0);
            }
            if (setInvisible != null)
            {
                setInvisible.SetActive(false);
            }
        }
        time = Time.fixedTime;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Teleporter exited...");
    }
}
