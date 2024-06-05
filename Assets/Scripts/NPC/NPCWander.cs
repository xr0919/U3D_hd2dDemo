using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWander : MonoBehaviour
{
    public float speed = 5.0f;           // NPC 移动速度
    public float changeDirectionTime = 2.0f; // 改变方向的时间间隔

    private Vector3 direction;           // 移动方向
    private float timer;
    private bool canMove = true;

    public Animator animator;
    public Transform graphicTrans;
    // Start is called before the first frame update
    void Start()
    {
        // 初始化移动方向和计时器
        ChangeDirection();
        timer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            // 移动 NPC
            transform.Translate(direction * speed * Time.deltaTime, Space.Self);

            // 更新计时器
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // 改变方向
                ChangeDirection();
                timer = changeDirectionTime;
            }
        }
    }

    private void ChangeDirection()
    {
        // 随机生成一个三维向量方向
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
            // X 轴方向大于 Z 轴方向
            animator.SetFloat("DirX", 1f);
            animator.SetFloat("DirZ", 0f);
        }
        else
        {
            // Z 轴方向大于或等于 X 轴方向
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
