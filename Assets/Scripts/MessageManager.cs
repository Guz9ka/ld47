using System.Collections;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> master
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager singleton { get; private set; }

    public delegate void MessageHandler();
    public event MessageHandler MessageArrived;

<<<<<<< HEAD
=======
    [Header("Отправка сообщений")]
    public float delayBetweenMessages;
    public bool messagingIsAvailable;

>>>>>>> master
    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        MessageArrived += AddNewMessages;
<<<<<<< HEAD
=======
        messagingIsAvailable = true;
        delayBetweenMessages = DaysCounter.singleton.delayBetweenMessages[DaysCounter.CurrentDay];
>>>>>>> master
        //звук
    }

    void AddNewMessages()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                SendMessageOnPhone();
                break;
            case 2:
                SendMessageOnPC();
                break;
        }
<<<<<<< HEAD

        Debug.Log("new message!");
=======
>>>>>>> master
    }

    void SendMessageOnPhone()
    {
        var phoneMail = PhoneMail.singleton;

        phoneMail.CreateNewMessage(1);
        //phoneMail.CreateNotification();
    }

    void SendMessageOnPC()
    {
        var PCmail = PCMail.singleton;

        PCmail.CreateNewMessage(1);
        //PCmail.CreateNotification();
    }

    public void TriggerMessageEvent()
    {
        MessageArrived.Invoke();
    }
<<<<<<< HEAD
=======

    public void DayChange()
    {
        delayBetweenMessages = DaysCounter.singleton.delayBetweenMessages[DaysCounter.CurrentDay + 1];
        messagingIsAvailable = true;
        //отменить все ивенты
    }
>>>>>>> master
}
