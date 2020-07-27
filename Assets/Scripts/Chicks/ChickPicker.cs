using UnityEngine;

namespace ChickProtector.Chicks
{
    public class ChickPicker : MonoBehaviour
    {
        [SerializeField] float grabDistance = 2f;
        [SerializeField] Transform slot = null;


        public void PickChick()
        {
            RaycastHit hit;
            bool hitDetect = Physics.BoxCast(transform.position, new Vector3(grabDistance * 2, grabDistance * 2, grabDistance) / 2, transform.forward, out hit, transform.rotation, grabDistance);
            if (hitDetect && hit.transform.tag == "Chick")
            {
                hit.transform.GetComponent<Chick>().Stationed(slot);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawRay(transform.position, transform.forward * grabDistance);
            Gizmos.matrix = Matrix4x4.TRS(transform.position + transform.forward * grabDistance, transform.rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(grabDistance*2, grabDistance*2, grabDistance));
        }
    }
}
