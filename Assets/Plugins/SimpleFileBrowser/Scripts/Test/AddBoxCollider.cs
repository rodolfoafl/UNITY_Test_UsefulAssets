using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoxCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider collider = transform.gameObject.AddComponent<BoxCollider>();
        StartCoroutine(SetColliderSettings(collider));
    }


    IEnumerator SetColliderSettings(BoxCollider collider)
    {
        var renderer = transform.gameObject.GetComponentInChildren<MeshRenderer>();

        yield return new WaitForSeconds(0.5f);
        collider.center = new Vector3(0f, renderer.bounds.extents.y, 0f);
        collider.size = new Vector3(renderer.bounds.extents.x, renderer.bounds.extents.y, renderer.bounds.extents.z);
    }
}
