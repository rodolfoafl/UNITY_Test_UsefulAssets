using Dummiesman;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCamera : MonoBehaviour
{
    private GameObject _target; 

    void Update()
    {
        /*if (_target != null)
        {
            transform.LookAt(_target.transform);
        }*/
    }

    public void SetTarget(GameObject target)
    {
        _target = target;


        StartCoroutine(Delay());

        #region If
        /*
        if (_target.GetComponent<MeshFilter>() == null)
        {
            Debug.Log("Target does not contain MeshFilter component!");
            if (_target.GetComponentInChildren<MeshFilter>() == null)
            {
                Debug.Log("Target child does not contain MeshFilter component!");
            }
            else
            {
                var height = _target.GetComponent<MeshFilter>().mesh.bounds.extents.y;
                transform.position = new Vector3(transform.position.x, height, transform.position.z);
            }
        }
        else
        {
            var height = _target.GetComponent<MeshFilter>().mesh.bounds.extents.y;
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
        */
        #endregion
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);

        if(GetTargetMeshRenderer() != Vector3.zero)
        {
            transform.position = GetTargetMeshRenderer();
        }
    }

    private Vector3 GetTargetMeshRenderer()
    {
        if (_target.GetComponent<MeshRenderer>() == null)
        {
            Debug.Log("Target does not contain MeshRenderer component!");
            if (_target.GetComponentInChildren<MeshRenderer>() == null)
            {
                Debug.Log("Target child does not contain MeshRenderer component!");
            }
            else
            {
                var height = _target.GetComponentInChildren<MeshRenderer>().bounds.extents.y;
                return new Vector3(transform.position.x, height, transform.position.z);
            }
        }
        else
        {
            var height = _target.GetComponent<MeshRenderer>().bounds.extents.y;
            return new Vector3(transform.position.x, height, transform.position.z);
        }
        return Vector3.zero;
    }
}
