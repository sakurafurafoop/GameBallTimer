using UnityEngine;

namespace Game
{
	public class DecideStageState : IState
	{
		private GameScene Scene;

		public DecideStageState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			ResetStage();
			DecideTimeGoal();
			DecideStage();
		}

		private void ResetStage()
        {
			GameData.Instance.timeNow = 0;
			GameData.Instance.stage++;
			Scene.GameResultUI.OffResultPanel();
			Scene.GameUI.DisplayTimeNow();
			Scene.Ball.ResetPosition();
			Scene.SliderPosition.gameObject.SetActive(false);
			Scene.Ball.StartCoroutine(Scene.Ball.DisplayBall());
        }

		private void DecideStage()
        {
			Scene.Stage.RotateStage();
			Scene.SliderPosition.ResetPositon(Scene.Stage.xSize);
		}

		/// <summary>
        /// ゴールタイムを決める関数
        /// </summary>
		private void DecideTimeGoal()
        {
			GameData.Instance.timeGoal = Random.Range(2, 6);
			Scene.GameUI.DisplayTimeGoal();
        }

		public void MainUpdate()
		{
			// MainUpdate method code here
			Scene.StateMachine.ChangeState(StateName.UserWait);
		}

		public void Exit()
		{
			// Exit method code here
		}
	}
}