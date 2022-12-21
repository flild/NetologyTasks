using System.Collections;
using UnityEngine;



namespace Checkers
{
    public class ChipMover : MonoBehaviour
    {
        [SerializeField] private float _chipMoveTime;
        /// <summary>
        /// Плавно перемещает фишку с одной клетки на другую
        /// </summary>
        /// <param name="_startCell">Начальная точка</param>
        /// <param name="_finishCell">Конечная точка</param>
        public IEnumerator MoveChip(CellComponent _startCell, CellComponent _finishCell, ChipComponent _chip)
        {
            float yOffset = _finishCell.transform.localScale.y / 2 + _chip.transform.localScale.y / 2;
            Vector3 startPos = _startCell.transform.position;
            Vector3 finishPos = _finishCell.transform.position + new Vector3(0, yOffset, 0);
            _startCell.Pair = null;
            _finishCell.Pair = _chip;

            
            while (Vector3.Distance(_chip.transform.position, finishPos) >0.01f)
            {
                _chip.transform.position = Vector3.Lerp(_chip.transform.position, finishPos, _chipMoveTime * Time.deltaTime);
                yield return null;
            }
        }
    }
}
