using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysCounter : MonoBehaviour
{
    public static DaysCounter singleton { get; private set; }

    public static int CurrentDay;

    public List<int> messagesPerMinute = new List<int>();
    public List<int> delayBetweenMessages = new List<int>();

    public delegate void ChangeDayHandler();
    public event ChangeDayHandler DayChanged;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        DayChanged += DayChange;
        DayChanged += PCMail.singleton.DayChange;
        DayChanged += PCPopUp.DayChange;
        DayChanged += PhoneMail.singleton.DayChange;
        DayChanged += PlayerBehavior.DayChange;
        DayChanged += MessageManager.singleton.DayChange;
    }

    void DayChange()
    {
        CurrentDay += 1;
    }

    public void TriggerDayChangeEvent()
    {
        Debug.Log($"new day {CurrentDay}!");
        DayChanged.Invoke();
    }
}
