using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{

    private bool m_isActivated = false;

    private Color32 m_initialColor;
    //Ce filtre est appliqu� � 80% sur la couleur initiale lors de la d�sactivation
    [SerializeField] private Color32 m_deactivatedFilter;
    //La couleur r�sultante de l'application du filtre sur la couleur initiale
    private Color32 m_deactivatedColor;

    //Le d�lai d'activation / d�sactivation : influence la vitesse de changement de couleur
    [SerializeField] private float m_delay;

    private MeshRenderer m_renderer;


    public bool IsActivated { get => m_isActivated;
        set {
            m_isActivated = value;
            Activate(value);
        }
    }

    //La couroutine de changement de couleur qui est actuellement en cours
    private Coroutine currentCoroutine;

    void Awake()
    {
        if (TryGetComponent(out m_renderer)){
            m_initialColor = m_renderer.material.color;
            //La couleur d�sactiv�e correspond � 0.2 x la couleur initiale + 0.8x le filtre de d�sactivation
            m_deactivatedColor = Color32.Lerp(m_initialColor, m_deactivatedFilter, 0.8f);
            IsActivated = false;
        } else
        {
            this.enabled = false;
        }
    }

    private void Activate(bool activate = true)
    {
        //On r�cup�re la couleur cible en fonction de si on active ou d�sactive
        Color32 targetColor = activate ? m_initialColor : m_deactivatedColor;
        //Si la couleur est d�j� en train d'�tre modifi�e, on interrompt cette coroutine
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        //On lance la nouvelle coroutine de changement de couleur
        currentCoroutine = StartCoroutine(ChangeColor(targetColor));
    }

    private IEnumerator ChangeColor(Color32 targetColor)
    {
        //On retient la couleur actuel du mat�riau au moment du changement de couleur
        //Note : cette couleur peut �tre diff�rente de m_initialColor ou m_deactivatedColor
        //si ChangeColor a �t� re-appel� avant d'avoir eu le temps de se terminer
        Color32 initalColor = m_renderer.material.color;
        float elapsedTime = 0.0f;
        //Le temps auquel le changement de couleur sera effectu�
        float endTime = Time.time + m_delay;
        while(Time.time <= endTime)
        {
            //Interpolation lin�aire entre la couleur de d�part et la couleur cible
            m_renderer.material.color = Color32.Lerp(initalColor, targetColor, elapsedTime / m_delay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //[OPTIONNEL] On s'assure que la couleur finale est bien la couleur cible
        m_renderer.material.color = targetColor;
        yield return null;
    }


}
