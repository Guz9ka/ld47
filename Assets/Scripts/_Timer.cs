using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class _Timer : MonoBehaviour
{
    public static _Timer singleton { get; private set; }

    public float currentTime;
    public int dayEndTime;
    public int dayStartTime;
    public float timeBetweenDaysMultiplier;

<<<<<<< HEAD
    [Header("Отправка сообщений")]
    private int messagesPerMinute;
    private int messagesSent;
=======
>>>>>>> master

    public List<TextMeshProUGUI> timerText = new List<TextMeshProUGUI>();

    [Header("Работа со временем")]
    int intHours;
    string strHours;

    int intMinutes;
    string strMinutes;

    public bool isActive = true;

    private void Awake()
    {
        singleton = this;
    }

<<<<<<< HEAD
    private void Start()
    {
        messagesSent = 0;
        messagesPerMinute = DaysCounter.singleton.messagesPerMinute[DaysCounter.CurrentDay];
    }

=======
>>>>>>> master
    private void Update()
    {
        if (isActive)
        {
            //Change Day
            if (currentTime >= 1440)
            {
                currentTime = 0;
                DaysCounter.singleton.TriggerDayChangeEvent();
            }

            //Логика работы таймера
            if (currentTime > dayStartTime && currentTime < dayEndTime)
            {
                TimerNormalSpeed();

<<<<<<< HEAD
                if (intMinutes > 60 / messagesPerMinute * messagesSent)
                {
                    MessageManager.singleton.TriggerMessageEvent();
                    messagesSent += 1;

                    if (messagesSent >= messagesPerMinute) messagesSent = 1;
=======
                if (MessageManager.singleton.messagingIsAvailable)
                {
                    StartCoroutine("TriggerMessageEvent");
>>>>>>> master
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

<<<<<<< HEAD
    private void TimerSpeedUp()
=======
    void TimerSpeedUp()
>>>>>>> master
    {
        currentTime += Time.deltaTime * timeBetweenDaysMultiplier;
        TimerTick(currentTime);
    }

    void TimerTick(float currentTime)
    {

        double doubleHours = Convert.ToDouble(currentTime / 60);
        double doubleMinutes = Convert.ToDouble(currentTime % 60);

        intHours = (int)doubleHours;
        intMinutes = (int)doubleMinutes;

        #region Format time
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

<<<<<<< HEAD
    public void DayChange()
    {
        messagesPerMinute = DaysCounter.singleton.messagesPerMinute[DaysCounter.CurrentDay + 1];
        messagesSent = 0;
        //отменить все ивенты
=======
    IEnumerator TriggerMessageEvent()
    {
        var messageManager = MessageManager.singleton;

        messageManager.messagingIsAvailable = false;

        Debug.Log("new message!");
        messageManager.TriggerMessageEvent();
        yield return new WaitForSeconds(messageManager.delayBetweenMessages);

        messageManager.messagingIsAvailable = true;
>>>>>>> master
    }
}
