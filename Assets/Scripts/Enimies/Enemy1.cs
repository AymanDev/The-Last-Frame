using UnityEngine;

namespace Enemies
{
    public class Enemy1 : MonoBehaviour
    {
        public GameObject damageZone;
        public AudioSource audio;

        private bool readyToShoot;
        private bool soundPlayed;

        public int timeToDie = 4;

        private void Start()
        {
            Invoke("Suicide", timeToDie);
        }

        private void Update()
        {
            if (readyToShoot) return;
            var playerPos = PlayerController.instance.transform.position;
            playerPos.y -= 2.0f;
            damageZone.transform.rotation = Quaternion.LookRotation(Vector3.forward,
                -(playerPos - transform.position).normalized);
        }

        public void ReadyToLazerEvent()
        {
            readyToShoot = true;
            audio.PlayOneShot(audio.clip, 1f);
        }

        public void ShootEvent()
        {
        }

        public void Suicide()
        {
            Destroy(gameObject);
        }
    }
}