using UnityEngine;

namespace Arcanoid
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseControl : MonoBehaviour
    {
        private Rigidbody _rb;
        [SerializeField] private float _moveSpeed;


        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        public void Move(Vector2 direction)
        {
            Vector3 mover = direction.y * transform.up + direction.x * transform.right;

            _rb.AddForce(mover.normalized * _moveSpeed, ForceMode.Force);
        }
    }
}
