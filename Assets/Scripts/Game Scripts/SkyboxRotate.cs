using UnityEngine;
using System.Collections;

public class SkyboxRotate : MonoBehaviour {

    public bool isEnabled = false;

    // Use this for initialization
    void Start ()
    {
       
    }


    // Update is called once per frame
    void Update ()
    {
        if (isEnabled == true)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * 3);
        }
    }

    public void enableSkybox()
    {
        isEnabled = true;
    }
}
