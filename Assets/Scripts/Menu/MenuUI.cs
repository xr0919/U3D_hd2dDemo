using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject timeCanvas;
    private int panelIndex = 0;

    private GameObject player;
    private GameObject npcFollowed;
    private Camera camera;
    private CinemachineBrain cinemachineBrain;
    public Button btnInit;
    public Button btnStart;
    public Button btnContinue;
    public Button btnQuit;
    public Button[] btnSlot;

    public float moveSpeed = 1f;
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -15f;
    public float maxZ = -10f;

    private Vector3 targetPosition;

    //panel1
    private bool increasing = true;
    //text渐变
    public Text textBtn;
    public float fadeSpeed = 0.5f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
        player?.SetActive(false);
        cinemachineBrain = camera?.transform.GetComponent<CinemachineBrain>();
        cinemachineBrain.enabled = false;
        timeCanvas.SetActive(false);

        //panel1
        if (btnInit != null)
        {
            btnInit.onClick.AddListener(() =>
            {
                panels[0].SetActive(false);
                panels[1].SetActive(true);
                panelIndex = 1;
            });
        }
        GenerateNewTargetPosition();

        //panel2
        if (btnStart != null)
        {
            btnStart.onClick.AddListener(() =>
            {
                cinemachineBrain.enabled = true;
                player?.SetActive(true);
                timeCanvas.SetActive(true);

                //
                npcFollowed = GameObject.Find("NPC_follow");
                npcFollowed?.SetActive(false);
                npcFollowed?.SetActive(true);

                this.gameObject.SetActive(false);
            });
        }
        if (btnContinue != null)
        {
            btnContinue.onClick.AddListener(() =>
            {
                panels[1].SetActive(false);
                panels[2].SetActive(true);
                panelIndex = 2;
            });
        }
        if (btnQuit != null)
        {
            btnQuit.onClick.AddListener(() =>
            {
                Application.Quit();
                /*EventHandler.PauseGame += () =>
                {
                    Time.timeScale = 0;
                };
                EventHandler.CallPauseGameEvent();*/
            });
        }

        //panel3
        for(int i = 0; i < btnSlot.Length; i++)
        {
            btnSlot[i].onClick.AddListener(() =>
            {
                cinemachineBrain.enabled = true;
                player?.SetActive(true);
                timeCanvas.SetActive(true);

                //
                npcFollowed = GameObject.Find("NPC_follow");
                npcFollowed?.SetActive(false);
                npcFollowed?.SetActive(true);

                this.gameObject.SetActive(false);
            });
        }


        //1.
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[0].SetActive(true);
        panelIndex = 0;

    }
    private void Update()
    {
        if (Input.anyKeyDown && panels[0].activeSelf)
        {
            panels[0].SetActive(false);
            panels[1].SetActive(true);
            panelIndex = 1;
        }

        // 计算朝目标位置移动的方向
        Vector3 direction = (targetPosition - camera.transform.position).normalized;

        // 计算新的摄像机位置
        Vector3 newPosition = camera.transform.position + direction * moveSpeed * Time.deltaTime;

        // 更新摄像机位置
        camera.transform.position = newPosition;

        // 检查是否接近目标位置，如果是则生成新的目标位置
        if (Vector3.Distance(camera.transform.position, targetPosition) < 0.1f)
        {
            GenerateNewTargetPosition();
        }


        //图片渐变
        float newAlpha = increasing ? textBtn.color.a + fadeSpeed * Time.deltaTime : textBtn.color.a - fadeSpeed * Time.deltaTime;

        // 切换递增和递减的方向
        if (newAlpha >= 1f)
        {
            newAlpha = 1f;
            increasing = false;
        }
        else if (newAlpha <= 0f)
        {
            newAlpha = 0f;
            increasing = true;
        }

        // 设置新的颜色，保持原有颜色的 RGB 成分，只修改透明度
        textBtn.color = new Color(textBtn.color.r, textBtn.color.g, textBtn.color.b, newAlpha);

        //返回上一个panel
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].SetActive(false);
            }
            panels[panelIndex>0 ? panelIndex-- : 0].SetActive(true);
        }

        
    }
    private void GenerateNewTargetPosition()
    {
        // 生成新的目标位置
        targetPosition = new Vector3(Random.Range(minX, maxX), camera.transform.position.y, Random.Range(minZ, maxZ));
    }
    /*public GameObject[] panels;

    public void SwitchPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].transform.SetAsLastSibling();
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("EXIT GAME");
    }
    */
}
