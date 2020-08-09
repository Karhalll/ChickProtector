using UnityEngine;
using UnityEngine.AI;

using ChickProtector.Utils;

namespace ChickProtector.Chicks
{
    public class Chick : MonoBehaviour
    {
        bool isKicked = false;

        public void Kick(float force)
        {
            Rigidbody rigidbody = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            BoxCollider boxCollider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;

            boxCollider.center = new Vector3(0f, 0.5f, 0f);
            boxCollider.isTrigger = true;
            
            rigidbody.AddForce((transform.forward + transform.up) * force);

            isKicked = true;
        }

        public void Stationed(Transform parent)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Wanderer>().enabled = false;
            
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());

            transform.parent = parent;
            transform.position = parent.position;
            transform.rotation = parent.rotation;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (isKicked && other.tag == "Ground")
            {
                Destroy(GetComponent<Rigidbody>());

                GetComponent<NavMeshAgent>().enabled = true;
                GetComponent<Wanderer>().enabled = true;
                
                isKicked = false;
            }
        }
    }
}
