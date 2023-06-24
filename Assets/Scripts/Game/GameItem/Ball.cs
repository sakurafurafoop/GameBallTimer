using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        public bool isGoal { get; private set; }

        [SerializeField] private AudioSource audioBall;
        [SerializeField] private AudioClip clipBall;
        [SerializeField] private AudioClip clipGoal;

        [SerializeField] private MeshRenderer render;
        

        public void ResetPosition()
        {
            this.gameObject.transform.position = new Vector3(0, 4, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            render.material.SetFloat("_ClipTime", 1);
        }

        public IEnumerator DisplayBall()
        {
            for (float i = 1; i > -0.1; i -= 0.1f)
            {
                render.material.SetFloat("_ClipTime", i);
                yield return new WaitForSeconds(0.025f);
            }
        }

        public void ChangePositon(int xPos, int maxPos)
        {
            int pos = xPos - maxPos / 2;
            this.gameObject.transform.position = new Vector3(pos, 4, 0);
        }

        public void OnGravity()
        {
            rb.useGravity = true;
            rb.isKinematic = false;
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