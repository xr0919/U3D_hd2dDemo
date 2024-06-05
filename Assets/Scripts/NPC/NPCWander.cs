using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWander : MonoBehaviour
{
    public float speed = 5.0f;           // NPC �ƶ��ٶ�
    public float changeDirectionTime = 2.0f; // �ı䷽���ʱ����

    private Vector3 direction;           // �ƶ�����
    private float timer;
    private bool canMove = true;

    public Animator animator;
    public Transform graphicTrans;
    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ���ƶ�����ͼ�ʱ��
        ChangeDirection();
        timer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            // �ƶ� NPC
            transform.Translate(direction * speed * Time.deltaTime, Space.Self);

            // ���¼�ʱ��
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // �ı䷽��
                ChangeDirection();
                timer = changeDirectionTime;
            }
        }
    }

    private void ChangeDirection()
    {
        // �������һ����ά��������
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if(direction.x > 0)
            {
                graphicTrans.localScale = new Vector3(-6,6,-6);
            }
            else
            {
                graphicTrans.localScale = new Vector3(6,6,6);
            }
            // X �᷽����� Z �᷽��
            animator.SetFloat("DirX", 1f);
            animator.SetFloat("DirZ", 0f);
        }
        else
        {
            // Z �᷽����ڻ���� X �᷽��
            if (direction.z < 0)
            {
                animator.SetFloat("DirX", 0f);
                animator.SetFloat("DirZ", 1f);
            }
            else
            {
                animator.SetFloat("DirX", 0f);
                animator.SetFloat("DirZ", 0f);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            canMove = false;
            //timer = 10;
            animator.SetFloat("DirX", 0f);
            animator.SetFloat("DirZ", 0f);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) { 
            timer = 0;
            canMove = true;
        } 
    }
}
