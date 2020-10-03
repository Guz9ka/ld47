using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBehavior : MonoBehaviour
{
    private Vector2 mousePosition;

    private GameObject currentMessage;
    private Vector2 originalPosition;
    public static PlayerBehavior singleton { get; private set; }

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
}
