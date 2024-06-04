using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class TimeManager : Singleton<TimeManager>
{
    private int gameSecond, gameMinute, gameHour, gameDay, gameMonth, gameYear;

    public bool gameClockPause;
    private float tikTime;

    //灯光时间差
    private float timeDifference;

    //public TimeSpan GameTime => new TimeSpan(gameHour, gameMinute, gameSecond);

    //public string GUID => GetComponent<DataGUID>().guid;

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        //EventHandler.UpdateGameStateEvent += OnUpdateGameStateEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        EventHandler.EndGameEvent += OnEndGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        //EventHandler.UpdateGameStateEvent -= OnUpdateGameStateEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        EventHandler.EndGameEvent -= OnEndGameEvent;
    }


    private void Start()
    {

        //saveable.RegisterSaveable();
        //gameClockPause = true;
        EventHandler.CallGameDateEvent(gameHour, gameDay, gameMonth, gameYear);
        EventHandler.CallGameMinuteEvent(gameMinute, gameHour, gameDay);
        // //切换灯光
        // EventHandler.CallLightShiftChangeEvent(gameSeason, GetCurrentLightShift(), timeDifference);
    }

    private void Update()
    {
        if (!gameClockPause)
        {
            tikTime += Time.deltaTime;

            if (tikTime >= Settings.secondThreshold)
            {
                tikTime -= Settings.secondThreshold;
                UpdateGameTime();
            }
        }
        /*
        if (Input.GetKey(KeyCode.T))
        {
            for (int i = 0; i < 60; i++)
            {
                UpdateGameTime();
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gameDay++;
            EventHandler.CallGameDayEvent(gameDay);
            EventHandler.CallGameDateEvent(gameHour, gameDay, gameMonth, gameYear);
        }
        */
    }
    private void OnEndGameEvent()
    {
        //gameClockPause = true;
    }
    private void OnStartNewGameEvent(int obj)
    {
        NewGameTime();
        gameClockPause = false;
    }

    private void NewGameTime()
    {
        gameSecond = 0;
        gameMinute = 0;
        gameHour = 7;
        gameDay = 1;
        gameMonth = 1;
        gameYear = 2022;
        //gameSeason = Season.春天;
    }

    //private void OnUpdateGameStateEvent(GameState gameState)
    //{
    //    gameClockPause = gameState == GameState.Pause;
    //}

    private void OnAfterSceneLoadedEvent()
    {
        gameClockPause = false;
        EventHandler.CallGameDateEvent(gameHour, gameDay, gameMonth, gameYear);
        EventHandler.CallGameMinuteEvent(gameMinute, gameHour, gameDay);
        //切换灯光
        //EventHandler.CallLightShiftChangeEvent(gameSeason, GetCurrentLightShift(), timeDifference);
    }

    private void OnBeforeSceneUnloadEvent()
    {
        //gameClockPause = true;
    }

    private void UpdateGameTime()
    {
        gameSecond++;
        if (gameSecond > Settings.secondHold)
        {
            gameMinute++;
            gameSecond = 0;

            if (gameMinute > Settings.minuteHold)
            {
                gameHour++;
                gameMinute = 0;

                if (gameHour > Settings.hourHold)
                {
                    gameDay++;
                    gameHour = 0;

                    if (gameDay > Settings.dayHold)
                    {
                        gameDay = 1;
                        gameMonth++;

                        if (gameMonth > 12)
                            gameMonth = 1;

                        
                    }
                }
                EventHandler.CallGameDateEvent(gameHour, gameDay, gameMonth, gameYear);
            }
            EventHandler.CallGameMinuteEvent(gameMinute, gameHour, gameDay);
            //切换灯光
            //EventHandler.CallLightShiftChangeEvent(gameSeason, GetCurrentLightShift(), timeDifference);
        }

        //Debug.Log("Second: " + gameSecond + " Minute: " + gameMinute + " hour: " + gameHour);
    }

    /// <summary>
    /// 返回lightshift同时计算时间差
    /// </summary>
    /// <returns></returns>
    //private LightShift GetCurrentLightShift()
    //{
    //    if (GameTime >= Settings.morningTime && GameTime < Settings.nightTime)
    //    {
    //        timeDifference = (float)(GameTime - Settings.morningTime).TotalMinutes;
    //        return LightShift.Morning;
    //    }

    //    if (GameTime < Settings.morningTime || GameTime >= Settings.nightTime)
    //    {
    //        timeDifference = Mathf.Abs((float)(GameTime - Settings.nightTime).TotalMinutes);
    //        // Debug.Log(timeDifference);
    //        return LightShift.Night;
    //    }

    //    return LightShift.Morning;
    //}



}
