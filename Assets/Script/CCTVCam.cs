using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVCam : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player)
        {
            Debug.Log("11111");
            GameController._instance.alertOn = true;
            GameController._instance.lastPlayerPostion = other.transform.position;
        }
    }

}
