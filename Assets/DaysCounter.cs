using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysCounter : MonoBehaviour
{
    static int CurrentDay;

    public delegate void ChangeDayHandler();
    public event ChangeDayHandler OnDayChange;

    private void Start()
    {
        OnDayChange += DayChange;
    }

    void DayChange()
    {
        CurrentDay += 1;
    }
}
