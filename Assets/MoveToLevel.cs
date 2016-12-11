using UnityEngine;
using System.Collections;

public class MoveToLevel : MonoBehaviour {
    public GameObject player;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
	// Use this for initialization
	void Start () {
        two.SetActive(false);
        //three.SetActive(false);
        four.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            one.SetActive(true);
            two.SetActive(false);
            //three.SetActive(false);
            four.SetActive(false);
            player.transform.position = new Vector3(12.19f, 2.44f, 0);
            player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            two.SetActive(true);
            one.SetActive(false);
            //three.SetActive(false);
            four.SetActive(false);
            player.transform.position = new Vector3(3, 18.79f, 116);
            player.transform.rotation = Quaternion.Euler(90, -180, 90);
        }
        if (Input.GetKeyDown("3"))
        {
            //move to the third level
        }
        if (Input.GetKeyDown("4"))
        {
            two.SetActive(false);
            //three.SetActive(false);
            one.SetActive(false);
            four.SetActive(true);
            player.transform.position = new Vector3(-0.55f, -94.63f,-121.4f);
            //player.transform.position = new Vector3(-0f, -67.9f, 17f);
            player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
