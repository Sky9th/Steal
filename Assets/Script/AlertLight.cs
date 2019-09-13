using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLight : MonoBehaviour
{
    public static AlertLight self;

    public bool alertOn = false;

    public float rate = 15;
    public GameObject alertLight;

    private readonly float maxIntensity = 0.5f;
    private readonly float minIntensity = 0;

    private float targetIntensity;

    // Start is called before the first frame update
    void Awake()
    {
        targetIntensity = maxIntensity;
        alertOn = false;
        self = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Add the light component
        Light lightComp = alertLight.GetComponent<Light>();
        lightComp.intensity = Mathf.Lerp(lightComp.intensity, targetIntensity, rate * Time.deltaTime);
        if (Mathf.Abs(lightComp.intensity - targetIntensity) < 0.05f)
        {
            if (alertOn)
            {
                targetIntensity = targetIntensity == maxIntensity ? minIntensity : maxIntensity;
            }
            else
            {
                targetIntensity = 0;
            }
        }
    }
}
