using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDevice : MonoBehaviour
{
    public GameObject device;
    public GameObject table;
    public GameObject clock;
    public GameObject text;
    public void SwitchDevice()
    {
        device.SetActive(!device.activeSelf);
        table.SetActive(!table.activeSelf);
        clock.SetActive(!clock.activeSelf);
        text.SetActive(!text.activeSelf);
    } 
}
