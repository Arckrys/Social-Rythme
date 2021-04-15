using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private Vector3 m_direction;

    //A renseigner depuis l'�diteur
    [SerializeField] private float m_speed;

    void Start()
    {
        //Ici on r�cup�re la direction vers laquelle la note va se d�placer
        m_direction = transform.parent.transform.forward;
    }

    void Update()
    {
        //La note se d�place dans la direction indiqu�e avec la vitesse renseign�e
        transform.position += m_direction * Time.deltaTime * m_speed;
    }

    //C'est dans cette zone que le joueur peut appuyer pour valider la note
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Note entered finish line");
    }

    //La joueur n'a pas appuy� sur la note � temps, elle dispara�t 
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Note left finish line");
        Destroy(gameObject);

    }
}
