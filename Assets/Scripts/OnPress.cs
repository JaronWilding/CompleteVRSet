using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPress : MonoBehaviour
{
    UnityEvent fire = new UnityEvent();
    void Start()
    {

        fire.AddListener(Action);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && fire != null)
        {
            //Begin the action
            fire.Invoke();
        }
    }

    public void Action()
    {
        Debug.Log("HA");
    }
}
