using UnityEngine;
using System.Collections;

public class destroyProjectile : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case "Asteroid":
                gameObject.GetComponent<Renderer>().enabled = false;
               // Destroy(gameObject, 1);
                Destroy(gameObject);
                break;

        }
    }
}
