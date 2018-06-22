using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraLook : MonoBehaviour {

    public float cameraLock = 0.45f;
    public float lookSpeed = 300.0f;
    private Camera characterCamera;

	// Use this for initialization
    void Start () {
        characterCamera = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
        //Look stuff
        float mouseX = Input.GetAxis ("Mouse X");
        float mouseY = Input.GetAxis ("Mouse Y");

        gameObject.transform.Rotate (0, mouseX * lookSpeed * Time.deltaTime, 0);
        characterCamera.transform.Rotate (-mouseY * lookSpeed * Time.deltaTime, 0, 0);

        Quaternion cameraRot = characterCamera.transform.localRotation;
        cameraRot.x = Mathf.Clamp (cameraRot.x, -cameraLock, cameraLock);

        characterCamera.transform.localRotation = cameraRot;
	}
}
