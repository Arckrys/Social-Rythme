using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe permet de gérer l'activation et la désactivation des tracks en fonction des
//performances du joueur


public class TrackManager : MonoBehaviour
{

    //Le GameObject parent qui contient toutes les tracks
    [SerializeField] private GameObject tracksContainer;

    //La liste des tracks
    private List<Track> tracksStatus;

    //La track la plus avancée actuellement activée
    private int m_currentIndex;

    //Le nombre max de tracks 
    private int m_maxIndex;

    /* SINGLETON */
    public static TrackManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /* END OF SINGLETON */

    void Start()
    {
        tracksStatus = new List<Track>(tracksContainer.GetComponentsInChildren<Track>());
        m_currentIndex = 0;
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
        if (track.IsActivated() && (tracksStatus[m_currentIndex] == track))
        {
            if (res)   //On a réussie une note, alors on gagne un point dans la jauge correspondante à cette track
            {
                data.Increase();
                if (data.WentAboveThreshold || (data.currentValue == data.max))
                {
                    ActivateNextTrack();
                }

            }
            else  //On a loupé une note, alors on perd un point dans la jauge correspondante à cette track
            {
                Debug.Log("Track " + tracksStatus.IndexOf(track) + " missed");
                data.Decrease();
                if (data.WentUnderThreshold || (data.currentValue == data.min))
                {
                    DeactivateCurrentTrack();
                }
            }
            Debug.Log("Track " + tracksStatus.IndexOf(track) + " value is " + data.currentValue);

        }

    }

    //On active la prochaine track et on décale l'index
    private void ActivateNextTrack()
    {
        if (m_currentIndex < m_maxIndex)
        {
            m_currentIndex++;
            tracksStatus[m_currentIndex].Activate();
        }
    }

    //On désactive la track la plus avancée et on décale l'index
    private void DeactivateCurrentTrack()
    {
        if (m_currentIndex != 0)
        {
            tracksStatus[m_currentIndex].Deactivate();
            m_currentIndex--;
        }
    }
}
