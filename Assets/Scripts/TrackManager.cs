using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

    //Le GameObject parent qui contient toutes les tracks
    [SerializeField] private GameObject tracksContainer;

    private List<Track> tracksStatus;
    private int m_currentIndex;
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
    // Start is called before the first frame update
    void Start()
    {
        tracksStatus = new List<Track>(tracksContainer.GetComponentsInChildren<Track>());
        m_currentIndex = 0;
        m_maxIndex = tracksStatus.Count;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Miss(Track track)
    {
        TrackPressed(track, false);
    }

    public void TrackPressed(Track track, bool res)
    {
        TrackData data = track.m_data;
        if (track.IsActivated())
        {
            if (res)
            {
                data.Increase();
                if (data.WentAboveThreshold)
                {
                    ActivateNextTrack();
                }

            }
            else
            {
                data.Decrease();
                if (data.WentUnderThreshold)
                {
                    DeactivateCurrentTrack();
                }
            }
        }
        
    }

    private void ActivateNextTrack()
    {
        if (m_currentIndex < m_maxIndex)
        {
            m_currentIndex++;
            tracksStatus[m_currentIndex].Activate();
        }
    }

    private void DeactivateCurrentTrack()
    {
        if (m_currentIndex != 0)
        {
            tracksStatus[m_currentIndex].Deactivate();
            m_currentIndex--;
        }
    }
}
