using UnityEngine;
using System.Collections;

public class destroyEarth : MonoBehaviour 
{
    
   
	void OnCollisionEnter(Collision anything)
    {
        AudioSource audio = GetComponent<AudioSource>();
     
        audio.Play();
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Detonator>().Explode();
       
    }
	




}
