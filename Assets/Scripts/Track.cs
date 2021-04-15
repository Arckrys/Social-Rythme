using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    [SerializeField] private bool m_isActivatedByDefault = false;

    [SerializeField] private GameObject m_buttonPrefab;
    private Vector3 m_prefabOffset;

    private Activable m_activableScript;
    private bool IsActivated()
    {
        return m_activableScript.IsActivated;
    }

    private MeshRenderer m_renderer;


    // Start is called before the first frame update
    private void Awake()
    {
        m_activableScript = GetComponent<Activable>();
        TryGetComponent(out m_renderer);

    }

    void Start()
    {
        m_activableScript.IsActivated = m_isActivatedByDefault;

        m_prefabOffset = m_renderer.bounds.max;
        m_prefabOffset.x = (m_renderer.bounds.min.x / 2) + (m_renderer.bounds.max.x / 2);
        m_prefabOffset.y += m_buttonPrefab.GetComponent<MeshRenderer>().bounds.max.y;

        GenerateNote();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateNote()
    {
        if (IsActivated())
        {
            var note = Instantiate(m_buttonPrefab, m_prefabOffset, gameObject.transform.rotation);
            note.transform.SetParent(transform);
        }

    }
}
