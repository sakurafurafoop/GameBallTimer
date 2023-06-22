using UnityEngine;

namespace Game
{
	public class StageResultState : IState
	{
		private GameScene Scene;

		public StageResultState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			Scene.GameResultUI.OnResultPanel(GetCalculateScore());
		}

		private float GetCalculateScore()
        {
			float num = GameData.Instance.timeNow - GameData.Instance.timeGoal;
			return num;
        }

		public void MainUpdate()
		{
			// MainUpdate method code here
		}

		public void Exit()
		{
			// Exit method code here
			Scene.GameResultUI.OffResultPanel();
		}
	}
}