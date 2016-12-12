using UnityEngine;
using System.Collections;

public class TogglePhysicsButton : MonoBehaviour
{
    public GameObject target;
    public GameObject state1, state2;

    public Color originalColor, newColor;
    public float originalIntens, newIntens;

    bool state = false;

    // Use this for initialization
    void Start()
    {
        target.GetComponent<teleport>().setDest(state1);
        GetComponent<Renderer>().material.color = originalColor;
        target.GetComponent<teleport>().setColor(originalColor, originalIntens);
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
        if (!state && state2)
        {
            GetComponent<Renderer>().material.color = newColor;
            target.GetComponent<teleport>().setDest(state2);
            target.GetComponent<teleport>().setColor(newColor, newIntens);
        }
        else if(state1)
        {
            GetComponent<Renderer>().material.color = originalColor;
            target.GetComponent<teleport>().setDest(state1);
            target.GetComponent<teleport>().setColor(originalColor, originalIntens);
        }
        state = !state;
    }
}
