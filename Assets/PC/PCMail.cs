using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMail : MonoBehaviour, IMessage
{
    public List<GameObject> messages = new List<GameObject>();
    //public Event
    void Start()
    {
        foreach(GameObject message in messages)
        {
            message.SetActive(false);
        }
    }

    public void CreateNewMessage(int messagesCount)
    {
        for (int i = 0; i < messagesCount; i++)
        {
            if(messages[i].activeSelf != true)
            {
                messages[i].SetActive(true);
            }
        }
    }

    public void CreateNotification()
    {
        throw new System.NotImplementedException();
    }

    public void DeleteMessage(int messageNumber)
    {
        throw new System.NotImplementedException();
    }
}
