using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette classe permet de g�rer l'activation et la d�sactivation des tracks en fonction des
//performances du joueur


public class TrackManager : MonoBehaviour
{

    //Le GameObject parent qui contient toutes les tracks
    [SerializeField] private GameObject tracksContainer;

    //La liste des tracks
    private List<Track> tracksStatus;

    //La track la plus avanc�e actuellement activ�e
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

    //On a loup� une note, alors on perd un point dans la jauge correspondante � cette track
    public void Miss(Track track)
    {
        TrackPressed(track, false);
    }

    public void TrackPressed(Track track, bool res)
    {
        TrackData data = track.m_data;
        if (track.IsActivated() && (tracksStatus[m_currentIndex] == track))
        {
            if (res)   //On a r�ussie une note, alors on gagne un point dans la jauge correspondante � cette track
            {
                data.Increase();
                if (data.WentAboveThreshold || (data.currentValue == data.max))
                {
                    ActivateNextTrack();
                }

            }
            else  //On a loup� une note, alors on perd un point dans la jauge correspondante � cette track
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

    //On active la prochaine track et on d�cale l'index
    private void ActivateNextTrack()
    {
        if (m_currentIndex < m_maxIndex)
        {
            m_currentIndex++;
            tracksStatus[m_currentIndex].Activate();
        }
    }

    //On d�sactive la track la plus avanc�e et on d�cale l'index
    private void DeactivateCurrentTrack()
    {
        if (m_currentIndex != 0)
        {
            tracksStatus[m_currentIndex].Deactivate();
            m_currentIndex--;
        }
    }
}
