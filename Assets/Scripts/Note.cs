using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Track m_parentTrack;

    private Vector3 m_direction;

    private AudioSource m_audioSource;
    private BoxCollider m_collider;
    private Renderer m_renderer;

    //A renseigner depuis l'éditeur
    //Le nombre de beats que met la note pour traverser la track
    [SerializeField] private float m_beatsToReachEnd;
    private float m_finalSpeed;

    public Track ParentTrack { get => m_parentTrack; set => m_parentTrack = value; }

    void Start()
    {
        m_collider = GetComponent<BoxCollider>();
        m_renderer = GetComponent<Renderer>();

        //Ici on récupére la direction vers laquelle la note va se déplacer
        m_direction = transform.parent.transform.forward;
        var distance = Vector3.Distance(Vector3.Scale(transform.position, new Vector3(0, 1, 1)),
            Vector3.Scale(FinishLine.Instance.transform.position, new Vector3(0, 1, 1)));
        m_finalSpeed = (distance / ((60.0f / BeatGenerator.Instance.Bpm))) / m_beatsToReachEnd;
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //La note se déplace dans la direction indiquée avec la vitesse renseignée
        transform.position += m_direction * Time.deltaTime * m_finalSpeed;
    }

    //C'est dans cette zone que le joueur peut appuyer pour valider la note
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Note entered finish line");
    }

    //La joueur n'a pas appuyé sur la note à temps, elle disparaît 
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Note left finish line");
        Destroy(gameObject);

    }

    public void Validate()
    {
        m_audioSource.Play();
        m_collider.enabled = false;
        m_renderer.enabled = false;

        var childrenRenderer = GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in childrenRenderer)
        {
            renderer.enabled = false;
        }

        var childrenCollider = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider collider in childrenCollider)
        {
            collider.enabled = false;
        }
        Destroy(gameObject, m_audioSource.clip.length);
    }
}
