using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMail : MonoBehaviour, IMessage
{
    public static PhoneMail singleton { get; private set; }

    public List<GameObject> messages = new List<GameObject>();
    public List<GameObject> activeMessages = new List<GameObject>();

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        //DeleteAllMessages();
        activeMessages.Add(messages[0]);
        activeMessages.Add(messages[1]);
        activeMessages.Add(messages[2]);
        activeMessages.Add(messages[3]);
    }

    public void CreateNewMessage(int messagesCount)
    {
        for (int i = 0; i < messages.Count; i++)
        {
            if (messages[i].activeSelf == false)
            {
                messages[i].SetActive(true);
                activeMessages.Add(messages[i]);
                break;
            }
        }
    }

    public void DeleteMessage()
    {
        PlayerBehavior.singleton.AddPlayerHP(5);

        int available = activeMessages.Count - 1; //last message in list
        if (available < 0) 
        { 
            available = 0;
        }
        Debug.Log(available);
        messages[available].SetActive(false);
        activeMessages.RemoveAt(available);
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
