using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager singleton { get; private set; }

    public delegate void MessageHandler();
    public event MessageHandler MessageArrived;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        MessageArrived += AddNewMessages;
        //звук
    }

    void AddNewMessages()
    {
        switch (Random.Range(1, 2))
        {
            case 1:
                SendMessageOnPhone();
                break;
            case 2:
                SendMessageOnPC();
                break;
        }
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
}
