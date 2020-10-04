using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class _Timer : MonoBehaviour
{
    public float currentTime;
    public int dayEndTime;
    public int dayStartTime;
    public float timeBetweenDaysMultiplier;

    [Header("Отправка сообщений")]
    private int messagesPerMinute;
    private int messagesSent;

    public List<TextMeshProUGUI> timerText = new List<TextMeshProUGUI>();

    [Header("Работа со временем")]
    int intHours;
    string strHours;

    int intMinutes;
    string strMinutes;

    public bool isActive = true;

    private void Start()
    {
        messagesSent = 0;
        messagesPerMinute = DaysCounter.singleton.messagesPerMinute[DaysCounter.CurrentDay];
    }

    private void Update()
    {
        if (isActive)
        {
            if(currentTime > dayStartTime && currentTime < dayEndTime)
            {
                TimerNormalSpeed();

                if (intMinutes > 60 / messagesPerMinute * messagesSent)
                {
                    MessageManager.singleton.TriggerMessageEvent();
                    messagesSent += 1;

                    if (messagesSent >= messagesPerMinute) messagesSent = 1;
                }
            }
            else
            {
                TimerSpeedUp();
            }
        }
    }


    void TimerNormalSpeed()
    {
        currentTime += Time.deltaTime;
        TimerTick(currentTime);
    }

    private void TimerSpeedUp()
    {
        currentTime += Time.deltaTime;
        TimerTick(currentTime * timeBetweenDaysMultiplier);
    }

    void TimerTick(float currentTime)
    {

        double doubleHours = Convert.ToDouble(currentTime / 60);
        double doubleMinutes = Convert.ToDouble(currentTime % 60);

        intHours = (int)doubleHours;
        intMinutes = (int)doubleMinutes;

        #region Format time
        if (intHours >= 24 || intMinutes > 59)
        {
            currentTime = 0;
        }

        if (intHours.ToString().Length == 1)
        {
            strHours = $"0{intHours}";
        }
        else
        {
            strHours = intHours.ToString();
        }

        if (intMinutes.ToString().Length == 1)
        {
            strMinutes = $"0{intMinutes}";
        }
        else
        {
            strMinutes = intMinutes.ToString();
        }
        #endregion

        string formattedTime = strHours + ":" + strMinutes;
        foreach(TextMeshProUGUI timerPanel in timerText)
        {
            timerPanel.text = formattedTime;
        }
    }

    public void DayChange()
    {
        currentTime = 0;
        messagesPerMinute = 0;
        messagesPerMinute = DaysCounter.singleton.messagesPerMinute[DaysCounter.CurrentDay + 1];
        //отменить все ивенты
    }
}
