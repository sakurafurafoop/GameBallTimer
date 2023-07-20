using UnityEngine;
using DG.Tweening;

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
			Scene.GameResultUI.IsActiveTotal(true);
			Scene.GameResultUI.ChangeTextResultTitle("総合結果");
			Scene.AudioPlayer.PlaySE(AudioPlayer.AudioName.Result);
            if (GameData.Instance.isFall)
            {
				Scene.GameUI.DisplayTextGame("GameOver...");
				Sequence seq = DOTween.Sequence()
					.AppendInterval(0.6f)
					.AppendCallback(() =>
					{
						Scene.GameResultUI.IsActiveRound(false);
						Scene.GameResultUI.OnResultPanel();
						Scene.GameUI.DisplayTextGame(string.Empty);
					});
            }
		}

		public void MainUpdate()
		{
			// MainUpdate method code here
		}

		public void Exit()
		{
			// Exit method code here
			Scene.GameResultUI.OffResultPanel();
			Scene.GameResultUI.IsActiveTotal(false);
		}
	}
}