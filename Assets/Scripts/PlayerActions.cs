using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] List<Track> m_tracks;
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
        m_playerInputsController.Default.Track1.started += ctx => PressTrackOne();
        m_playerInputsController.Default.Track2.started += ctx => PressTrackTwo();
        m_playerInputsController.Default.Track3.started += ctx => PressTrackThree();
        m_playerInputsController.Default.Track4.started += ctx => PressTrackFour();
        m_playerInputsController.Default.Track5.started += ctx => PressTrackFive();
    }

    //Cette fonction est appelée quand on appuie sur une touche bind à l'action Track1
    private void PressTrackOne()
    {
        Debug.Log("Track one pressed");
        FinishLine.Instance.PressTrack(m_tracks[0]);
    }

    private void PressTrackTwo()
    {
        Debug.Log("Track two pressed");
        FinishLine.Instance.PressTrack(m_tracks[1]);
    }

    private void PressTrackThree()
    {
        Debug.Log("Track three pressed");
        FinishLine.Instance.PressTrack(m_tracks[2]);
    }

    private void PressTrackFour()
    {
        Debug.Log("Track four pressed");
        FinishLine.Instance.PressTrack(m_tracks[3]);
    }

    private void PressTrackFive()
    {
        Debug.Log("Track five pressed");
        FinishLine.Instance.PressTrack(m_tracks[4]);
    }

}
