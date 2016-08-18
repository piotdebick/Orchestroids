using UnityEngine;
using System.Collections;

public class moveCanon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKey (KeyCode.LeftArrow)) {
			
			transform.position += Vector3.left;

		}
		if (Input.GetKey (KeyCode.RightArrow)) {

			transform.position += Vector3.right;

		}
	}
}
