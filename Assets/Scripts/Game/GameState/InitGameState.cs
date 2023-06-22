using UnityEngine;

namespace Game
{
	public class InitGameState : IState
	{
		private GameScene Scene;

		public InitGameState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			InitGame();
		}

		private void InitGame()
        {
			GameData.Instance.totalScore = 0;
        }

		public void MainUpdate()
		{
			// MainUpdate method code here
			Scene.StateMachine.ChangeState(StateName.DecideStage);
		}

		public void Exit()
		{
			// Exit method code here
		}
	}
}