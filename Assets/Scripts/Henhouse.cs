using UnityEngine;

public class Henhouse : MonoBehaviour
{
    [SerializeField] Transform chickSpots = null;

    ChickSpot[] spots;
    float releaseTimer;

    void Start()
    {
        GetSpots();
    }

    void Update()
    {
        
    }

    void GetSpots()
    {
        spots = chickSpots.GetComponentsInChildren<ChickSpot>();
    }
}
