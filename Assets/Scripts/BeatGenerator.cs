using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatGenerator : MonoBehaviour
{
    //Le BPM général de la musique utilisée
    [SerializeField] float Bpm;

    //Cet event est appelé à chaque Beat , donc toutes les 60/BPM secondes
    public event EventHandler OnBeat;

    //Le timeStamp correspondant au prochain appel de OnBeat
    private float m_nextBeat;

    /* SINGLETON */
    public static BeatGenerator Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //SceneManager.sceneLoaded += OnSceneLoaded;
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
        m_nextBeat = Time.time + (60.0f / Bpm);
    }

    void Update()
    {
        if(Time.time >= m_nextBeat)
        {
            OnBeat?.Invoke(this, EventArgs.Empty);
            m_nextBeat = Time.time + (60.0f / Bpm);
        }
    }
}
