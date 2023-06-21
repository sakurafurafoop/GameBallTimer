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
            //StateDictに代入
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