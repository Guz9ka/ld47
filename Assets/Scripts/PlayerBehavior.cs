using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior singleton { get; private set; }

    [Header("Общие данные")]
    public static int PlayerHP;

    private Vector2 mousePosition;

    private GameObject currentMessage;
    private Vector2 originalPosition;

    private void Awake()
    {
        singleton = this;
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        if (currentMessage != null)
        {
            InteractPhoneMessage();

            if(currentMessage.transform.position.x > originalPosition.x + 25 || currentMessage.transform.position.x < originalPosition.x - 25)
            {
                PhoneMail.singleton.DeleteMessage();
                currentMessage.transform.position = originalPosition;
                currentMessage = null;
                Debug.Log("delete");
            }
        }
    }

    void InteractPhoneMessage() 
    {
        currentMessage.transform.position = new Vector2(mousePosition.x, currentMessage.transform.position.y);
    }

    public void GetPhoneMessage(GameObject message)
    {
        currentMessage = message;
        originalPosition = message.transform.position;
    }

    public static void DayChange()
    {
        PlayerHP = 100;
    }
}
