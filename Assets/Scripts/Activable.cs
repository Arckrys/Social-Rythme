using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{

    private bool m_isActivated = false;

    private Color32 m_initialColor;
    [SerializeField] private Color32 m_deactivatedFilter;
    private Color32 m_deactivatedColor;


    [SerializeField] private float m_delay;

    private MeshRenderer m_renderer;


    public bool IsActivated { get => m_isActivated;
        set {
            m_isActivated = value;
            Activate(value);
        }
    }

    private Coroutine currentCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<MeshRenderer>(out m_renderer)){
            m_initialColor = m_renderer.material.color;
            m_deactivatedColor = Color32.Lerp(m_initialColor, m_deactivatedFilter, 0.8f);
            IsActivated = false;
        } else
        {
            this.enabled = false;
        }
    }

    private void Activate(bool activate = true)
    {
        Color32 targetColor = activate ? m_initialColor : m_deactivatedColor;
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(ChangeColor(targetColor));
    }

    private IEnumerator ChangeColor(Color32 targetColor)
    {
        Color32 initalColor = m_renderer.material.color;
        float elapsedTime = 0.0f;
        float endTime = Time.time + m_delay;
        while(Time.time <= endTime)
        {
            m_renderer.material.color = Color32.Lerp(initalColor, targetColor, elapsedTime / m_delay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        m_renderer.material.color = targetColor;
        yield return null;
    }


}
