using UnityEngine;
using System.Collections;

public class DontMove : MonoBehaviour {
    Quaternion iniRot; 

    // Use this for initialization
    void Start () {
        iniRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = iniRot;
	}
}
