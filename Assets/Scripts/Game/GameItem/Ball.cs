using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        public bool isGoal { get; private set; }

        [SerializeField] private AudioSource audioBall;
        [SerializeField] private AudioClip clipBall;
        [SerializeField] private AudioClip clipGoal;

        public void ResetPosition()
        {
            this.gameObject.transform.position = new Vector3(0, 4, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        public void ChangePositon(int xPos, int maxPos)
        {
            int pos = xPos - maxPos / 2;
            this.gameObject.transform.position = new Vector3(pos, 4, 0);
        }

        public void OnGravity()
        {
            rb.useGravity = true;
            isGoal = false;
        }

        private void OnCollisionEnter(Collision collision)
        {

            
            if (collision.gameObject.tag == "Goal")
            {
                isGoal = true;
                PlaySE(clipGoal);
            }
            else if(collision.gameObject.tag == "Stage")
            {
                PlaySE(clipBall);
            }
        }

        private void PlaySE(AudioClip clip)
        {
            audioBall.PlayOneShot(clip);
        }

        
    }
}