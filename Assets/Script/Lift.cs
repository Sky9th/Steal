using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{

    public Transform outer_left;
    public Transform inner_left;
    public Transform outer_right;
    public Transform inner_right;

    private void Update()
    {
        inner_left.position = new Vector3(outer_left.position.x, inner_left.position.y, inner_left.position.z);
        inner_right.position = new Vector3(outer_right.position.x, inner_right.position.y, inner_right.position.z);
    }

}
