using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagP : MonoBehaviour
{
    public Button ShowBtn;
    public GameObject BagInfo;
    public Button CrossBtn;
    public Image[] imgs;
    public Text[] objNum;
    // Start is called before the first frame update
    void Start()
    {
        BagInfo.SetActive(false);
        for(int i = 0; i < imgs.Length; i++)
        {
            imgs[i].gameObject.SetActive(false);
        }

        ShowBtn?.onClick.AddListener(() =>
        {
            BagInfo.SetActive(true);
        });
        CrossBtn?.onClick.AddListener(() =>
        {
            BagInfo.SetActive(false);
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BagInfo.SetActive(true);
        }
        if (InventoryMgr.Instance.objId1)
        {
            imgs[0].gameObject.SetActive(true);
            imgs[2].gameObject.SetActive(true);
        }
        if (InventoryMgr.Instance.objId2)
        {
            imgs[1].gameObject.SetActive(true);
            imgs[3].gameObject.SetActive(true);
            for(int i = 0; i < objNum.Length; i++)
            {
                objNum[i].text = "" + InventoryMgr.Instance.numObjId2;
            }
        }
    }
}
