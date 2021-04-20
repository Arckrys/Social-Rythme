using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Track m_parentTrack;

    private Vector3 m_direction;

    //A renseigner depuis l'�diteur
    //Le nombre de beats que met la note pour traverser la track
    [SerializeField] private float m_beatsToReachEnd;
    private float m_finalSpeed;

    public Track ParentTrack { get => m_parentTrack; set => m_parentTrack = value; }

    void Start()
    {
        //Ici on r�cup�re la direction vers laquelle la note va se d�placer
        m_direction = transform.parent.transform.forward;
        var distance = Vector3.Distance(Vector3.Scale(transform.position, new Vector3(0, 1, 1)),
            Vector3.Scale(FinishLine.Instance.transform.position, new Vector3(0, 1, 1)));
        m_finalSpeed = (distance / ((60.0f / BeatGenerator.Instance.Bpm))) / m_beatsToReachEnd;
    }

    void Update()
    {
        //La note se d�place dans la direction indiqu�e avec la vitesse renseign�e
        transform.position += m_direction * Time.deltaTime * m_finalSpeed;
    }

    //C'est dans cette zone que le joueur peut appuyer pour valider la note
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Note entered finish line");
    }

    //La joueur n'a pas appuy� sur la note � temps, elle dispara�t 
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Note left finish line");
        Destroy(gameObject);

    }
}
