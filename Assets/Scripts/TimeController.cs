﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController Timer;

    public Text TimeText;
    public GameObject TimeObject;

    private TimeSpan TimePlayed;
    private bool IsTimer;
    private float ElapsedTime;

    void Awake()
    {
        if (Timer != null && Timer != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        Timer = this;
    }

    private void Start()
    {
        TimeText.text = "Time: 00:00.0";
        IsTimer = false;

        TimeObject.SetActive(false);
    }
    public void BeginTimer()
    {
        IsTimer = true;
        ElapsedTime = 0f;

        TimeObject.SetActive(true);
        StartCoroutine(UpdateTimer());
    }
    IEnumerator UpdateTimer()
    {
        while (IsTimer)
        {
            ElapsedTime += Time.deltaTime;
            TimePlayed = TimeSpan.FromSeconds(ElapsedTime);
            string TimeStr = "Time: " + TimePlayed.ToString("mm':'ss'.'f");
            TimeText.text = TimeStr;

            yield return null;
        }
    }
    public void EndTimer()
    {
        IsTimer = false;
    }
}
