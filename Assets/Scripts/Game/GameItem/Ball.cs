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

        private const float ACCELEPOWER = 180;
        private const float BREAKPOWER = 20;
        private const float BREAKTIME = 1.2f;

        private bool isTouchStage;
        private GameObject touchStage;
        

        public void ResetPosition()
        {
            this.gameObject.transform.position = new Vector3(0, 4, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            render.material.SetFloat("_ClipTime", 1);
            isTouchStage = false;
        }

        public void DisplayBall()
        {
            float clipTime = 1;
            DOTween.To(x => clipTime = x, 1, 0, GameData.DISPLAYTIME)
                .OnUpdate(() => render.material.SetFloat("_ClipTime", clipTime))
                .SetEase(Ease.Linear);

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
                NoDisplayBall();
            }
            else if(collision.gameObject.tag == "Stage")
            {
                PlaySE(clipBall);
                isTouchStage = true;
                touchStage = collision.gameObject;
            }
            else if(collision.gameObject.tag == "Fall")
            {
                GameData.Instance.isFall = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Stage")
            {
                isTouchStage = false;
            }
        }


        public void NoDisplayBall()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(new Vector3(0, 300));
            float clipTime = 0;
            DOTween.To(x => clipTime = x, 0, 1, GameData.DISPLAYTIME * 1.5f)
                .OnUpdate(() => render.material.SetFloat("_ClipTime", clipTime))
                .OnComplete(() => rb.isKinematic = true)
                .SetEase(Ease.Linear);
            
        }

        private void PlaySE(AudioClip clip)
        {
            audioBall.PlayOneShot(clip);
        }

        public void OnClickAcceleration()
        {
            GameData.Instance.canAccele = false;
            Vector3 force;
            if (isTouchStage)
            {
                if(Mathf.Sign(touchStage.transform.rotation.z) == 1)
                {
                    force = Vector3.left * ACCELEPOWER;
                }
                else
                {
                    force = Vector3.right * ACCELEPOWER;
                }
            }
            else
            {
                force = rb.velocity.normalized * ACCELEPOWER;
            }
            rb.AddForce(force);
        }

        public void OnClickBreak()
        {
            GameData.Instance.canBreak = false;
            rb.angularDrag = BREAKPOWER;
            float anguler = BREAKPOWER;
            DOTween.To(x => anguler = x, BREAKPOWER, 0.05f, BREAKTIME)
                .OnUpdate(() => rb.angularDrag = anguler);
        }
    }
}