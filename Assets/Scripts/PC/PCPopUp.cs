using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPopUp : MonoBehaviour, IWindow
{
    public static PCPopUp singleton { get; private set; }

    public GameObject PopUpWindow;

    private void Awake()
    {
        singleton = this;
    }

    public void WindowSwitch()
    {
        PopUpWindow.SetActive(!PopUpWindow.activeSelf);
    }

    public void DayChange()
    {
        PopUpWindow.SetActive(false);
    }
}
