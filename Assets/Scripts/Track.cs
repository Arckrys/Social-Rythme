using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    [SerializeField] private GameObject m_buttonPrefab; // TODO ici on met le prefab des notes qui glissent le long du track

    private Activable m_activableScript;

    private bool IsActivated()
    {
        return m_activableScript.IsActivated;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_activableScript = GetComponent<Activable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
