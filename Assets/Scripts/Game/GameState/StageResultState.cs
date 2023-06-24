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
			GameData.Instance.totalScore += GetScore();
			GameData.Instance.isSuccess = GetIsSuccess();
			Scene.GameResultUI.OnResultPanel(GetDistance());
			Scene.GameResultUI.OnActiveRound(true);
			
		}


		private float GetDistance()
        {
			float num = GameData.Instance.timeNow - GameData.Instance.timeGoal;
			return num;
        }

		private bool GetIsSuccess()
        {
			if(Mathf.Abs(GetDistance()) <= 2)
            {
				return true;
            }
            else
            {
				return false;
            }
        }

		private int GetScore()
        {
			if (Mathf.Abs(GetDistance()) > 2) return 0;
			return (int)(-2 * Mathf.Abs(GetDistance()) + 5);
        }

		public void MainUpdate()
		{
			// MainUpdate method code here
		}

		public void Exit()
		{
			// Exit method code here
			
			Scene.GameResultUI.OnActiveRound(false);
		}
	}
}