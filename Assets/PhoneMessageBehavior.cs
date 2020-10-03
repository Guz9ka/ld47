using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMessageBehavior : MonoBehaviour
{
    PlayerBehavior playerBehavior;

    private void Start()
    {
        playerBehavior = PlayerBehavior.singleton;
    }

    public void OnClick()
    {
        playerBehavior.GetPhoneMessage(gameObject);
    }
}
