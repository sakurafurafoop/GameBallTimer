using UnityEngine;

namespace Game
{
	public class UserWaitState : IState
	{
		private GameScene Scene;

		public UserWaitState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			Scene.SliderPosition.ResetPositon(Scene.StageManager.GetSize());
			Scene.GameUI.OnToggleBtnOK(true);
			Scene.SliderPosition.gameObject.SetActive(true);
		}

		public void MainUpdate()
		{
			// MainUpdate method code here
			Scene.Ball.ChangePositon(Scene.SliderPosition.GetValue(), Scene.StageManager.GetSize());
		}

		public void Exit()
		{
			// Exit method code here
			Scene.GameUI.OnToggleBtnOK(false);
			Scene.SliderPosition.gameObject.SetActive(false);
		}
	}
}