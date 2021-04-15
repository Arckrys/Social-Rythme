using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private PlayerInputsController m_playerInputsController;

    private void Awake()
    {
        m_playerInputsController = new PlayerInputsController();
    }

    private void OnEnable()
    {
        m_playerInputsController.Enable();
    }

    private void OnDisable()
    {
        m_playerInputsController.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_playerInputsController.Default.Track1.performed += ctx => PressTrackOne();
    }

    private void PressTrackOne()
    {
        Debug.Log("Track one pressed");
    }

}
