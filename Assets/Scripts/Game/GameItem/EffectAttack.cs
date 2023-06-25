using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EffectAttack : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.tag == "Ball")
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(GetPowerX(other.gameObject.transform.position.x), 50));
            }
        }

        private float GetPowerX(float ballPosX)
        {
            if (this.gameObject.transform.position.x <= ballPosX)
            {
                return 50;
            }
            else
            {
                return -50;
            }
        }
    }
}