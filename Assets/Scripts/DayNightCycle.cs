using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration, timeSpeed;
    public Light2D globalLight;
    float dayCounter;
    private void Start()
    {
        dayCounter = dayDuration * 3f / 10f;
    }
    private void FixedUpdate()
    {
        dayCounter += Time.deltaTime * timeSpeed;
        float timeAtDay = dayCounter / dayDuration;
        if (timeAtDay >= 1f)
        {
            dayCounter = 0;
        };
        if (timeAtDay >= 0.7f)
        {
            globalLight.intensity = 0.4f;
            globalLight.color = new Color32(160, 251, 255, 255);
            return;
        }
        globalLight.intensity = 1;
        globalLight.color = new Color32(255, 251, 160, 255);
    }
}
