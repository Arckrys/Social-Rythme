using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    // Est-ce que ce Track est activé au début du jeu ?
    [SerializeField] private bool m_isActivatedByDefault = false;

    //Le prefab de la note qui sera placée sur le Track
    [SerializeField] private GameObject m_buttonPrefab;
    //L'offset de la note pour mieux la placer sur le Track
    private Vector3 m_prefabOffset;

    private Activable m_activableScript;
    private bool IsActivated()
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

        //On calcule la position de départ des notes en fonction du renderer de la Track
        m_prefabOffset = m_renderer.bounds.max;
        m_prefabOffset.x = (m_renderer.bounds.min.x / 2) + (m_renderer.bounds.max.x / 2);
        m_prefabOffset.y += m_buttonPrefab.GetComponent<MeshRenderer>().bounds.max.y;

        //Quand OnBeat (voir BeatGenerator) est activé, la fonction GeneraNote est lancée
        BeatGenerator.Instance.OnBeat += GenerateNote;

    }

    //On instancie une note sur la track
    private void GenerateNote(object sender, System.EventArgs e)
    {
        if (IsActivated())
        {
            var note = Instantiate(m_buttonPrefab, m_prefabOffset, gameObject.transform.rotation);
            note.transform.SetParent(transform);
        }

    }
}
