using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackData 
{
    public float threshold;
    public float max;
    public float min;
    private float currentValue = 0.0f;
    public bool WentUnderThreshold = false;
    public bool WentAboveThreshold = false;

    public void Clear()
    {
        currentValue = 0.0f;
    }

    public void Decrease()
    {
        var oldValue = currentValue;
        currentValue = Mathf.Max(min, currentValue - 1);
        WentUnderThreshold = (oldValue >= threshold && currentValue < threshold);
    }

    public void Increase()
    {
        var oldValue = currentValue;
        currentValue = Mathf.Min(currentValue + 1, max);
        WentAboveThreshold = (oldValue < threshold && currentValue >= threshold);
    }
}
