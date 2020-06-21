using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    [SerializeField] float changeDirectionTime = 5f;
    [SerializeField] float randomTargetRange = 20f;

    NavMeshAgent navMeshAgent = null;
    float timer = 0f;

    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() 
    {
        ChangeTarget();
    }

    void Update()
    {
        UpdateTimer();

        if (timer > changeDirectionTime)
        {
            ChangeTarget();
            timer = 0f;
        }
    }

    private void ChangeTarget()
    {
        float randomX = Random.Range(transform.position.x - randomTargetRange, transform.position.x + randomTargetRange);
        float randomZ = Random.Range(transform.position.z - randomTargetRange, transform.position.z + randomTargetRange);
        
        Vector3 newPosition = new Vector3(randomX, transform.position.y, randomZ);

        NavMeshHit hit;
        if (!NavMesh.SamplePosition(newPosition, out hit, 4f, NavMesh.AllAreas)) 
        {
            NavMesh.SamplePosition(newPosition, out hit, randomTargetRange + 4f, NavMesh.AllAreas);  
        }
        navMeshAgent.destination = hit.position;
    }

    private void UpdateTimer() 
    {
        timer += Time.deltaTime;
    }
}
