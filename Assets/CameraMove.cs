using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private GameObject player;
    private Vector3 targetPos = Vector3.zero;
    private Vector3 offset;
    float dis;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        Vector3 playerTrans = player.transform.position;
        offset = playerTrans - this.transform.position;
        dis = Vector3.Distance(this.transform.position, player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTrans = player.transform.position;

        Vector3 beginPos = player.transform.position - offset;
        Vector3 endPos = player.transform.position + offset.magnitude * Vector3.up;

        Vector3[] arrayList = new Vector3[5];
        arrayList[0] = beginPos;
        arrayList[1] = Vector3.Lerp(beginPos, endPos, 0.25f);
        arrayList[2] = Vector3.Lerp(beginPos, endPos, 0.5f);
        arrayList[3] = Vector3.Lerp(beginPos, endPos, 0.75f);
        arrayList[4] = endPos;

        for (int i = 0; i < 5; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(arrayList[i], player.transform.position - arrayList[i]);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag != Tags.player)
                {
                    continue;
                }
                else
                {
                    targetPos = arrayList[i];
                    break;
                }
            }
            else
            {
                targetPos = arrayList[i];
                break;
            }
        }
        //this.transform.position = targetPos;
        this.transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);
        Quaternion newRoatation = transform.rotation;
        this.transform.LookAt(player.transform.position);
        Quaternion.Lerp(newRoatation, transform.rotation, Time.deltaTime * 10);
    }
}
