using UnityEngine;
using System.Collections;

public class PhysicsButton : MonoBehaviour {
    public float coolDownTime;
    public GameObject target;

    private Color originalColor;

    bool inCooldown = false;

    private float timeHit = 0;
	// Use this for initialization
	void Start () {
        //originalColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (!inCooldown || coolDownTime == -1)
        {
            return;
        }
        if (Time.fixedTime - timeHit > coolDownTime)
        {
            inCooldown = false;
            GetComponent<Renderer>().material.color = originalColor;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Bullet")
        {
            return;
        }
        if (!inCooldown)
        {
            target.GetComponent<PhysicsButtonTarget>().activate();
            originalColor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
            timeHit = Time.fixedTime;
            inCooldown = true;
        }
    }
}
