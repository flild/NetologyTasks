using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class ClickHandler : MonoBehaviour
    {

        [SerializeField] public Material currentWhiteChip;
        [SerializeField] public Material currentBlackChip;
        [SerializeField] private CameraMove _camera;

        private ChipMover _chipMover;
        private CellComponent[,] _cells;
        private PathFinder _pathFinder;
        private CellComponent previousClickedCell;
        private SideController _sideConroller;
        private WinChecker _winChecker;

        
        public void Init(CellComponent[,] cells)
        {
            _cells = cells;

            foreach(CellComponent cell in _cells)
            {
                cell.Clicked += OnCellClicked;
            }

        }
        private void Awake()
        {
            _pathFinder = new();
        }
        private void Start()
        {
            _chipMover = GetComponent<ChipMover>();
            _sideConroller = GetComponent<SideController>();
            _winChecker = GetComponent<WinChecker>();
            _winChecker.Init(_cells);
        }

        private void OnDisable()
        {
            foreach (CellComponent cell in _cells)
            {
                cell.Clicked -= OnCellClicked;
            }
        }

        private void OnCellClicked(BaseClickComponent cell)
        {
            if( !cell.isFreeToMove)
                ClearDeskSelect();
            if (cell == null) return;

            if (cell.Pair != null) 
            {
                if (cell.Pair.color != _sideConroller.GetCurrentSide())
                {
                    Debug.Log("Сейчас ходит другой игрок");
                    ClearDeskSelect();
                    return;
                }
                cell.Pair.SetMaterial(cell.Pair.color == ColorType.Black ? currentBlackChip : currentWhiteChip);
                _pathFinder.HighlightNextell(cell as CellComponent);
                previousClickedCell = cell as CellComponent;
                return;
            }
            else if(cell.isFreeToMove)
            {
                MoveChip(cell as CellComponent);
            }
            _winChecker.CheckWinnerAsync();
            ClearDeskSelect();

        }
        private void MoveChip(CellComponent cell)
        {
            StartCoroutine(_chipMover.MoveChip(previousClickedCell, cell, previousClickedCell.Pair as ChipComponent));
            var killingChip = _pathFinder.GetChipToKill();
            if (killingChip && (_pathFinder.GetCellToKill() == cell))
                killingChip.KillChip();
            _sideConroller.ChangeSide();
            StartCoroutine(_camera.MoveCamera());
            
        }
        private void ClearDeskSelect()
        {
            _pathFinder.ClearChipToKill();
            foreach ( var cell in _cells)
            {
                cell.SetMaterial();
                cell.isFreeToMove = false;
                if (cell.Pair != null) 
                    cell.Pair.SetMaterial(); 
                
            }
        }
    }
}

