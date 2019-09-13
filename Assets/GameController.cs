using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController _instance;

    public bool alertOn = false;
    public Light alert;
    public Vector3 lastPlayerPostion = Vector3.zero;
    public GameObject[] sirens;

    public AudioSource musicNormal;
    public AudioSource musicPanic;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        alertOn = false;
        sirens = GameObject.FindGameObjectsWithTag(Tags.siren);
    }

    // Update is called once per frame
    void Update()
    {
        AlertLight.self.alertOn = this.alertOn;
        if (this.alertOn)
        {
            musicNormal.volume = Mathf.Lerp(musicNormal.volume, 0, Time.deltaTime * 10);
            musicPanic.volume = Mathf.Lerp(musicPanic.volume, 0.5f, Time.deltaTime * 10);
            PlayAlert();
        }
        else
        {
            musicNormal.volume = Mathf.Lerp(musicNormal.volume, 0.5f, Time.deltaTime * 10);
            musicPanic.volume = Mathf.Lerp(musicPanic.volume, 0, Time.deltaTime * 10);
            StopAlert();
        }
    }

    private void PlayAlert()
    {
        foreach (GameObject go in sirens)
        {
            if (!go.GetComponent<AudioSource>().isPlaying)
            {
                go.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void StopAlert()
    {
        foreach (GameObject go in sirens)
        {
            if (go.GetComponent<AudioSource>().isPlaying)
            {
                go.GetComponent<AudioSource>().Pause();
            } 
        }
    }
}
