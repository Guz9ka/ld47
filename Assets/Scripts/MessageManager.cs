using System.Collections;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager singleton { get; private set; }

    public delegate void MessageHandler();
    public event MessageHandler MessageArrived;

    [Header("Отправка сообщений")]
    public float delayBetweenMessages;
    public bool messagingIsAvailable;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        MessageArrived += AddNewMessages;
        messagingIsAvailable = true;
        delayBetweenMessages = DaysCounter.singleton.delayBetweenMessages[DaysCounter.CurrentDay];
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
    }

    void SendMessageOnPhone()
    {
        var phoneMail = PhoneMail.singleton;

        phoneMail.CreateNewMessage(1);
        _SoundManager.singleton.PlaySound(2);
    }

    void SendMessageOnPC()
    {
        var PCmail = PCMail.singleton;
        PCPopUp.singleton.WindowSwitch();

        PCmail.CreateNewMessage(1);
        _SoundManager.singleton.PlaySound(1);
    }

    public void TriggerMessageEvent()
    {
        MessageArrived.Invoke();
    }

    public void DayChange()
    {
        delayBetweenMessages = DaysCounter.singleton.delayBetweenMessages[DaysCounter.CurrentDay + 1];
        messagingIsAvailable = true;
        //отменить все ивенты
    }
}
