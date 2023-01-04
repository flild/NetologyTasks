using System;

using UnityEngine;
using System.Threading.Tasks;

namespace Checkers
{
    public class WinChecker : MonoBehaviour, IRecorder
    {
        private CellComponent[,] _cells;
        private bool anyBlackChip = true;
        private bool anyWhiteChip = true;
        private int _rows;
        private int _columns;
        private string blackWinMessage = "Черные выйграли!";
        private string whiteWinMessage = "Белые выйграли!";


        public event Action<ChipComponent> ChipDestroyed;//zaglushka
        public event Action<String> Step;//zaglushka
        public event Action<ColorType> GameEnded;

        public void Init(CellComponent[,] cells)
        {
            _cells = cells;
            _rows = cells.GetLength(0);
            _columns = cells.GetLength(1);
        }

        public async void CheckWinnerAsync()
        {
            for (int i = 0; i < _columns; i++)
            {
                //проверяем крайнии клетки доски, если на них фишки противоположного цвета, то победа
                if (_cells[_rows - 1, i].Pair != null && _cells[_rows - 1, i].Pair.color == ColorType.White)
                {
                    Debug.Log(whiteWinMessage);
                }
                if (_cells[0,i].Pair != null && _cells[0,i].Pair.color == ColorType.Black)
                {
                    Debug.Log(blackWinMessage);
                }
                await Task.Yield();
            }
            anyWhiteChip = false;
            anyBlackChip = false;
            foreach (var cell in _cells)
            {
                //если есть хотябы одна фишка цвета, то ставим соотвествующий флаг в true
                if (cell.Pair == null) continue;
                if (cell.Pair.color == ColorType.White)
                    anyWhiteChip = true;
                if (cell.Pair.color == ColorType.Black)
                    anyBlackChip = true;
            }
            //если хотя бы один флаг false, то объявляем победу, так как остались только фишки одного цвета
            if (anyWhiteChip && anyBlackChip)
                return;
            Debug.Log(anyWhiteChip ? blackWinMessage : whiteWinMessage);
            GameEnded.Invoke(anyWhiteChip ? ColorType.Black : ColorType.White);
        }

    }
}

