using UnityEngine;

namespace Arcanoid
{
    [RequireComponent(typeof(BaseControl))]
    public class SecondPlayerControl : MonoBehaviour
    {
        private PlayersConrol _input;

        private BaseControl _mover;

        private void Awake()
        {
            _input = new PlayersConrol();
        }
        private void OnEnable()
        {
            _input.Enable();
            //_input.Players.FirstPlayerMove.started += OnMove;

        }
        private void Start()
        {
            _mover = GetComponent<BaseControl>();
        }
        private void OnDisable()
        {
            _input.Disable();
            //_input.Players.FirstPlayerMove.started -= OnMove;
        }


        private void FixedUpdate()
        {
            var direction = _input.Players.SecondPlayerMove.ReadValue<Vector2>();
            _mover.Move(direction);
        }
    }
}
