using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class characterControl : MonoBehaviour {
    public float movementSpeed, mouseSpeed, rotationUppNer, lasvinkel, acceleration, hopphastighet;

    CharacterController cc;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        cc = GetComponent<CharacterController>();
		    

	}


	// Update is called once per frame
	void Update () {
        CharacterController cc = GetComponent<CharacterController>();
        
        //Rotation höger vänster
        float rotationHogerVanster = Input.GetAxis("Mouse X") * mouseSpeed;
        transform.Rotate(0, rotationHogerVanster, 0);

        //Rotation kamera Upp & Ner
        float rotationUppNer=Input.GetAxis("Mouse Y") * mouseSpeed;
        rotationUppNer=Mathf.Clamp(rotationUppNer,-lasvinkel,lasvinkel);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationUppNer, 0, 0); //- (pga unity omvänd kontroll-> Upp=(-) & Ner=(+)

        //Vertikal & horisontal förflyttning
        float speedForward = Input.GetAxis("Vertical") * movementSpeed;
        float speedSideStep = Input.GetAxis("Horizontal") * movementSpeed;

        acceleration += Physics.gravity.y * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            acceleration = hopphastighet;
        }

        Vector3 speed = new Vector3(speedSideStep, acceleration, speedForward);

        //Rotation adderad till speed
        speed = transform.rotation * speed;

        //Sätter Character kontroll
        cc.Move(speed * Time.deltaTime);
	}
}
