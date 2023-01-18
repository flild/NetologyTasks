using UnityEngine;

namespace Arcanoid
{
    public class Block : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Ball _ball))
            {
                _ball.DestroyLevelBlock(gameObject);
            }

        }
    }
}
