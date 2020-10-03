using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPopUp : MonoBehaviour, IWindow
{
    public static GameObject PopUpWindow;

    public void WindowSwitch()
    {
        PopUpWindow.SetActive(!PopUpWindow.activeSelf);
    }

    public static void DayChange()
    {
        PopUpWindow.SetActive(false);
    }
}
