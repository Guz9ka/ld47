using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class _Timer : MonoBehaviour
{
    public float currentTime;
    private int messagesPerMinute;
    private int messagesToSent;

    public TextMeshProUGUI timerText;

    int inthours;
    string hours;

    int intminutes;
    string minutes;

    public bool isActive = true;

    private void Start()
    {
        messagesToSent = 0;
        messagesPerMinute = DaysCounter.singleton.messagesPerMinute[DaysCounter.CurrentDay];
    }

    private void Update()
    {
        if (isActive)
        {
            TimerTick();

            if (intminutes > 60 / messagesPerMinute * messagesToSent)
            {
                //MessageManager.Trigger
                Debug.Log("new message!");
                messagesToSent += 1;

                if (messagesToSent >= messagesPerMinute) messagesToSent = 0;
            }
        }
    }

    void TimerTick()
    {
        currentTime += Time.deltaTime;

        inthours = Convert.ToInt32(currentTime / 60);
        intminutes = Convert.ToInt32(currentTime % 60);

        #region Format time
        if (inthours >= 24)
        {
            currentTime = 0;
        }
        if (intminutes > 59)
        {
            intminutes = 0;
        }

        if (inthours.ToString().Length == 1)
        {
            hours = $"0{inthours}";
        }
        else
        {
            hours = inthours.ToString();
        }

        if (intminutes.ToString().Length == 1)
        {
            minutes = $"0{intminutes}";
        }
        else
        {
            minutes = intminutes.ToString();
        }
        #endregion

        string formattedTime = hours + " : " + minutes;
        timerText.text = formattedTime;
    }

    public void DayChange()
    {
        currentTime = 0;
        messagesPerMinute = 0;
        messagesPerMinute = DaysCounter.singleton.messagesPerMinute[DaysCounter.CurrentDay + 1];
    }
}
