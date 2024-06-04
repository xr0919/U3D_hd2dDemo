using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string sceneToGo;
    public Vector3 positionToGo;

    private void OnTriggerEnter(Collider other)
    {
        print("player");
        if (other.CompareTag("Player"))
        {
            EventHandler.CallTransitionEvent(sceneToGo, positionToGo);
        }
    }
}
