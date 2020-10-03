using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public delegate void OnMessageArrive();
    public event OnMessageArrive MessageHandler;

    private void Start()
    {
        MessageHandler += AddNewMessages;
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
}
