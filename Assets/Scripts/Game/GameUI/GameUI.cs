using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTimeGoal;
    [SerializeField] private TextMeshProUGUI textTimeNow;

    [SerializeField] private TextMeshProUGUI textGame;

    [SerializeField] private Button buttonOK;

    public void DisplayTimeGoal()
    {
        textTimeGoal.text = GameData.Instance.timeGoal.ToString("F0");
    }

    public void DisplayTimeNow()
    {
        textTimeNow.text = GameData.Instance.timeNow.ToString("F2");
    }

    public void DisplayTextGame(string str)
    {
        textGame.text = str;
    }

    public void OnToggleBtnOK(bool isActive)
    {
        buttonOK.gameObject.SetActive(isActive);
    }
}
