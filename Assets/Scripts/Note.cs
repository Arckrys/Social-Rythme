using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private Vector3 m_direction;

    //A renseigner depuis l'éditeur
    [SerializeField] private float m_speed;

    void Start()
    {
        //Ici on récupére la direction vers laquelle la note va se déplacer
        m_direction = transform.parent.transform.forward;
    }

    void Update()
    {
        //La note se déplace dans la direction indiquée avec la vitesse renseignée
        transform.position += m_direction * Time.deltaTime * m_speed;
    }

    //C'est dans cette zone que le joueur peut appuyer pour valider la note
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Note entered finish line");
    }

    //La joueur n'a pas appuyé sur la note à temps, elle disparaît 
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Note left finish line");
        Destroy(gameObject);

    }
}
