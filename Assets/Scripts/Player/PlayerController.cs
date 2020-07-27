using UnityEngine;
using UnityEngine.AI;

namespace ChickProtector.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 10f;

        NavMeshAgent navMeshAgent;

        void Awake() 
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start() 
        {
            navMeshAgent.isStopped = true;
        }

        void Update() 
        {
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
            {
                Vector3 inputDirection = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

                transform.LookAt(transform.position + inputDirection);
                navMeshAgent.Move(transform.forward * Time.deltaTime * moveSpeed);
            }
        }
    }
}
