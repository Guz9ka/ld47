using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _Timer : MonoBehaviour
{
    public static _Timer singleton { get; private set; }

    public float currentTime;
    public int dayEndTime;
    public int dayStartTime;
    public float timeBetweenDaysMultiplier;

    public int HpToDecrease;


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

            if (currentTime > 300)
            {
                DaysCounter.singleton.TriggerAlarm();
            }

            if (currentTime > dayEndTime)
            {
                DaysCounter.singleton.TriggerDayEnd();
            }

            //Логика работы таймера
            if (currentTime > dayStartTime && currentTime < dayEndTime)
            {
                TimerNormalSpeed();
                StartCoroutine("DecreasePlayerHP");
                if (MessageManager.singleton.messagingIsAvailable)
                {
                    StartCoroutine("TriggerMessageEvent");
                }
            }
            else
            {
                TimerSpeedUp();
            }
        }
    }

    IEnumerator DecreasePlayerHP()
    {
        yield return new WaitForSeconds(1);
        if (PhoneMail.singleton.activeMessages.Count > 0 || PCMail.singleton.activeMessages.Count > 0)
        {
            PlayerBehavior.singleton.AddPlayerHP(-HpToDecrease * Time.deltaTime);

        }
    }

    void TimerNormalSpeed()
    {
        currentTime += Time.deltaTime;
        TimerTick(currentTime);
    }

    void TimerSpeedUp()
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
        foreach (TextMeshProUGUI timerPanel in timerText)
        {
            timerPanel.text = formattedTime;
        }
    }

    IEnumerator TriggerMessageEvent()
    {
        var messageManager = MessageManager.singleton;

        messageManager.messagingIsAvailable = false;

        Debug.Log("new message!");
        messageManager.TriggerMessageEvent();
        yield return new WaitForSeconds(messageManager.delayBetweenMessages);

        messageManager.messagingIsAvailable = true;
    }

    public void DayEnd()
    {
        StopAllCoroutines();
    }
}
