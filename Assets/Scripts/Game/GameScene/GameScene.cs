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
        [SerializeField] private Stage stage;
        public Stage Stage => stage;

        // 他クラス
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
            stateMachine.Initialize(StateName.InitGame);
        }

        // Update is called once per frame
        void Update()
        {
            stateMachine.MainUpdate();
        }

        public void OnClickOK()
        {
            StateMachine.ChangeState(StateName.RollBall);
        }

        public void OnClickNext()
        {
            StateMachine.ChangeState(StateName.DecideStage);
        }
    }
}

