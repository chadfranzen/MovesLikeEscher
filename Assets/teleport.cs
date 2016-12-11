using UnityEngine;
using UnityEngine;
using System.Collections;
using System;

public class teleport : MonoBehaviour, PhysicsButtonTarget
{
    public GameObject destination, otherDest;
    public float [] intensities = new float[2];
    public Color[] colors = new Color[2];
    public bool maintainOrientation = true;
    public GameObject setVisible;
    public GameObject setInvisible;
    public float cooldown;
    public GameObject BulletPrefab;
    private int i;

    private float time = -1;
	public bool newMode = true;
    // Use this for initialization
    void Start()
    {
        i = 0;
        GetComponent<Light>().color = colors[i];
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
        if (other.tag == "Bullet")
        {
            return;
        }
        if (cooldown <= 0 || Time.fixedTime - time > cooldown)
        {
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
                /*if(other.tag == "Bullet" && !other.GetComponent<BulletScript>().teleported)
                {
                    Debug.Log("Found bullet!");
                    Vector3 pos = other.transform.position;
                    float vel = other.GetComponent<BulletScript>().speed;
                    GameObject bullet = Instantiate(other.transform.gameObject);
                    bullet.GetComponent<BulletScript>().teleported = true;
                    //bullet.transform.position = pos;

                    bullet.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity;
                    //bullet.transform.Translate(direction * 3);
                }*/

                if (Math.Abs(this.transform.forward.x - other.transform.forward.x) <= 100 &&
                    Math.Abs(this.transform.forward.y - other.transform.forward.y) <= 100 &&
                    Math.Abs(this.transform.forward.z - other.transform.forward.z) <= 100 )
                {
                    Debug.Log("Teleporting...");
                    Transform oldParent = other.transform.parent;
                    other.transform.parent = this.transform;

                    GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                    foreach (GameObject bullet in bullets)
                    {
                        bullet.transform.parent = other.transform;
                    }


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
                    foreach (GameObject bullet in bullets)
                    {
                        bullet.transform.parent = null;
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

    public void activate()
    {
        GameObject temp = destination;
        destination = otherDest;
        otherDest = temp;
        toggle();
        destination.GetComponent<teleport>().toggle();
    }
    public void toggle()
    {
        GetComponent<Light>().color = colors[(++i) % 2];
        GetComponent<Light>().intensity = intensities[i % 2];
        if (i == 2) i = 0;
    }
}
