using UnityEngine;
using System.Collections;

public class MoveToLevel : MonoBehaviour {
    public GameObject player;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
	// Use this for initialization
	void Start () {
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("1"))
        {
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            player.transform.position = new Vector3(12.19f, 2.44f, 0);
            player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            two.SetActive(true);
            one.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            //To move player to end of level 2, uncomment this and comment the next line: player.transform.position = new Vector3(2, -60, 115);
            player.transform.position = new Vector3(3, 18.79f, 116);
            player.transform.rotation = Quaternion.Euler(90, -180, 90);

        }
        if (Input.GetKeyDown("3"))
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(true);
            four.SetActive(false);
            five.SetActive(false);
            player.transform.position = new Vector3(65.20f, 5.15f, -104.32f);
            player.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            two.SetActive(false);
            three.SetActive(false);
            one.SetActive(false);
            four.SetActive(true);
            five.SetActive(false);
            player.transform.position = new Vector3(-0.55f, -94.63f,-121.4f);
            //player.transform.position = new Vector3(-0f, -67.9f, 17f);
            player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKeyDown("5"))
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(true);
            player.transform.position = new Vector3(16, 45, -54f);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
