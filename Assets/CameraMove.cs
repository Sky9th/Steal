using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        Vector3 playerTrans = player.transform.position;
        offset = playerTrans - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTrans = player.transform.position;
        this.transform.position = new Vector3(playerTrans.x, this.transform.position.y, playerTrans.z - offset.z);
    }
}
