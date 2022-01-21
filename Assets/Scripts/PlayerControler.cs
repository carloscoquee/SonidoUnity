using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;

    public Transform cam;
    public float lookSensitivity;
    public float minXRot;
    public float maxXRot;
    private float curXRot;

    void Start()
    {
// hide and lock the cursor at the start of the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();

        if (Cursor.lockState == CursorLockMode.Locked)
            Look();
    }

    void Move()
    {
// get the movement inputs
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

// calculate the relative direction
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();

// include the move speed
        dir *= moveSpeed * Time.deltaTime;

// move the controller
        controller.Move(dir);
    }

    void Look()
    {
// get the X and Y mouse inputs
        float x = Input.GetAxis("Mouse X") * lookSensitivity;
        float y = Input.GetAxis("Mouse Y") * lookSensitivity;

// rotate the player horizontally
        transform.eulerAngles += Vector3.up * x;

        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);
    }
}