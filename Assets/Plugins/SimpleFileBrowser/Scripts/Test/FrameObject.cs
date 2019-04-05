using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameObject : MonoBehaviour
{
    Bounds CalculateBounds(GameObject go) {
        Bounds b = new Bounds(go.transform.position, Vector3.zero);
        Object[] rList = go.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer r in rList) {
            b.Encapsulate(r.bounds);
        }
        return b;
    }

    /*
    void FocusCameraOnGameObject(Camera c, GameObject go) {
        Bounds b = CalculateBounds(go);
        Vector3 max = b.size;
        float radius = Mathf.Max(max.x, Mathf.Max(max.y, max.z));
        float dist = radius /  (Mathf.Sin(c.fieldOfView * Mathf.Deg2Rad / 2f));
        Debug.Log("Radius = " + radius + " dist = " + dist);
        Vector3 pos = Random.onUnitSphere * dist + b.center;
        c.transform.position = pos;
        c.transform.LookAt(b.center);
    }
    */

    public void FocusCameraOnGameObject(Camera c, GameObject go) {
        Bounds b = CalculateBounds(go);
        Vector3 max = b.size;
        float radius = max.magnitude / 2f;
        float horizontalFOV = 2f * Mathf.Atan(Mathf.Tan(c.fieldOfView * Mathf.Deg2Rad / 2f) * c.aspect) * Mathf.Rad2Deg;   
        float fov = Mathf.Min(c.fieldOfView, horizontalFOV);
        float dist = radius /  (Mathf.Sin(fov * Mathf.Deg2Rad / 2f));
        Debug.Log("Radius = " + radius + " dist = " + dist);
        c.transform.localPosition = new Vector3(c.transform.position.x, c.transform.position.y, dist);
        if (c.orthographic)
            c.orthographicSize = radius;

        c.transform.LookAt(b.center);
    }

    public void CallCoroutine(Camera c, GameObject go){
        StartCoroutine(CoroutineFocusCameraOnGameObject(c, go));
    }

    IEnumerator CoroutineFocusCameraOnGameObject(Camera c, GameObject go) {
        yield return new WaitForSeconds(0.5f);

        Bounds b = CalculateBounds(go);
        Vector3 max = b.size;
        float radius = max.magnitude / 2f;
        float horizontalFOV = 2f * Mathf.Atan(Mathf.Tan(c.fieldOfView * Mathf.Deg2Rad / 2f) * c.aspect) * Mathf.Rad2Deg;   
        float fov = Mathf.Min(c.fieldOfView, horizontalFOV);
        float dist = radius /  (Mathf.Sin(fov * Mathf.Deg2Rad / 2f));
        Debug.Log("Radius = " + radius + " dist = " + dist);
        c.transform.localPosition = new Vector3(c.transform.position.x, c.transform.position.y, dist);
        if (c.orthographic)
            c.orthographicSize = radius;

        c.transform.LookAt(b.center);
    }

    void Update () {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
            Camera c = Camera.main;
            Vector3 mp = Input.mousePosition;
            Ray ray = c.ScreenPointToRay(mp);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                FocusCameraOnGameObject(Camera.main, hit.transform.gameObject);
            }
        }
    }
}
