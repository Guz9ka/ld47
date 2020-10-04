using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMail : MonoBehaviour, IMessage
{
    public static PCMail singleton { get; private set; }

    public GameObject mailMessage;

    public List<GameObject> messages = new List<GameObject>();
    public List<GameObject> activeMessages = new List<GameObject>();
    //public Event

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
        activeMessages.Add(messages[4]);
        activeMessages.Add(messages[5]);
    }

    public void CreateNewMessage(int messagesCount)
    {
        for (int i = 0; i < messagesCount; i++)
        {
            if(messages[i].activeSelf != true)
            {
                messages[i].SetActive(true);
                activeMessages.Add(messages[i]);
            }
        }
    }

    public void DeleteMessage()
    {
        PlayerBehavior.singleton.AddPlayerHP(5);

        int available = activeMessages.Count - 1; //last message in list
        messages[available].SetActive(false);
        activeMessages.RemoveAt(available);
    }

    public void OpenMessage()
    {
        _SoundManager.singleton.PlaySound(3);
        mailMessage.SetActive(true);
    }

    public void CloseMessage()
    {
        _SoundManager.singleton.PlaySound(3);
        mailMessage.SetActive(false);
        DeleteMessage();
    }

    public void DayChange()
    {
        DeleteAllMessages();
    }

    private void DeleteAllMessages()
    {
        foreach(GameObject message in messages)
        {
            message.SetActive(false);
        }
    }
}
