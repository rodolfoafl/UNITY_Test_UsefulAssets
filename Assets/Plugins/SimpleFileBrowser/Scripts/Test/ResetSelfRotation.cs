using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSelfRotation : MonoBehaviour
{
    Quaternion _originalRotationValue;
    [SerializeField] float _rotationResetSpeed = 1f;

    void Start () {
        _originalRotationValue = transform.rotation;
    }

    public void ResetRotation(){
        Debug.Log("reseting rotation!");
        //transform.rotation = Quaternion.Slerp(transform.rotation, _originalRotationValue, Time.deltaTime * _rotationResetSpeed);
        transform.rotation = _originalRotationValue;
    }
}
