using UnityEngine;

namespace Game
{
	public class RollBallState : IState
	{
		private GameScene Scene;
		private float stateTimer;

		public RollBallState(GameScene scene)
		{
			Scene = scene;
		}

		public void Enter()
		{
			// Enter method code here
			Scene.Ball.OnGravity();
			GameData.Instance.timeNow = 0;
			GameData.Instance.canAccele = true;
			GameData.Instance.canBreak = true;
			GameData.Instance.isFall = false;
			Scene.GameUI.OnToggleBtnBall(true);
			Scene.GameUI.OnInteractableBtnBall(); 
			stateTimer = 0;
		}

		public void MainUpdate()
		{
			// MainUpdate method code here
            if (Scene.Ball.isGoal)
            {
				GameData.Instance.timeGoal = GameData.Instance.timeNow;
				stateTimer += Time.deltaTime;
				if(stateTimer >= GameData.DISPLAYTIME * 2 + 0.5f)
                {
					Scene.StateMachine.ChangeState(StateName.StageResult);
				}				
            }
            else
            {
				GameData.Instance.timeNow += Time.deltaTime;
				Scene.GameUI.DisplayTimeNow();
			}

            if (!GameData.Instance.canAccele)
            {
				Scene.GameUI.OffInteractableBtnAccele();

			}

            if (!GameData.Instance.canBreak)
            {
				Scene.GameUI.OffInteractableBtnBreak();

			}

            if (GameData.Instance.isFall)
            {
				Scene.StateMachine.ChangeState(StateName.GameResult);
            }
		}

		

		public void Exit()
		{
			// Exit method code here
			Scene.GameUI.OnToggleBtnBall(false);
			Scene.GameUI.OnToggleTextTime(false);
		}
	}
}