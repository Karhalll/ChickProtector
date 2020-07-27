using System.Collections.Generic;
using UnityEngine;

namespace ChickProtector.Chicks
{
    public class ChickKicker : MonoBehaviour
    {
        [SerializeField] float kickForce = 200f;
        [SerializeField] float timeBetwenKicks = 3f;

        float kickTimer = 0f;

        void Update()
        {
            if (kickTimer > timeBetwenKicks)
            {
                KickRandomChick();
                kickTimer = 0f;
            }

            kickTimer += Time.deltaTime;
        }

        private void KickRandomChick()
        {
            Henhouse henhouse = GetComponent<Henhouse>();

            if (!henhouse.isEmpty())
            {
                henhouse.GetRandomSlot().ReleaseChick(kickForce);
            }
            else
            {
                Debug.LogWarning(gameObject.name + ": " + henhouse.name + " is empty. No chicks to kick");
            }
        }
    }
}