using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour {

	// Use this for initialization
    void Start () {
        ToggleLock ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            ToggleLock ();
        }
	}

    private void ToggleLock() {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.lockState == CursorLockMode.None
            ? Cursor.lockState = CursorLockMode.Locked
            : Cursor.lockState = CursorLockMode.None;
    }
}
