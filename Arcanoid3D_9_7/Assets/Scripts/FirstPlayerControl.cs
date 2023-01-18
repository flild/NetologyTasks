using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
namespace Arcanoid
{
    [RequireComponent(typeof(BaseControl))]
    public class FirstPlayerControl : MonoBehaviour
    {
        [SerializeField] GameObject _pauseManager;
        private PlayersConrol _input;

        private BaseControl _mover;

        private void Awake()
        {
            _input = new PlayersConrol();
        }
        private void OnEnable()
        {
            _input.Enable();
            _input.Players.Pause.performed += OnPause;

        }
        private void Start()
        {
            _mover = GetComponent<BaseControl>();
        }
        private void OnDisable()
        {
            _input.Disable();
        }
        private void OnPause(CallbackContext context)
        {
            Time.timeScale = 0f;
            _pauseManager.SetActive(true);

        }


        private void FixedUpdate()
        {
            var direction = _input.Players.FirstPlayerMove.ReadValue<Vector2>();
            _mover.Move(direction);
        }
    }
}