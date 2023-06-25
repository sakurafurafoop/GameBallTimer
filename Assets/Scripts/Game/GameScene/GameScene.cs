using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameScene : MonoBehaviour
    {
        private StateMachine stateMachine;
        public StateMachine StateMachine => stateMachine;

        // GameObject
        [SerializeField] private Ball ball;
        public Ball Ball => ball;

        // 他クラス
        [SerializeField] private StageManager stageManager;
        public StageManager StageManager => stageManager;

        [SerializeField] private AudioPlayer audioPlayer;
        public AudioPlayer AudioPlayer => audioPlayer;

        [SerializeField] private GameUI gameUI;
        public GameUI GameUI => gameUI;

        [SerializeField] private GameResultUI gameResultUI;
        public GameResultUI GameResultUI => gameResultUI;

        [SerializeField] private SliderPosition sliderPosition;
        public SliderPosition SliderPosition => sliderPosition;

        private void Awake()
        {
            stateMachine = new StateMachine(this);

        }
        // Start is called before the first frame update
        void Start()
        {
            stateMachine.Initialize(StateName.Title);
        }

        // Update is called once per frame
        void Update()
        {
            stateMachine.MainUpdate();
        }

        // ボール位置確定
        public void OnClickOK()
        {
            StateMachine.ChangeState(StateName.RollBall);
            AudioPlayer.PlaySE(AudioPlayer.AudioName.OK);
        }

        public void OnClickNext()
        {
            StateMachine.ChangeState(StateName.DecideStage);
            AudioPlayer.PlaySE(AudioPlayer.AudioName.Button);
        }

        public void OnClickGameStart()
        {
            stateMachine.ChangeState(StateName.InitGame);
            AudioPlayer.PlaySE(AudioPlayer.AudioName.Button);
        }

        public void OnClickFinish()
        {
            stateMachine.ChangeState(StateName.GameResult);
            AudioPlayer.PlaySE(AudioPlayer.AudioName.Button);
        }

        public void OnClickBackTitle()
        {
            stateMachine.ChangeState(StateName.Title);
            AudioPlayer.PlaySE(AudioPlayer.AudioName.Button);
        }

        public void OnClickRetry()
        {
            stateMachine.ChangeState(StateName.InitGame);
            AudioPlayer.PlaySE(AudioPlayer.AudioName.Button);
        }
    }
}

