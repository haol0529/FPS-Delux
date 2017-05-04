using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public GameObject grenade_prefab;
    public float grenadeimpulse;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Camera cam = Camera.main;
            GameObject thegrenade = (GameObject)Instantiate(grenade_prefab, cam.transform.position, cam.transform.rotation);
            thegrenade.GetComponent<Rigidbody>().AddForce(cam.transform.forward * grenadeimpulse, ForceMode.Impulse);
        }
    }
}