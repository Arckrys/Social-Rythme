using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject tracksContainer;
    public Dictionary<Track, Note> tracksStatus;


    /* SINGLETON */
    public static FinishLine Instance;
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
        tracksStatus = new Dictionary<Track, Note>();
        var tracks = tracksContainer.GetComponentsInChildren<Track>();
        foreach(Track track in tracks)
        {
            tracksStatus[track] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Une note touche la ligne
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Note note))
        {
            Debug.Log("Note entered finish line");
            tracksStatus[note.ParentTrack] = note;
        }
    }

    //Une note quitte la ligne
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Note note))
        {
            Debug.Log("Note left finish line");
            tracksStatus[note.ParentTrack] = null;
        }
    }

    public bool PressTrack (Track track)
    {
        Note noteContained = tracksStatus[track];
        bool res = (noteContained != null);
        if (res) // CORRECT
        {
            Debug.Log("Correct !");
            Destroy(noteContained.gameObject);


        } else // MISS
        {
            Debug.Log("Miss !");

        }
        return res;
    }
}
