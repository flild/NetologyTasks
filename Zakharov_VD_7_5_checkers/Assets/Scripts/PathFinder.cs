using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class PathFinder : MonoBehaviour
    {
        [SerializeField] private Material nextStepSelect;
        private ChipComponent _chipToKill;
        private CellComponent _cellToKill;

        public void HighlightNextell(CellComponent selectCell)
        {
            foreach (NeighborType side in Enum.GetValues(typeof(NeighborType)))
            { 
                HighlightCell(selectCell.GetNeighbors(side), selectCell, side);
            }

        }
        private void HighlightCell(CellComponent nextCell, CellComponent SeletCell, NeighborType type)
        {
            //Если соседняя клетка существует и на ней никто стоит, то подсветить её
            if (nextCell == null) return;
            
            if (nextCell.Pair == null)
            {
                nextCell.SetMaterial(nextCell.currentCell);
                nextCell.isFreeToMove = true;
                return;
            }    
            //Сюда мы попадаем только если клетка существует и на ней стоит фишка
            //Своих не кушаем
            if (IsSameChip(SeletCell.Pair as ChipComponent, nextCell.Pair as ChipComponent)) return;
            else
            {//если следущая клетка занята противником, то проверям клетку за ним
                CellComponent nextNextCell = nextCell.GetNeighbors(type);
                if (nextNextCell == null) return;
                if (nextNextCell.Pair == null)
                {
                    nextNextCell.SetMaterial(nextNextCell.currentCell);
                    SetKillingPair(nextCell.Pair as ChipComponent,nextNextCell);
                    nextNextCell.isFreeToMove = true;
                    
                }
            }

        }
        /// <summary>
        /// Проверка находятся ли фишки в одно команде
        /// </summary>
        /// <param name="chip_1"></param>
        /// <param name="chip_2"></param>
        /// <returns></returns>
        private bool IsSameChip(ChipComponent chip_1, ChipComponent chip_2)
        {
            return chip_1.color == chip_2.color ? true : false;
        }

        public ChipComponent GetChipToKill()
        {
            ChipComponent killingChip = _chipToKill;
            _chipToKill = null;
            return killingChip;
        }
        public CellComponent GetCellToKill()
        {
            CellComponent _killingCell = _cellToKill;
            _cellToKill = null;
            return _killingCell;
        }
        public void ClearChipToKill()
        {
            _chipToKill = null;
            _cellToKill = null;
        }
        private void SetKillingPair(ChipComponent chip, CellComponent cell)
        {
            _chipToKill = chip;
            _cellToKill = cell;
        }
    }
}