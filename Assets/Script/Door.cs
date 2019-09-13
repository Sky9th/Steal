using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool close = true;
    public Animator anim;
    public AudioSource audi;
    public int count = 0;
    public bool requireKey;
    public AudioSource denid;

    public void Awake()
    {
        anim = this.GetComponent<Animator>();
        audi = this.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (count > 0)
        {
            close = false;
        }
        else
        {
            close = true;
        }
        anim.SetBool("close", close);

        if (anim.IsInTransition(0))
        {
            if (!audi.isPlaying)
            {
                audi.Play();
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (requireKey)
        {
            if(other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                Debug.Log(player.getKey);
                if (player.getKey)
                {
                    count++;
                }
                else
                {
                    if (!denid.isPlaying)
                    {
                        denid.Play();
                    }
                }
            }
        }
        else
        {
            if (other.tag == Tags.player || other.tag == Tags.enemy)
            {
                count++;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (requireKey)
        {
            if (other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                if (player.getKey)
                {
                    count--;
                }
            }
        }
        else
        {
            if (other.tag == Tags.player || other.tag == Tags.enemy)
            {
                count--;
            }
        }
    }
}
