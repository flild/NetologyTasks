using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class SideController : MonoBehaviour
    {
        private ColorType _currentSide = ColorType.White;

        /// <summary>
        /// Меняет активную сторону на противоположную
        /// </summary>
        public void ChangeSide()
        {
            _currentSide = _currentSide == ColorType.White ? ColorType.Black : ColorType.White;
        }
        
        /// <summary>
        /// Возращает текущую актвиную сторону
        /// </summary>
        /// <returns></returns>
        public ColorType GetCurrentSide()
        {
            return _currentSide;
        }
    }
}

