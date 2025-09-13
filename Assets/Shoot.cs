using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wand;

public void Fire(){
	// Create a bullet object.
       GameObject projectile = Instantiate(bullet,
wand.transform.position,
wand.transform.rotation);
		// Apply a velocity to the rigid body of the bullet in the direction
		// of your wand (i.e. your right hand controller)
       projectile.GetComponent<Rigidbody>().linearVelocity =
wand.transform.TransformDirection(Vector3.forward * 10);
    }
}
