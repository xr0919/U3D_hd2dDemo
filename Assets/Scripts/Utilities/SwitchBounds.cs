using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchBounds : MonoBehaviour
{
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += SwitchConfinerShape;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= SwitchConfinerShape;
    }
    private void SwitchConfinerShape()
    {
        print(111111);
        print(SceneManager.GetActiveScene().name);
        
        BoxCollider confinerShape = GameObject.FindGameObjectWithTag("BoundsConfiner").GetComponent<BoxCollider>();
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        confiner.m_BoundingVolume = confinerShape;
        confiner.InvalidatePathCache();

    }
}
