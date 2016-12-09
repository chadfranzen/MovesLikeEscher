using UnityEngine;
using System.Collections;

public class TogglePhysicsButton : MonoBehaviour
{
    public float coolDownTime;
    public GameObject target;

    public Color originalColor, newColor;

    bool inCooldown = false, state = false;

    private float timeHit = 0;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inCooldown || coolDownTime == -1)
        {
            return;
        }
        if(Time.fixedTime - timeHit > coolDownTime)
        {
            inCooldown = false;
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
            if (state)
            {
                GetComponent<Renderer>().material.color = newColor;
            }
            else 
            {
                    GetComponent<Renderer>().material.color = originalColor;
            }
            timeHit = Time.fixedTime;
            inCooldown = true;
        }
    }
}
