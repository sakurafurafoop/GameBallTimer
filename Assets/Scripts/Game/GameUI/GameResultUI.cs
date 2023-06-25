using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField] private Image panelResult;
        [SerializeField] private GameObject round;
        [SerializeField] private GameObject total;

        [SerializeField] private Slider sliderResult;
        [SerializeField] private Image imageFill;

        [SerializeField] private TextMeshProUGUI textResultTitle;
        [SerializeField] private TextMeshProUGUI textResult;
        [SerializeField] private TextMeshProUGUI textSecond;
        [SerializeField] private TextMeshProUGUI textTotalScore;
        [SerializeField] private TextMeshProUGUI textStage;
        [SerializeField] private TextMeshProUGUI textScore;

        [SerializeField] private Button btnNextStage;

        private float secondScore;

        public void OnResultPanel(float second, int nowScore)
        {
            secondScore = second;
            DisplayResult();
            SetSlider();
            ChangeTextResultTitle(GameData.Instance.stage.ToString() + "ステージ目の結果");
            textScore.text = nowScore.ToString();
            textSecond.text = (Mathf.Sign(secondScore) == 1 ? "+" : "") + secondScore.ToString("F2") + "秒";
            textTotalScore.text = GameData.Instance.totalScore.ToString();
            textStage.text = GameData.Instance.stage.ToString();
            panelResult.gameObject.SetActive(true);
        }

        public void ChangeTextResultTitle(string str)
        {
            textResultTitle.text = str;
        }

        private void DisplayResult()
        {
            if (GameData.Instance.isSuccess)
            {
                textResult.text = "Clear!";
                btnNextStage.gameObject.SetActive(true);
            }
            else
            {
                textResult.text = "Miss...";
                btnNextStage.gameObject.SetActive(false);
            }
        }

        private void SetSlider()
        {
            sliderResult.minValue = GameData.Instance.timeTarget - 2.0f;
            sliderResult.maxValue = GameData.Instance.timeTarget + 2.0f;
            sliderResult.value = GameData.Instance.timeNow;
            if(Mathf.Abs(secondScore) >= 0 && Mathf.Abs(secondScore) < 0.5f)
            {
                imageFill.color = Color.blue;
            }
            else if (Mathf.Abs(secondScore) >= 0.5f && Mathf.Abs(secondScore) < 1f)
            {
                imageFill.color = Color.green;
            }
            else if (Mathf.Abs(secondScore) >= 1f && Mathf.Abs(secondScore) < 1.5f)
            {
                imageFill.color = Color.yellow;
            }
            else
            {
                imageFill.color = Color.red;
            }
        }

        public void OffResultPanel()
        {
            panelResult.gameObject.SetActive(false);
        }

        public void OnActiveRound(bool isActive)
        {
            round.SetActive(isActive);
        }

        public void OnActiveTotal(bool isActive)
        {
            total.SetActive(isActive);
        }
    }
}

