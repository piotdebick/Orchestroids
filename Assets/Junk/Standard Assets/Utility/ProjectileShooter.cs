using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProjectileShooter : MonoBehaviour {

    moveAroundEarth playerRotation;
    DontMove dontRotate;
    GameObject projectile;
    GameObject shootEffect;
    GameObject loadEffect;
    GameObject playerSatelite;
    GameObject earth;
    GameObject earthSphere;
    GameObject loadButton;

    public float timeSinceShot;
    public bool isLoaded, isShot;
  
	void Start ()
    {
        earth = GameObject.Find("Player Earth");
        earthSphere = GameObject.Find("sphere"); 
        playerRotation = earthSphere.GetComponent<moveAroundEarth>();
        dontRotate = earthSphere.GetComponent<DontMove>();
        projectile = Resources.Load("LightProjectile") as GameObject;
        shootEffect = Resources.Load("ShootEffect") as GameObject;
        loadEffect = Resources.Load("Charge_01.3 Fairydust") as GameObject;
        loadButton = GameObject.Find("Load Button");
        isLoaded = false;
        isShot = false;       
        dontRotate.enabled = true;
        playerRotation.enabled = false;
    }

	void Update ()
    {
        if (isLoaded)
        {
            enablePlayerMove();
        }
        if (Input.GetMouseButtonDown(0) && isLoaded == true)
        {
            loadButton.GetComponent<Button>().interactable = false;
            GameObject SampleProjectile = Instantiate(projectile) as GameObject;
            GameObject ShootingEffect = Instantiate(shootEffect) as GameObject;
            SampleProjectile.transform.position = transform.position;
            ShootingEffect.transform.position = transform.position;
            Rigidbody rigidBody = SampleProjectile.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.forward * -500);
            isShot = true;

            DestroyObject(SampleProjectile, 10);
            DestroyObject(ShootingEffect, 0.5f);
            DestroyObject(GameObject.Find("Charge_01.3 Fairydust(Clone)"));    
            clearInput();
            isLoaded = false;
            if (isShot)
            {
                disablePlayerMove();
            }
        }
        if (isShot)
        {
            timeSinceShot += Time.deltaTime;
            if (timeSinceShot >= 2.5f)
            {            
                DestroyObject playerDestroyObject = (DestroyObject)earth.GetComponent(typeof(DestroyObject));
                playerDestroyObject.clearCurrentInput();
                isShot = false;
                timeSinceShot = 0f;
            }
        }
    }

    public void load()
    {      
            if (isLoaded == false)
            {
                GameObject LoadEffect = Instantiate(loadEffect) as GameObject;
                LoadEffect.transform.parent = GameObject.Find("sphere").transform;
                isLoaded = true;
            }      
    }
    public void clearInput()
    {
        DestroyObject playerDestroyObject = (DestroyObject)earth.GetComponent(typeof(DestroyObject));
        playerDestroyObject.clearInput();
    }

    public void disablePlayerMove()
    {
        dontRotate.enabled = true;
        playerRotation.enabled = false;
    }

    public void enablePlayerMove()
    {
        dontRotate.enabled = false;
        playerRotation.enabled = true;
    }
}
