using UnityEngine;
using System.Collections;

public class rotate_asteroid : MonoBehaviour {
	public float speed = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate (new Vector3(1, 1, 1), speed * Time.deltaTime);

    }
}
