using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerer : MonoBehaviour
{
    public Light thisLight;
    public float flickerInterval = 1.0f;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > flickerInterval)
        {
            thisLight.enabled = !thisLight.enabled;
            flickerInterval = Random.Range(0f, 0.5f);
            timer -= flickerInterval;
        }
    }
}
