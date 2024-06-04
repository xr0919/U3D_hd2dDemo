using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public Transform spriteChild;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //spriteChild = GetComponent<Transform>();
        //Animator animator = spriteChild.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
        this.transform.eulerAngles = Vector3.zero;
        if(agent.velocity != Vector3.zero)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        //��������ж������λ��
        Vector3 v = Vector3.Cross(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, this.transform.position);
        if(v.y < 0)
        {
            //����ڸ�������ұ�
            spriteChild.localScale = new Vector3(0.5f,0.5f,0.5f);
        }
        else
        {
            //����ڸ���������
            spriteChild.localScale = new Vector3(-0.5f,0.5f,-0.5f);
        }
    }
}
