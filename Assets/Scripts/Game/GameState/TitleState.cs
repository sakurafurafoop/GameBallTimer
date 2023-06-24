using UnityEngine;

namespace Game
{
	public class TitleState : IState
	{
		private GameScene Scene;

		public TitleState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			Scene.GameUI.OnActivePanelTitle(true);
		}

		public void MainUpdate()
		{
			// MainUpdate method code here
		}

		public void Exit()
		{
			// Exit method code here
			Scene.GameUI.OnActivePanelTitle(false);
		}
	}
}