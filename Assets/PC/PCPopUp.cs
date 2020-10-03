using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPopUp : MonoBehaviour, IWindow
{
    public GameObject PopUpWindow;

    public void WindowSwitch()
    {
        PopUpWindow.SetActive(!PopUpWindow.activeSelf);
    }
}
