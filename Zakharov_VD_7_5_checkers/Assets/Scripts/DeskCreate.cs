using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Checkers
{
    [RequireComponent(typeof(ClickHandler))]
    public class DeskCreate : MonoBehaviour
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private CellComponent _cellPrefab;
        [SerializeField] private ChipComponent _chipPrefab;

        private ClickHandler _clickHandler;
        private ColorType previousColor;
        private CellComponent[,] _cells;
        



        private void Start()
        {
            GenerateDesk();
            FindCellNeighbors();
            _clickHandler = GetComponent<ClickHandler>();
            _clickHandler.Init(_cells);
        }
        private void GenerateDesk()
        {
            _cells = new CellComponent[_rows, _columns];
            CellComponent previousСell;
            float cellSize;
            previousСell = Instantiate(_cellPrefab,new Vector3(0,0,0), Quaternion.identity, transform);
            previousСell.SetDefaultMaterial(previousСell.whiteCellMaterial);
            previousСell.SetMaterial();
            previousColor = ColorType.White;
            cellSize = previousСell.transform.localScale.x;


            for (int _x=0; _x < _rows; _x++)
            {
                for (int _z = 0; _z < _columns; _z++)
                {
                    previousСell = Instantiate(_cellPrefab, new Vector3(cellSize*_x, 0, cellSize*_z), Quaternion.identity, transform);
                    previousСell.SetDefaultMaterial(previousColor == ColorType.White? previousСell.blackCellMaterial: previousСell.whiteCellMaterial);
                    _cells[_x,_z] = previousСell;
                    previousСell.coordinate = new Coordinate(_x, _z);
                    previousСell.name = _x.ToString() + _z.ToString();
                    previousColor = previousColor == ColorType.White ? ColorType.Black : ColorType.White;

                    switch (_x)
                    {
                        case 0:
                        case 1:
                        case 2:
                            if(previousColor == ColorType.Black)
                            {
                                CreateChip(previousСell, ColorType.White);
                            }
                        break;
                        case 5:
                        case 6:
                        case 7:
                            if (previousColor == ColorType.Black)
                            {
                                CreateChip(previousСell, ColorType.Black);
                            }
                            break;
                    }
                }
                previousColor = previousColor == ColorType.White ? ColorType.Black : ColorType.White;

            }
        }
        private void FindCellNeighbors()
        {
            
            for (int _x = 0; _x < _rows; _x++)
            {
                for (int _z = 0; _z < _columns; _z++)
                {
                    Dictionary<NeighborType, CellComponent> neighbors = new();
                    //Проверяем, если область проверки выходит за границы поля, то присваеваем null
                    neighbors[NeighborType.BottomLeft] = _x - 1 < 0 || _z + 1 >= _columns ? null : _cells[_x - 1, _z + 1];
                    neighbors[NeighborType.TopLeft] = _x + 1 >= _rows || _z + 1 >= _columns ? null : _cells[_x + 1, _z + 1];
                    neighbors[NeighborType.TopRight] = _x + 1 >= _rows || _z - 1 < 0 ? null : _cells[_x + 1, _z - 1];
                    neighbors[NeighborType.BottomRight] = _x - 1 < 0 || _z - 1 < 0 ? null : _cells[_x - 1, _z - 1];
                    _cells[_x, _z].Configuration(neighbors);
                }
            }
        }

        private void CreateChip(CellComponent cell, ColorType color)
        {
            ChipComponent chip = Instantiate(_chipPrefab,
                                            cell.transform.position + new Vector3(0, cell.transform.localScale.y/2, 0),
                                            Quaternion.identity, transform);
            chip.Pair = cell;
            cell.Pair = chip;
            chip.SetDefaultMaterial(color == ColorType.White ? chip.whiteChipMaterial : chip.blackChipMaterial);
            chip.color = color;

        }

        public Vector3 GetDeskCenter()
        {
            return new Vector3(_rows/2, 0, _columns/2);
        }

    }
}
