using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameScene : MonoBehaviour
    {
        private StateMachine stateMachine;
        public StateMachine StateMachine => stateMachine;

        private void Awake()
        {
            stateMachine = new StateMachine(this);

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

