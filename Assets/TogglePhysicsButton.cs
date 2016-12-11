using UnityEngine;
using System.Collections;

public class TogglePhysicsButton : MonoBehaviour
{
    public GameObject target;

    public Color originalColor, newColor;

    bool state = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Bullet")
        {
            return;
        }
        target.GetComponent<PhysicsButtonTarget>().activate();
        if (!state)
        {
            GetComponent<Renderer>().material.color = newColor;
        }
        else 
        {
            GetComponent<Renderer>().material.color = originalColor;
        }
        state = !state;
    }
}
