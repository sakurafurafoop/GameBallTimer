using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }
        public Dictionary<StateName, IState> StateDict;

        public StateMachine(GameScene scene)
        {
            StateDict = new Dictionary<StateName, IState>();
            //StateDictに代入
			StateDict[StateName.InitGame] = new InitGameState(scene);
			StateDict[StateName.StageResult] = new StageResultState(scene);
			StateDict[StateName.RollBall] = new RollBallState(scene);
			StateDict[StateName.UserWait] = new UserWaitState(scene);
			StateDict[StateName.DecideStage] = new DecideStageState(scene);
        }


        public void Initialize(StateName state)
        {
            CurrentState = StateDict[state];
            CurrentState.Enter();
        }

        public void ChangeState(StateName state)
        {
            CurrentState.Exit();
            CurrentState = StateDict[state];
            CurrentState.Enter();
        }

        public void MainUpdate()
        {
            CurrentState.MainUpdate();
        }
    }
}