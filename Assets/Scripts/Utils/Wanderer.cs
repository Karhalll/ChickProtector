using UnityEngine;
using UnityEngine.AI;

namespace ChickProtector.Utils
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Wanderer : MonoBehaviour
    {
        [Tooltip("Maximal range for random selection of next destination.")]
        [SerializeField] float maxRange = 20f;
        [Tooltip("Minimal waiting time for next destination after reaching the previous one.")]
        [SerializeField] float minTime = 2f;
        [Tooltip("Maximal waiting time for next destination after reaching the previous one.")]
        [SerializeField] float maxTime = 7f;

        float waitTimer;
        float waitTime;
        bool atDestination;

        NavMeshAgent navMeshAgent;

        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            atDestination = true;
            waitTime = Random.Range(minTime, maxTime);
        }

        void Update()
        {
            if (atDestination)
            {
                UpdateTimer();
                if (waitTimer > waitTime)
                {
                    ChangeDestination();
                    atDestination = false;
                    waitTimer = 0f;
                }
            }
            else
            {
                float distance;
                distance = Vector3.Distance(transform.position, navMeshAgent.destination);

                if (distance < 0.1f)
                {
                    waitTime = Random.Range(minTime, maxTime);
                    atDestination = true;
                }
            }
        }

        void ChangeDestination()
        {
            float randomX = Random.Range(transform.position.x - maxRange, transform.position.x + maxRange);
            float randomZ = Random.Range(transform.position.z - maxRange, transform.position.z + maxRange);
            Vector3 newRandomPosition = new Vector3(randomX, transform.position.y, randomZ);

            NavMeshHit hit;
            if (!NavMesh.SamplePosition(newRandomPosition, out hit, 4f, NavMesh.AllAreas))
            {
                NavMesh.SamplePosition(newRandomPosition, out hit, maxRange + 4f, NavMesh.AllAreas);
            }

            navMeshAgent.destination = hit.position;
        }

        void UpdateTimer()
        {
            waitTimer += Time.deltaTime;
        }
    }

}