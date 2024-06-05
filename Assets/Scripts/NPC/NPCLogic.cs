using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public Transform dialogueTrans;
    public Transform spaceTrans;
    //public Collider dialogueCollider;

    // Start is called before the first frame update
    void Start()
    {
        spaceTrans?.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) { 
            spaceTrans?.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& other.CompareTag("Player"))
        {
            dialogueTrans?.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            dialogueTrans?.gameObject.SetActive(true);
            spaceTrans?.gameObject.SetActive(false);
        }
    }

}
