using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDevice : MonoBehaviour
{
    public GameObject device;

    public void SwitchDevice()
    {
        device.SetActive(!device.activeSelf);
    } 
}
