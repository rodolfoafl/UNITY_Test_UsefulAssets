using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectWithMouse : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 150f;

    void OnMouseDrag()
    {
        Debug.Log("Dragging!");

        float rotX = Input.GetAxis("Mouse X") * _rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * _rotationSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, rotY);
    }
}
