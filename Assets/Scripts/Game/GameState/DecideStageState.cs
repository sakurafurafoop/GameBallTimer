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
			Scene.StageManager.CreateStage();
			Scene.Ball.DisplayBall();
			Scene.GameUI.OnToggleTextTime(true);
			DecideTimeGoal();
			Scene.StateMachine.ChangeState(StateName.UserWait);
		}

		private void ResetStage()
        {
			GameData.Instance.timeNow = 0;
			GameData.Instance.timeGoal = 0;
			GameData.Instance.stage++;
			Scene.GameResultUI.OffResultPanel();
			Scene.GameUI.DisplayTimeNow();
			Scene.Ball.ResetPosition();
			Scene.SliderPosition.gameObject.SetActive(false);
		}


		/// <summary>
        /// ゴールタイムを決める関数
        /// </summary>
		private void DecideTimeGoal()
        {
			if(Scene.StageManager.stageNum == 1)
            {
				GameData.Instance.timeTarget = Random.Range(2, 6);
			}
            else
            {
				GameData.Instance.timeTarget = Random.Range(6, 14);
			}
			
			Scene.GameUI.DisplayTimeGoal();
        }

		public void MainUpdate()
		{
			// MainUpdate method code here
			
		}

		public void Exit()
		{
			// Exit method code here
		}
	}
}