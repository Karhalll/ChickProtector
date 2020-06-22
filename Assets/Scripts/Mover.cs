using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    [SerializeField] float maxRandomTargetRange = 20f;
    [SerializeField] float minChangeDirectionTime = 2f;
    [SerializeField] float maxChangeDirectionTime = 7f;

    NavMeshAgent navMeshAgent = null;

    float waitTimer = 0f;
    float waitTime;

    bool hasReachedDestination = false;

    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() 
    {
        waitTime = minChangeDirectionTime;
        ChangeTarget();
    }

    void Update()
    {
        float distanceFromDestination;
        distanceFromDestination = Vector3.Distance(transform.position, navMeshAgent.destination);

        if (distanceFromDestination < 0.1f && !hasReachedDestination)
        {
            waitTime = Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
            hasReachedDestination = true;
        }
        if (distanceFromDestination < 0.1f)
        {
            UpdateTimer();
        }

        if (waitTimer > waitTime)
        {
            ChangeTarget();
            hasReachedDestination = false;
            waitTimer = 0f;
        }
    }

    private void ChangeTarget()
    {
        float randomX = Random.Range(
            transform.position.x - maxRandomTargetRange, 
            transform.position.x + maxRandomTargetRange
        );
        float randomZ = Random.Range(
            transform.position.z - maxRandomTargetRange, 
            transform.position.z + maxRandomTargetRange
        );
        
        Vector3 newRandomPosition = new Vector3(randomX, transform.position.y, randomZ);

        NavMeshHit hit;
        if (!NavMesh.SamplePosition(newRandomPosition, out hit, 4f, NavMesh.AllAreas)) 
        {
            if (!NavMesh.SamplePosition(newRandomPosition, out hit, maxRandomTargetRange + 4f, NavMesh.AllAreas))
            {
                print(gameObject.name + "Path not found");
            }
        }
        navMeshAgent.destination = hit.position;
    }

    private void UpdateTimer() 
    {
        waitTimer += Time.deltaTime;
    }
}
