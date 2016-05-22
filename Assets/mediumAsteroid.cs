using UnityEngine;
using System.Collections;

public class mediumAsteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //var pos = GameObject.Find("Fonso-Earth").transform.position;
        Vector3 pos = new Vector3(0, 0, 0);
        float speed = 1.5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
	}
}
