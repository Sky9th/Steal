using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == Tags.player)
        {
            GameController._instance.alertOn = true;
        }
    }

}
