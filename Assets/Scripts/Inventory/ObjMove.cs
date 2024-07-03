using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    //obj ID
    public int objId;

    // �ƶ�����
    public float amplitude = 0.3f;
    // �ƶ��ٶ�
    public float speed = 1.0f;

    // ��ʼλ��
    private Vector3 startPosition;

    void Start()
    {
        // ��¼��ʼλ��
        startPosition = transform.position;
    }

    void Update()
    {
        // �����µ�Z��λ��
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        // ��������λ��
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
