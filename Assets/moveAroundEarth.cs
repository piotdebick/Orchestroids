using UnityEngine;
using System.Collections;

public class moveAroundEarth : MonoBehaviour {
	public float speed = 3.0f;
	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () {
		//transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0f), speed);

		//Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint (Input.mousePosition);

		//Get the angle between the points
		float angle = AngleBetweenTwoPoints (positionOnScreen, mouseOnScreen);

		//Ta Daaa
		transform.rotation = Quaternion.Euler (new Vector3 (angle-90f, 90f, 0f));

	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
		return Mathf.Atan2(b.x*2f - a.x*2f, b.y - a.y) * Mathf.Rad2Deg;
	}
}
