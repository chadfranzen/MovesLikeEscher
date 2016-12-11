using UnityEngine;
using UnityEngine;
using System.Collections;
using System;

public class TheEndIsNeverTheEnd : MonoBehaviour {
    public GameObject ob;
	// Use this for initialization
	void Start () {
        ob.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        ob.SetActive(false);
    }
}
