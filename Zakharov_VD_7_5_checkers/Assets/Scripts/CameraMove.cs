using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private float _CameraMoveSpeed;
        [SerializeField] private DeskCreate _Desk;
        private Quaternion _startRotation;

        private void Start()
        {
            transform.position = _Desk.GetDeskCenter();
            _startRotation = transform.rotation;
        }
        public IEnumerator MoveCamera()
        {

            Quaternion end_pos = transform.rotation == _startRotation ? Quaternion.AngleAxis(180, transform.up) : _startRotation;

            while ((Quaternion.Dot(transform.rotation, end_pos) < 1f) && (Quaternion.Dot(transform.rotation, end_pos) > -1f))
            { 
                transform.rotation = Quaternion.RotateTowards(transform.rotation, end_pos, _CameraMoveSpeed*Time.deltaTime);
                yield return null;
            }

        }

    }
}