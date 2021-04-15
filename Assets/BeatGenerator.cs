using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatGenerator : MonoBehaviour
{

    [SerializeField] float Bpm;

    public event EventHandler OnBeat;
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

    // Start is called before the first frame update
    void Start()
    {
        m_nextBeat = Time.time + (60.0f / Bpm);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= m_nextBeat)
        {
            OnBeat?.Invoke(this, EventArgs.Empty);
            m_nextBeat = Time.time + (60.0f / Bpm);
        }
    }
}
