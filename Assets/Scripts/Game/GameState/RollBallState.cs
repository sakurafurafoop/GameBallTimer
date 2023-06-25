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
			stateTimer = 0;
			Scene.Gun.OnActiveGun(true);
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
				Scene.Gun.MoveGun();
				if (Input.GetMouseButton(0))
				{
					Scene.Gun.ParticlePlay();
				}
			}
		}

		

		public void Exit()
		{
			// Exit method code here
			Scene.Gun.OnActiveGun(false);
		}
	}
}