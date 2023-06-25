using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private ParticleSystem particle;
        public void OnActiveGun(bool isActive)
        {
            this.gameObject.SetActive(isActive);
        }

        public void MoveGun()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            if (Mathf.Abs(worldPos.x) > 6) return;
            if (worldPos.y < -1 || worldPos.y > 2) return;
            this.gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        }

        public void ParticlePlay()
        {
            if (particle.isPlaying) return;
            particle.Play();
        }
    }
}