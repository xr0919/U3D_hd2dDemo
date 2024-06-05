using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public RectTransform dayNightImage;
    public RectTransform clockHand;

    private int t = 0;

    //setting
    public Button btnSetting;
    public Button btnSave;
    public GameObject savePanel;
    public GameObject settingPanel;
    private float panelTimer = 2;
    private bool isShow;
    public Button btnBack;
    public Button btnQuit;

    private void Awake()
    {
        savePanel?.SetActive(false);
        settingPanel?.SetActive(false);
        btnSave?.onClick.AddListener(() =>
        {
            savePanel.SetActive(true);
            isShow = true;
            panelTimer = 0;
        });
        btnSetting?.onClick.AddListener(() =>
        {
            settingPanel.SetActive(true);
        });
        btnBack?.onClick.AddListener(() => { settingPanel.SetActive(false); });
        btnQuit?.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    private void OnEnable()
    {
        //EventHandler.GameMinuteEvent += OnGameMinuteEvent;
        EventHandler.GameDateEvent += OnGameDateEvent;
    }

    private void OnDisable()
    {
        //EventHandler.GameMinuteEvent -= OnGameMinuteEvent;
        EventHandler.GameDateEvent -= OnGameDateEvent;
    }

    private void Update()
    {
        if (isShow)
        {
            panelTimer += Time.deltaTime;
            if(panelTimer > 1)
            {
                savePanel.SetActive(false);
                isShow = false;
                panelTimer = 0;
            }
        }
    }


    private void OnGameDateEvent(int hour, int day, int month, int year)
    {
        //dateText.text = year + "年" + month.ToString("00") + "月" + day.ToString("00") + "日";
        //seasonImage.sprite = seasonSprites[(int)season];

        SwitchHourImage(hour);
        DayNightImageRotate(hour);
    }

    /// <summary>
    /// 根据小时切换时间块显示
    /// </summary>
    /// <param name="hour"></param>
    private void SwitchHourImage(int hour)
    {
        int index = hour / 4;

        //if (index == 0)
        //{
        //    foreach (var item in clockBlocks)
        //    {
        //        item.SetActive(false);
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < clockBlocks.Count; i++)
        //    {
        //        if (i < index + 1)
        //            clockBlocks[i].SetActive(true);
        //        else
        //            clockBlocks[i].SetActive(false);
        //    }
        //}
    }

    private void DayNightImageRotate(int hour)
    {
        //var target = new Vector3(0, 0, hour * 15 - 90);
        var target = new Vector3(0, 0, 90);
        //dayNightImage.DORotate(target, 1f, RotateMode.Fast);
        t++;
        //每6小时转一次转盘
        if(t == 6)
        {
            dayNightImage.Rotate(target, Space.Self);
            t = 0;
        }
        var targetClockHand = new Vector3(0, 0, -30);
        clockHand.Rotate(targetClockHand,Space.Self);
    }
    
}
