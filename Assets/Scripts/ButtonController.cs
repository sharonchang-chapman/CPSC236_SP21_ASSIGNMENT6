using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject ResetButton;
    public GameObject QuitButton;

    public void HideButtons()
    {
        ResetButton.SetActive(false);
        QuitButton.SetActive(false);
    }

    public void ShowButtons()
    {
        ResetButton.SetActive(true);
        QuitButton.SetActive(true);
    }
}
