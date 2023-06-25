using UnityEngine;

namespace Game
{
	public class GameResultState : IState
	{
		private GameScene Scene;

		public GameResultState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			Scene.GameResultUI.OnActiveTotal(true);
		}

		public void MainUpdate()
		{
			// MainUpdate method code here
		}

		public void Exit()
		{
			// Exit method code here
			Scene.GameResultUI.OffResultPanel();
			Scene.GameResultUI.OnActiveTotal(false);
		}
	}
}