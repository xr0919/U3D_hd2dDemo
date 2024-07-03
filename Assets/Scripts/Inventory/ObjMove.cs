using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    //obj ID
    public int objId;

    // 移动幅度
    public float amplitude = 0.3f;
    // 移动速度
    public float speed = 1.0f;

    // 初始位置
    private Vector3 startPosition;

    void Start()
    {
        // 记录初始位置
        startPosition = transform.position;
    }

    void Update()
    {
        // 计算新的Z轴位置
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        // 更新物体位置
        transform.position = new Vector3(startPosition.x, newY,startPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            if(objId == 1)
            {
                InventoryMgr.Instance.objId1 = true;
            }
            if (objId == 2)
            {
                InventoryMgr.Instance.objId2 = true;
                InventoryMgr.Instance.numObjId2++;
            }
        }
    }
}
