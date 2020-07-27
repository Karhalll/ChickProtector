using System.Collections.Generic;

using UnityEngine;

namespace ChickProtector.Chicks
{
    public class Henhouse : MonoBehaviour
    {
        [SerializeField] int chicksAtStart = 3;
        [SerializeField] Chick chickPrefab = null;
        [SerializeField] Transform chickSlots = null;

        ChickSlot[] slots;

        void Start()
        {
            GetSlots();
            RandomlyFillSlots(chicksAtStart);
        }

        void GetSlots()
        {
            slots = chickSlots.GetComponentsInChildren<ChickSlot>();
        }

        void RandomlyFillSlots(int numberOfSpots)
        {
            List<ChickSlot> emptySlots = GetEmptySlots();

            if (numberOfSpots > emptySlots.Count)
            {
                Debug.LogWarning("More chicks to fill then empty spots in " + gameObject.name);
                numberOfSpots = emptySlots.Count;
                // TODO deal with overfloating chicks
            }

            for (int i = 0; i < numberOfSpots; i++)
            {
                ChickSlot randomSlot = emptySlots[Random.Range(0, emptySlots.Count)];

                randomSlot.DockChick(Instantiate(chickPrefab));
                emptySlots.Remove(randomSlot);
            }
        }

        List<ChickSlot> GetEmptySlots()
        {
            List<ChickSlot> emptySlots = new List<ChickSlot>();
            foreach (ChickSlot slot in slots)
            {
                if (slot.GetChick() == null)
                {
                    emptySlots.Add(slot);
                }
            }
            return emptySlots;
        }
    }
}