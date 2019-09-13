using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{

    public AudioClip pickupMusic;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player)
        {
            Player player = other.GetComponent<Player>();
            player.getKey = true;
            Debug.Log(player);
            AudioSource.PlayClipAtPoint(pickupMusic, this.transform.position);
            Destroy(this.gameObject);
        }
    }

}
