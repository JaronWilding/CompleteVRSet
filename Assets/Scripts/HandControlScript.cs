using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControlScript : MonoBehaviour
{
    [SerializeField] private Transform leftHand = null;
    [SerializeField] private Transform rightHand = null;

    [SerializeField] private float leftGrip_Input;
    [SerializeField] private float rightGrip_Input;
    [SerializeField] private bool left_CanGrab;
    [SerializeField] private bool right_CanGrab;


    internal enum Hands{ left, right }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftGrip_Input = Input.GetAxis("LTrigger");
        rightGrip_Input = Input.GetAxis("RTrigger");

        left_CanGrab = leftGrip_Input <= -0.1f ? true : false;
        right_CanGrab = rightGrip_Input <= -0.1f ? true : false;
        
    }
}
