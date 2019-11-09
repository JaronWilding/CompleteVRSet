using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControlTriggers : MonoBehaviour
{
    public enum Hands { left, right }
    [SerializeField] public Hands hand = Hands.left;

    [SerializeField] private Transform leftHolster;
    [SerializeField] private Transform rightHolster;

    [SerializeField] private bool leftEnter;
    [SerializeField] private bool leftCarrying;
    [SerializeField] private GameObject leftObj;
    [SerializeField] private string leftObjTag;

    [SerializeField] private bool rightEnter;
    [SerializeField] private bool rightCarrying;
    [SerializeField] private GameObject rightObj;
    [SerializeField] private string rightObjTag;

    [SerializeField] private float leftGrip_Input;
    [SerializeField] private float rightGrip_Input;
    [SerializeField] private bool left_CanGrab;
    [SerializeField] private bool right_CanGrab;



    private bool left_Grabbing;
    private bool left_Throwing;
    private bool right_Grabbing;
    private bool right_Throwing;

    void Update()
    {

        if (hand == Hands.left)
        {
            leftGrip_Input = Input.GetAxis("LTrigger");
            left_CanGrab = leftGrip_Input <= -0.1f ? true : false; ;
            CheckHands(ref left_CanGrab, ref leftEnter, ref leftObj, ref leftObjTag, ref leftCarrying, ref leftHolster);
        }
        else if(hand == Hands.right)
        {
            rightGrip_Input = Input.GetAxis("RTrigger");
            right_CanGrab = rightGrip_Input <= -0.1f ? true : false; ;
            CheckHands(ref right_CanGrab, ref rightEnter, ref rightObj, ref rightObjTag, ref rightCarrying, ref rightHolster);
        }

        
    }

    private void CheckHands(ref bool _canGrab, ref bool _enter, ref GameObject _obj, ref string _tag, ref bool _carrying, ref Transform _holster)
    {
        if (_canGrab == true && _enter == true && _obj != null)
        {
            if (_tag == "Free Grab")
            {
                
            }
            else if (_tag == "Snap Toggle")
            {
                SnapToggle(_obj, ref _carrying, transform.parent, _holster);
            }
        }
    }


    private void Grab(GameObject _obj, Transform _hand)
    {
        _obj.GetComponent<Rigidbody>().isKinematic = true;
        _obj.transform.position = _hand.position;
        _obj.transform.rotation = _hand.rotation;
        _obj.transform.SetParent(_hand);
    }


    private void SnapToggle(GameObject _obj, ref bool _carrying, Transform _hand, Transform _holster)
    {
        if (_carrying == false)
        {
            _carrying = true;
            _obj.GetComponent<Rigidbody>().isKinematic = true;
            _obj.transform.position = _hand.position;
            _obj.transform.rotation = _hand.rotation;
            _obj.transform.SetParent(_hand);
        }
        else
        {
            _carrying = false;
            _obj.transform.position = _holster.position;
            _obj.transform.rotation = _holster.rotation;
            _obj.transform.SetParent(_holster);
        }
    }
    

    private void OnTriggerEnter(Collider col)
    {
        if(col != null)
        {
            SetVariables(col);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        RevertVariables(col);
    }

    private void SetVariables(Collider col)
    {
        if (hand == Hands.left)
        {
            leftEnter = true;
            leftObj = col.gameObject;
            leftObjTag = col.tag;
        }
        else
        {
            rightEnter = true;
            rightObj = col.gameObject;
            rightObjTag = col.tag;
        }
    }

    private void RevertVariables(Collider col)
    {
        if (hand == Hands.left)
        {
            leftEnter = false;
            leftObj = null;
            leftObjTag = null;
        }
        else
        {
            rightEnter = false;
            rightObj = null;
            rightObjTag = null;
        }
    }

    
}
