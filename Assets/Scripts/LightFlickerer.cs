using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerer : MonoBehaviour
{
    private Light thisLight;
    public float flickerInterval = 10f;
    private float timer;
    public bool isOn = false;

    void Start()
    {
        thisLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (isOn)
        {
            timer += Time.deltaTime;

            if (timer > flickerInterval)
            {
                thisLight.enabled = !thisLight.enabled;
                flickerInterval = Random.Range(0f, flickerInterval);
                timer -= flickerInterval;
            }
        }
    }
}
