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

        [SerializeField] private Slider sliderResult;
        [SerializeField] private Image imageFill;

        [SerializeField] private TextMeshProUGUI textResult;
        [SerializeField] private TextMeshProUGUI textTotalScore;

        private float nowScore;

        public void OnResultPanel(float score)
        {
            panelResult.gameObject.SetActive(true);
            nowScore = score;
            SetSlider();
            textResult.text = nowScore.ToString("F2");
        }

        private void SetSlider()
        {
            sliderResult.minValue = GameData.Instance.timeGoal - 2.0f;
            sliderResult.maxValue = GameData.Instance.timeGoal + 2.0f;
            sliderResult.value = GameData.Instance.timeNow;
            Debug.Log(nowScore);
            if(Mathf.Abs(nowScore) >= 0 && Mathf.Abs(nowScore) < 0.5f)
            {
                imageFill.color = Color.blue;
            }
            else if (Mathf.Abs(nowScore) >= 0.5f && Mathf.Abs(nowScore) < 1f)
            {
                imageFill.color = Color.green;
            }
            else if (Mathf.Abs(nowScore) >= 1f && Mathf.Abs(nowScore) < 1.5f)
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
    }
}

