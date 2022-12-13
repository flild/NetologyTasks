using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class DeskCreate : MonoBehaviour
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private CellComponent _cellPrefab;
        [SerializeField] private ChipComponent _chipPrefab;
        private ColorType previousColor; 


        private void Start()
        {
            GenerateDesk();
        }
        private void GenerateDesk()
        {
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
                    previousСell.SetMaterial();
                    previousColor = previousColor == ColorType.White ? ColorType.Black : ColorType.White;

                    switch (_x)
                    {
                        case 0:
                        case 1:
                        case 2:
                            if(previousColor == ColorType.Black)
                            {
                                CreateChip(previousСell, ColorType.Black);
                            }
                        break;
                        case 5:
                        case 6:
                        case 7:
                            if (previousColor == ColorType.Black)
                            {
                                CreateChip(previousСell, ColorType.White);
                            }
                            break;
                    }
                }
                previousColor = previousColor == ColorType.White ? ColorType.Black : ColorType.White;

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
            chip.SetMaterial();
            chip.color = color;

        }
        
    }
}
