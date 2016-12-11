using UnityEngine;
using System.Collections;

public class TogglePhysicsButton : MonoBehaviour
{
    public GameObject target, tgtlight;

    public Color originalColor, newColor;

    bool state = false;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = originalColor;
        tgtlight.GetComponent<Light>().color = originalColor;
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
            tgtlight.GetComponent<Light>().color = newColor;
        }
        else 
        {
            GetComponent<Renderer>().material.color = originalColor;
            tgtlight.GetComponent<Light>().color = originalColor;
        }
        state = !state;
    }
}
