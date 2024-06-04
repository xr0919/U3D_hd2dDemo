using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public Transform dialogueTrans;
    //public Collider dialogueCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueTrans.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        dialogueTrans.gameObject.SetActive(true);
    }

}
