using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe permet de gérer l'activation et la désactivation des tracks en fonction des
//performances du joueur


public class TrackManager : MonoBehaviour
{

    //Le GameObject parent qui contient toutes les tracks
    [SerializeField] private GameObject tracksContainer;

    //Le GameObject parent qui contient toutes les tracks
    [SerializeField] private float m_globalThreshold;
     private float m_currentValue = 5.0f;
    public float CurrentValue
    {
        get => m_currentValue;
        set
        {
            //Debug.Log("m_currentValue " + m_currentValue);
            m_currentValue = Mathf.Max(0,value);
            if(m_currentValue >= m_globalThreshold)
            {
                m_currentValue = 5.0f;
                ActivateNextTrack();

            } 
        }
    }


    //La liste des tracks
    private List<Track> tracksStatus;

    //Le nombre max de tracks 
    private int m_maxIndex;

    /* SINGLETON */
    public static TrackManager Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /* END OF SINGLETON */

    void Start()
    {
        tracksContainer = FindObjectOfType<TracksContainer>().gameObject;
        tracksStatus = new List<Track>(tracksContainer.GetComponentsInChildren<Track>());
        CurrentValue = 5.0f;
        m_maxIndex = tracksStatus.Count;


    }

    //On a loupé une note, alors on perd un point dans la jauge correspondante à cette track
    public void Miss(Track track)
    {
        TrackPressed(track, false);
    }

    public void TrackPressed(Track track, bool res)
    {
        TrackData data = track.m_data;
        if (track.IsActivated )
        {

            if (res)   //On a réussie une note, alors on gagne un point dans la jauge correspondante à cette track
            {
                data.Increase();
                CurrentValue++;

                /*
                if (data.WentAboveThreshold )
                {
                    ActivateNextTrack();
                }*/

            }
            else  //On a loupé une note, alors on perd un point dans la jauge correspondante à cette track
            {
                //Debug.Log("Track " + tracksStatus.IndexOf(track) + " missed");
                CurrentValue--;
                data.Decrease();
                if ((data.CurrentValue == data.min))
                {
                    DeactivateCurrentTrack(track);
                }
            }

        }

    }

    //On active la prochaine track et on décale l'index
    private void ActivateNextTrack()
    {
        for(int i = 0; i <tracksStatus.Count; i++)
        {
            Track track = tracksStatus[i];
            if (!track.IsActivated)
            {
                track.Activate();
                break;
            }
        }
    }

    //On désactive la track la plus avancée et on décale l'index
    private void DeactivateCurrentTrack(Track track)
    {
        int index = tracksStatus.IndexOf(track);
        if (index != 0)
        {
            Debug.Log("Désactive " + index);
            tracksStatus[index].Deactivate();
        }
    }
}
