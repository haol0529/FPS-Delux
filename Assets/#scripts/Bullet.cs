using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject bullet_prefab;
    public float bulletimpulse;

	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            Camera cam = Camera.main;
            GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position,cam.transform.rotation);
            thebullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletimpulse, ForceMode.Impulse);
        }
		
	}
}
