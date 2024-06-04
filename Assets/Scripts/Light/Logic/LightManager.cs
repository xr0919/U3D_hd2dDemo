using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light dLight;

    private void OnEnable()
    {
        EventHandler.GameDateEvent += OnGameDateEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameDateEvent -= OnGameDateEvent;
    }

    private void OnGameDateEvent(int hour, int day, int month, int year)
    {
        UpdateLight(hour);
    }

    private void UpdateLight(int hour) {
        if (hour >= 0 && hour <= 5)
        {
            dLight.intensity = 2.0f;
        }
        else if (hour >= 6 && hour <= 12)
        {
            dLight.intensity = 3.0f;
        }
        else if (hour >= 13 && hour <= 18)
        {
            dLight.intensity = 1.0f;
        }
        else
        {
            dLight.intensity = 0.5f;
        }
    }
}
