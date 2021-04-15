using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private Vector3 m_direction;

    [SerializeField] private float m_speed;
    // Start is called before the first frame update
    void Start()
    {
        m_direction = transform.parent.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_direction * Time.deltaTime * m_speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Note entered finish line");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Note left finish line");

    }
}
