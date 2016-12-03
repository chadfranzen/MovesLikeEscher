using UnityEngine;
using System.Collections;

public class PhysicsButton : MonoBehaviour {
    public float coolDownTime = 2;
    public GameObject target;

    private float timeHit = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Bullet")
        {
            return;
        }
        if (Time.fixedTime - timeHit > coolDownTime)
        {
            target.GetComponent<PhysicsButtonTarget>().activate();
        }
    }
}
