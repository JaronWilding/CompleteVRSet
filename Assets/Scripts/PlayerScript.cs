using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float xInput;
    public float zInput;
    public bool inputMovement;
    public float moveSpeed = 2.0f;

    public CharacterController charCon;

    private void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    private void Update()
    {
        xInput = Input.GetAxis("LHorizontal");
        zInput = Input.GetAxis("LVertical");

        inputMovement = xInput <= -0.2f || xInput >= 0.2f || zInput <= -0.2f || zInput >= 0.2f ? true : false;

        if (Input.GetButton("LThumbPress")) { moveSpeed = 4f; } else { moveSpeed = 2f; }

        charCon.Move(new Vector3(xInput * Time.deltaTime * moveSpeed, 0f, zInput * Time.deltaTime * moveSpeed));
    }

}
