using UnityEngine;

namespace ChickProtector.Chicks
{
    public class Chick : MonoBehaviour
    {
        [SerializeField] bool canKick = false;
        [SerializeField] float kickForce = 200f;
 
        void Update() 
        {
            if (canKick)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Kick(kickForce);
                }
            }
        }

        public void Kick(float force)
        {
            Rigidbody rigidbody = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            rigidbody.AddForce((transform.forward + transform.up) * force);

            // TODO make chick to stap at ground
        }
    }
}
