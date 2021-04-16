using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    // Est-ce que ce Track est activ� au d�but du jeu ?
    [SerializeField] private bool m_isActivatedByDefault = false;

    //Une note sera g�n�r�e toute les m_frequency Beats
    [SerializeField] private float m_frequency;

    [SerializeField] public TrackData m_data;


    private uint m_currentNumberOfBeats = 0;


    //Le prefab de la note qui sera plac�e sur le Track
    [SerializeField] private GameObject m_buttonPrefab;
    //L'offset de la note pour mieux la placer sur le Track
    private Vector3 m_prefabOffset;

    private Activable m_activableScript;
    public bool IsActivated()
    {
        return m_activableScript.IsActivated;
    }

    private MeshRenderer m_renderer;


    private void Awake()
    {
        m_activableScript = GetComponent<Activable>();
        TryGetComponent(out m_renderer);

    }

    void Start()
    {
        m_activableScript.IsActivated = m_isActivatedByDefault;

        //On calcule la position de d�part des notes en fonction du renderer de la Track
        m_prefabOffset = m_renderer.bounds.max;
        m_prefabOffset.x = (m_renderer.bounds.min.x / 2) + (m_renderer.bounds.max.x / 2);
        m_prefabOffset.y += m_buttonPrefab.GetComponent<MeshRenderer>().bounds.max.y;

        //Quand OnBeat (voir BeatGenerator) est activ�, la fonction GeneraNote est lanc�e
        BeatGenerator.Instance.OnBeat += OnBeat;

    }

    private void OnBeat(object sender, System.EventArgs e)
    {
        if (IsActivated())
        {
            m_currentNumberOfBeats++;
            if(m_currentNumberOfBeats >= m_frequency)
            {
                m_currentNumberOfBeats = 0;
                GenerateNote();
            }
        }
    }

    //On instancie une note sur la track
    private void GenerateNote()
    {
        if (IsActivated())
        {
            var note = Instantiate(m_buttonPrefab, m_prefabOffset, gameObject.transform.rotation);
            note.transform.SetParent(transform);
            note.GetComponent<Note>().ParentTrack = this;
        }

    }

    public void Activate()
    {
        m_data.Clear();
        m_activableScript.IsActivated = true;
    }

    public void Deactivate()
    {
        m_activableScript.IsActivated = false;
        m_data.Clear();
    }
}
