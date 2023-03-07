using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using Zenject;

namespace Ziggurat
{
    public class CameraController : MonoBehaviour
    {
        [Header("Configurable Properties")]
        [Tooltip("This is the Y offset of our focal point. 0 Means we're looking at the ground.")]
        [SerializeField] private float LookOffset;
        [Tooltip("The angle that we want the camera to be at.")]
        [SerializeField] private float CameraAngle;

        [Tooltip("How fast the camera rotates")]
        [SerializeField] private float RotationSpeed;
        [SerializeField] private float CameraSpeed;

        //Camera specific variables
        private Camera _actualCamera;
        private Vector3 _cameraPositionTarget;

        //Movement variables
        private Vector3 _moveTarget;
        private Vector3 _moveDirection = new Vector3(0, 0, 0);

        //Rotation variables
        private bool _rightMouseDown = false;
        private Quaternion _rotationTargetX;
        private Quaternion _rotationTargetZ;
        private Vector2 _mouseDelta;

        [Inject]
        private Transform _centerMap;

        private void Start()
        {
            _actualCamera = Camera.main;
            gameObject.transform.LookAt(_centerMap);
        }

        /// <summary>
        /// Sets the direction of movement based on the input provided by the player
        /// </summary>
        public void OnMove(CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            _moveDirection = new Vector3(value.x, 0, value.y);
            _moveTarget = (transform.forward * _moveDirection.z + transform.right *
                _moveDirection.x) * Time.fixedDeltaTime * CameraSpeed;

        }
        /// <summary>
        /// Sets whether the player has the right mouse button down
        /// </summary>
        /// <param name="context"></param>
        public void OnRotateToggle(CallbackContext context)
        {
            _rightMouseDown = context.ReadValue<float>() == 1;
        }
        /// <summary>
        /// Sets the rotation target quaternion if the right mouse button is pushed when the player is 
        /// moving the mouse
        /// </summary>
        /// <param name="context"></param>
        public void OnRotate(CallbackContext context)
        {
            _mouseDelta = _rightMouseDown ? context.ReadValue<Vector2>() : Vector2.zero;
            _rotationTargetX = Quaternion.AngleAxis(_mouseDelta.x * Time.deltaTime * RotationSpeed, Vector3.up);
            _rotationTargetZ = Quaternion.AngleAxis(-_mouseDelta.y * Time.deltaTime * RotationSpeed, Vector3.right);
        }
        private void LateUpdate()
        {
            transform.position += _moveTarget;
            transform.rotation *= _rotationTargetX;
            transform.rotation *= _rotationTargetZ;
        }


    }
}

