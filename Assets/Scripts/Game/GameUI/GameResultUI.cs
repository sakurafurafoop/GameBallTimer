using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace Game
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField] private Image panelResult;
        [SerializeField] private Image imageFade;
        [SerializeField] private GameObject round;
        [SerializeField] private GameObject total;
        private const float OPENTIME = 0.8f;

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

        public void OnResultPanel(float second = 0, int nowScore = 0)
        {
            secondScore = second;
            DisplayResult();
            SetSlider();
            ChangeTextResultTitle(GameData.Instance.stage.ToString() + "ステージ目の結果");
            textScore.text = nowScore.ToString();
            textSecond.text = (Mathf.Sign(secondScore) == 1 ? "+" : "") + secondScore.ToString("F2") + "秒";
            textTotalScore.text = GameData.Instance.totalScore.ToString();
            textStage.text = GameData.Instance.stage.ToString();
            DisplayResultPanel();
        }

        private void DisplayResultPanel()
        {
            imageFade.gameObject.SetActive(true);
            imageFade.material.SetFloat("_progress", 1);
            float progressValue = 1;
            DOTween.To(x => progressValue = x, 1, 0, OPENTIME)
                .OnUpdate(() => imageFade.material.SetFloat("_progress", progressValue))
                .OnComplete(() => panelResult.gameObject.SetActive(true));
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
                imageFill.color = new Color(50 / 255, 180 / 255, 255 / 255);
            }
            else if (Mathf.Abs(secondScore) >= 0.5f && Mathf.Abs(secondScore) < 1f)
            {
                imageFill.color = new Color(166 / 255, 255 / 255, 50 / 255);
            }
            else if (Mathf.Abs(secondScore) >= 1f && Mathf.Abs(secondScore) < 1.5f)
            {
                imageFill.color = new Color(255 / 255, 221 / 255, 50 / 255);
            }
            else
            {
                imageFill.color = new Color(255 / 255, 50 / 255, 50 / 255);
            }
        }

        public void OffResultPanel()
        {
            panelResult.gameObject.SetActive(false);
            imageFade.material.SetFloat("_progress", 0);
            float progressValue = 0;
            DOTween.To(x => progressValue = x, 0, 1, OPENTIME * 1.5f)
                .OnUpdate(() => imageFade.material.SetFloat("_progress", progressValue))
                .OnComplete(() => imageFade.gameObject.SetActive(false));
     
        }

        public void IsActiveRound(bool isActive)
        {
            round.SetActive(isActive);
        }

        public void IsActiveTotal(bool isActive)
        {
            total.SetActive(isActive);
        }
    }
}

