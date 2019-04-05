using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoxCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider collider = transform.gameObject.AddComponent<BoxCollider>();
        StartCoroutine(SetColliderSettings());
    }


    IEnumerator SetColliderSettings()
    {
        /*
         * var renderer = transform.gameObject.GetComponentInChildren<MeshRenderer>();

        yield return new WaitForSeconds(0.5f);
        collider.center = new Vector3(0f, renderer.bounds.extents.y, 0f);
        collider.size = new Vector3(renderer.bounds.extents.x * 2, renderer.bounds.extents.y * 2, renderer.bounds.extents.z * 2);
        */
        yield return new WaitForSeconds(0.5f);

        BoxCollider collider = transform.gameObject.GetComponent<BoxCollider>();

        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>();
        }

        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        Renderer thisRenderer = transform.GetComponent<Renderer>();
        if (thisRenderer != null)
        {
            bounds.Encapsulate(thisRenderer.bounds);
            collider.center = bounds.center - transform.position;
            collider.size = bounds.size;
        }



        Transform[] allDescendants = gameObject.GetComponentsInChildren<Transform>();
        if (allDescendants.Length > 0)
        {

            foreach (Transform desc in allDescendants)
            {
                Renderer childRenderer = desc.GetComponent<Renderer>();
                if (childRenderer != null)
                {
                    bounds.Encapsulate(childRenderer.bounds);
                    collider.center = bounds.center - transform.position;
                    collider.size = bounds.size;
                }
            }
        }
    }
}
