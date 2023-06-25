using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StageManager : MonoBehaviour
    {
        public int stageNum { get; private set; }
        [SerializeField] private Stage rightStage;
        [SerializeField] private Stage leftStage;
        private Stage[] stages;
        [SerializeField] private GameObject goal;

        private const float FIRSTX = 5;
        private const float SECONDX = 2.5f;
        private float[] positionsX;
        private const float FIRSTY = -2.4f;
        private const float SECONDY = 1f;
        private float[] positionsY;

        public void InitGame()
        {
            stages = new Stage[2] { leftStage, rightStage };
            positionsX = new float[2] { FIRSTX, SECONDX };
            positionsY = new float[2] { FIRSTY, SECONDY }; 
        }

        public void CreateStage()
        {
            stageNum = DecideStageNum();
            ShuffleStage();
            DecideDic();
            ChangeGoal();
            RotateStage();
        }

        private int DecideStageNum()
        {
            return Random.Range(1, 3);
            if (GameData.Instance.stage < 5)
            {
                return 1;
            }
            else
            {
                return Random.Range(1, 3);
            }
        }

        private void ShuffleStage()
        {
            for(int i = 0; i < stages.Length; i++)
            {
                Stage stage = stages[i];
                int randonNum = Random.Range(0, stages.Length);
                stages[i] = stages[randonNum];
                stages[randonNum] = stage;
                
            }

        }

        private void DecideDic()
        {
            for(int i = 0; i < stageNum; i++)
            {
                float xpos;
                xpos = positionsX[i] * Mathf.Sign(stages[i].transform.position.x);

                stages[i].transform.position = new Vector3(xpos, positionsY[i]);
                stages[i].gameObject.SetActive(true);
            }
            if (stageNum == 1)
            {
                stages[1].gameObject.SetActive(false);
            }
        }

        private void ChangeGoal()
        {
            goal.transform.position = new Vector3(6 * Mathf.Sign(stages[0].transform.position.x), -2.7f);
        }

        private void RotateStage()
        {
            for(int i = 0; i < stageNum; i++)
            {
                stages[i].RotateStage(i, stageNum);
            }
        }

        public int GetSize()
        {
            return stages[stageNum - 1].xSize;
        }
    }
}
