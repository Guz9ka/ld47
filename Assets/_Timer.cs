using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class _Timer : MonoBehaviour
{
    public float startTime;
    public TextMeshProUGUI timerText;

    string hours;
    string minutes;

    private void Update()
    {
        startTime += Time.deltaTime;

        int inthours = Convert.ToInt32(startTime / 60);
        int intminutes = Convert.ToInt32(startTime % 60);

        if (inthours.ToString().Length < 2)
        {
            hours = $"0{inthours}";
        }
        else
        {
            hours = inthours.ToString();
        }

        if(intminutes.ToString().Length < 2)
        {
            minutes = $"0{intminutes}";
        }
        else
        {
            minutes = intminutes.ToString();
        }

        if(inthours > 24)
        {
            startTime = 0;
        }
        if(intminutes > 59)
        {
            intminutes = 0;
        }

        string formattedTime = hours + " : " + minutes;
        timerText.text = formattedTime;
    }
}
