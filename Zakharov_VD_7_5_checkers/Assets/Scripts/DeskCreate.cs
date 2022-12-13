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
                }
                previousColor = previousColor == ColorType.White ? ColorType.Black : ColorType.White;
            }
        }
        
    }
}
