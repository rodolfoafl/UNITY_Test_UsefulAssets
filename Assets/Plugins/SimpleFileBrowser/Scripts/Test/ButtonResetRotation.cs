using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResetRotation : MonoBehaviour
{
    public void ResetObjectRotation(){
        GameObject obj = GameObject.Find("Objeto");
        if(obj != null){
            obj.GetComponent<ResetSelfRotation>().ResetRotation();
        }
    }
}
