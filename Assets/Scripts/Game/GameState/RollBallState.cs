using UnityEngine;

namespace Game
{
	public class RollBallState : IState
	{
		private GameScene Scene;

		public RollBallState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			Scene.Ball.OnGravity();
			GameData.Instance.timeNow = 0;
		}

		public void MainUpdate()
		{
			// MainUpdate method code here
			GameData.Instance.timeNow += Time.deltaTime;
			Scene.GameUI.DisplayTimeNow();

            if (Scene.Ball.isGoal)
            {
				Scene.StateMachine.ChangeState(StateName.StageResult);
            }
		}

		public void Exit()
		{
			// Exit method code here
		}
	}
}