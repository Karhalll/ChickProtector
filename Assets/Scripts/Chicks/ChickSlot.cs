using UnityEngine;

namespace ChickProtector.Chicks
{
    public class ChickSlot : MonoBehaviour
    {
        Chick chick;

        public void ReleaseChick()
        {

        }

        public void DockChick(Chick chick)
        {
            this.chick = chick;
            chick.transform.position = transform.position;
            chick.transform.rotation = transform.rotation;
            chick.transform.parent = transform;
        }

        public Chick GetChick()
        {
            return chick;
        }
    }
}
