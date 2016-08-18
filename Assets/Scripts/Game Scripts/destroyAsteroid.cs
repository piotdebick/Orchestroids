using UnityEngine;
using System.Collections;

public class destroyAsteroid : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        AudioSource audio = GetComponent<AudioSource>();

        switch (col.gameObject.tag)
        {
            case "Projectile":
                 gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Detonator>().Explode();
                audio.Play();
                Destroy(gameObject,3);
                break;

        }

        
    }
    
}

