using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 20;
    public float rotationSpeed = 10;
    public float stopSpeed = 30;
    public bool getKey = false;

    private Animator anim;
    private AudioSource audi;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
        audi = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if( Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            float newSpeed = Mathf.Lerp(anim.GetFloat("speed"), 5.6f, moveSpeed * Time.deltaTime);
            anim.SetFloat("speed", newSpeed);

            Vector3 targetDir = new Vector3(h, 0, v);

            Quaternion newRotation = Quaternion.LookRotation(targetDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            float newSpeed = Mathf.Lerp(anim.GetFloat("speed"), 0, stopSpeed * Time.deltaTime);
            anim.SetFloat("speed", newSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("sneak", true);
        }
        else
        {
            anim.SetBool("sneak", false);
        }

        if ( anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion") )
        {
            if (!audi.isPlaying)
            {
                audi.Play();
            }
        }
        else
        {
            if (audi.isPlaying)
            {
                audi.Stop();
            }
        }
        
    }
}
