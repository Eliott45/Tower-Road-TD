using UnityEngine;

namespace Archer
{
    public class ArcherUnit : MonoBehaviour
    {
        public void Rotate(float enemyPositionX)
        {
            if (enemyPositionX - transform.position.x <= 0)
            {
                if(transform.rotation.y == 0)
                {
                    transform.Rotate(0f, 180f, 0f, Space.World);
                }
            }
            else
            {
                if (transform.rotation.y != 0) transform.Rotate(0f, -180f, 0f);
            }
        }
    }
}
