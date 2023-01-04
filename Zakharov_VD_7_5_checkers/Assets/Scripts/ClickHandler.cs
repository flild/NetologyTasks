using System;

using UnityEngine;


namespace Checkers
{
    public class ClickHandler : MonoBehaviour, IRecorder
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
        private IObserve _observer;

        public event Action<String> Step;

        public event Action<ColorType> GameEnded;

        public event Action<ChipComponent> ChipDestroyed;

        


        public void Init(CellComponent[,] cells)
        {
            TryGetComponent(out _observer);
            _cells = cells;

            _observer.RepeatStep += OnStepRepeat;

            foreach (CellComponent cell in _cells)
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
            _observer.RepeatStep -= OnStepRepeat;
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
                CellComponent cellToRecord = cell as CellComponent;
                Step?.Invoke(Extension.ToSerializable(cellToRecord.coordinate.ToString(),
                    _sideConroller.GetCurrentSide(), RecordType.Click));//observ
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
            Step?.Invoke(Extension.ToSerializable(previousClickedCell.coordinate.ToString()
                ,_sideConroller.GetCurrentSide(),RecordType.Move, cell.coordinate.ToString()));//observ
            var killingChip = _pathFinder.GetChipToKill();
            if (killingChip && (_pathFinder.GetCellToKill() == cell))
            {
                killingChip.KillChip();
                ChipDestroyed?.Invoke(killingChip); //observ
            }    
                
            _sideConroller.ChangeSide();
            StartCoroutine(_camera.MoveCamera());
            
        }

        private void OnStepRepeat(Coordinate cordinate)
        {
            var cell = _cells[cordinate._x, cordinate._y];
            OnCellClicked(cell);
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

