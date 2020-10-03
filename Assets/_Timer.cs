using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class _Timer : MonoBehaviour
{
    public static float currentTime;
    public TextMeshProUGUI timerText;

    string hours;
    string minutes;

    public bool isActive;

    private void Update()
    {
        if (isActive) TimerTick();
    }

    void TimerTick()
    {
        currentTime += Time.deltaTime;

        int inthours = Convert.ToInt32(currentTime / 60);
        int intminutes = Convert.ToInt32(currentTime % 60);

        #region Format time
        if (inthours >= 24)
        {
            currentTime = 0;
        }
        if (intminutes > 59)
        {
            intminutes = 0;
        }

        if (inthours.ToString().Length < 2)
        {
            hours = $"0{inthours}";
        }
        else
        {
            hours = inthours.ToString();
        }

        if (intminutes.ToString().Length < 2)
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

    public static void DayChange()
    {
        currentTime = 0;
    }
}
