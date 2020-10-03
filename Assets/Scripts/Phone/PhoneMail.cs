using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMail : MonoBehaviour, IMessage
{
    public static PhoneMail singleton { get; private set; }

    public List<GameObject> messages = new List<GameObject>();

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        DeleteAllMessages();
    }

    public void CreateNewMessage(int messagesCount)
    {
        for (int i = 0; i < messagesCount; i++)
        {
            if (messages[i].activeSelf != true)
            {
                messages[i].SetActive(true);
            }
        }
    }

    public void DeleteMessage(int messageNumber)
    {
        throw new System.NotImplementedException();
    }

    public void DayChange()
    {
        DeleteAllMessages();
    }

    private void DeleteAllMessages()
    {
        foreach (GameObject message in messages)
        {
            message.SetActive(false);
        }
    }
}
