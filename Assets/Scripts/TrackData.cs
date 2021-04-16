using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Ici on a une jauge qui se remplit quand on fait une bonne note et qui se vide quand on loupe une note
// Si la jauge est assez remplie, alors TrackManager activera la prochaine track
// Si on loupe trop de notes, alors TrackManager désactive cette track



[System.Serializable]
public class TrackData 
{
    public float threshold;
    public float max;
    public float min;
    public float currentValue = 0.0f;
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
