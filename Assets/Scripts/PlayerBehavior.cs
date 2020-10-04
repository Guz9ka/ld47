using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior singleton { get; private set; }

    [Header("Общие данные")]
    public static float PlayerHP;

    private Vector2 mousePosition;

    private GameObject currentMessage;
    private Vector2 originalPosition;

    public TextMeshProUGUI hpBar;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        PlayerHP = 100;
    }

    void Update()
    {
        if(PlayerHP <= 0)
        {
            EndScene.singleton.StartEndScene();
        }

        mousePosition = Input.mousePosition;
        hpBar.text = $"HP:{(int)PlayerHP}";

        if (currentMessage != null)
        {
            InteractPhoneMessage();

            if(currentMessage.transform.position.x > originalPosition.x + 25 || currentMessage.transform.position.x < originalPosition.x - 25)
            {
                PhoneMail.singleton.DeleteMessage();
                currentMessage.transform.position = originalPosition;
                currentMessage = null;
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

    public void AddPlayerHP(float sum) 
    {
        PlayerHP += sum;
        if(PlayerHP > 100)
        {
            PlayerHP = 100;
        }
    }

    public void DayChange()
    {
        PlayerHP = 100;
    }
}
