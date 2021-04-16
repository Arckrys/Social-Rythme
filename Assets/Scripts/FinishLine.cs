using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    /* Je pars du principe qu'il n'y aura jamais deux notes d'une m�me track en m�me temps sur la finish line
     * Cependant sur des BPM tr�s �lev�s on risque d'avoir le cas 
     * Soit on reste sur des BPM pas SI �lev�s que �a
     * Soit on peut r�duire la taille de la barre
     * Une solution plus g�n�rique prendrait plus de temps � r�aliser
     */


    //Le GameObject parent qui contient toutes les tracks
    [SerializeField] private GameObject tracksContainer;

    //Pour chaque track, stocke la note qui est en ce moment sur la finish line
    //Si il n'y a pas de note, la valeur est mise � null
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
