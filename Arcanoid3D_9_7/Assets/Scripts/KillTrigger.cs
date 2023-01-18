using UnityEngine;
namespace Arcanoid
{
    public class KillTrigger : MonoBehaviour
    {
        [SerializeField] public PlayerSide player { get; }

        [SerializeField] private Platform _boundPlatform;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Ball>(out Ball _ball))
            {
                _ball.SetCurrentPlatform(_boundPlatform);
                _ball.Death();
            }
        }
    }
}
