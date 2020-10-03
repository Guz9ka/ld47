using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysCounter : MonoBehaviour
{
    public static DaysCounter singleton { get; private set; }

    public static int CurrentDay;

    public List<int> messagesPerMinute = new List<int>();

    public delegate void ChangeDayHandler();
    public event ChangeDayHandler OnDayChange;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        OnDayChange += DayChange;
    }

    void DayChange()
    {
        CurrentDay += 1;
    }
}
