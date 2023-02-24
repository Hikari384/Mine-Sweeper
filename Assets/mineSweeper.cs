using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mineSweeper : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _row = 1;
    [SerializeField] private int _col = 1;
    [SerializeField] private int _mine = 1;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup = null;
    [SerializeField] private cell _cellPrefab = null;
    private int openCellCount = 0; //クリックした回数カウント  
    

    cell[,] cells;

    private bool isPlayng = true;


    // Start is called before the first frame update
    void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _col;

        cells = new cell[_row, _col];
        

        var parent = _gridLayoutGroup.gameObject.transform;
        for (var r = 0; r < _row; r++)
        {
            for (var c = 0; c < _col; c++)
            {
                
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                cell.cellState = CellState.None; //セルの初期値設定
                cell.opend = false;
                cells[r, c] = cell;
                
            }
        }
    }

    
       
    public void OnPointerClick(PointerEventData eventData)
    {

        var cell = eventData.pointerCurrentRaycast.gameObject.GetComponent<cell>();

        if(cell != null && !cell.opend && isPlayng)
        {
  
            //cell.status = (int)cell.cellState;
            
            for (var r = 0; r < cells.GetLength(0); r++)
            {
                for (int c = 0; c < cells.GetLength(1); c++)
                {
                    if (cells[r, c] == cell)
                    {
                        
                        //ev.cellState = CellState.None;
                        if(openCellCount <= 0)
                        {
                            SetCellState(cell);
                        }
                        TryOpenCell(r, c);


                        if (cell.cellState == CellState.Mine)
                        {
                            AllOpenCell();
                            Debug.Log("ゲームオーバー");
                            isPlayng = false;
                        }

                    }
                }
            }

            int safeCellCount = _row * _col - _mine;
            if (openCellCount == safeCellCount)
            {
                Debug.Log("ゲームクリア");
                isPlayng = false;
            }


        }
        else if (cell == null)
        {
            return;
        }
        /*// Debug.Log("cell");
        //   Debug.Log("a");
        //if (cell.opend == false)
        //{
        //    Debug.Log("b");
        //}
        //if (TryCellIndex(cell, out var r, out var c))
        //{
        //    //Debug.Log(r);
        //    //Debug.Log(c);
        //    var aaa = cells[r,c].GetComponent<cell>();
        //    //if (ev == aaa)
        //    //{
        //    //}
            
        //}
        */
        /*
        for (var r = 0; r < cells.GetLength(0); r++)
        {
            for (var c = 0; c < cells.GetLength(1); c++)
            {
                cell = cells[r,c];
                //if (cell == cells[r, c])
                //{
                //    cells[r, c].cellState = CellState.None;
                //    cells[r, c].opend = true;
                //    // cell= cells[r, c];
                //    //Debug.Log("a");
                //}
                if (cell.opend == false)
                {
                    cell.cellState = CellState.None;
                    cell.status = (int)cell.cellState;
                    clickCount++;
                    cell.opend = true;
                }

               // SetCellState();
            }
        
        }
        */
        
    }
    
    private bool tryCheckMine(int r, int c)
    {
        var row = cells.GetLength(0);
        var col = cells.GetLength(1);
        if (r < 0 || r >= row || c < 0 || c >= col) { return false; }
        if (cells[r, c].cellState == CellState.Mine) { return true; }
        return false;
    }

    //r-1c-1, r-1c, r-1c+1
    //rc-1, rc, rc+1
    //r+1c-1, r+1c, r+1c+1
    private bool TryOpenCell(int r, int c)
    {
        if(r < 0 || r >= cells.GetLength(0)) { return false; }
        if(c < 0 || c >= cells.GetLength(1)) { return false; }

        var cell = cells[r, c];

        if (cell.opend) { return false; }


        cell.opend= true;
                
        if (cell.cellState == CellState.Mine)
        {
            return false;
        }

        openCellCount++;
        Debug.Log(openCellCount);



        if (cell.cellState == CellState.None)
        {
            //r-1c-1, r-1c, r-1c+1
            //rc-1, rc, rc+1
            //r+1c-1, r+1c, r+1c+1
            TryOpenCell(r - 1, c - 1);
            TryOpenCell(r - 1, c);
            TryOpenCell(r - 1, c + 1);
            TryOpenCell(r, c - 1);
            TryOpenCell(r, c + 1);
            TryOpenCell(r + 1, c - 1);
            TryOpenCell(r + 1, c);
            TryOpenCell(r + 1, c + 1);

        }

        
        return true;
        
    }

    private void SetCellState(cell clicked)
    {
        for (var i = 0; i < _mine; i++)
        {
            var r = Random.Range(0, _row);
            var c = Random.Range(0, _col);
            var cell = cells[r, c];
            if (cell.cellState == CellState.Mine || cell == clicked)
            {
                i--;
                continue;
            }
            cell.cellState= CellState.Mine;

        }
        for (var r = 0; r < _row; r++)
        {
            for (var c = 0; c < _col; c++)
            {
                var mineCount = 0;
                //if (cells[r,c].opend == true) { continue; }
                //if (cells[r,c].cellState == CellState.None) { continue; }
                if (cells[r, c].cellState == CellState.Mine){ continue; }
                if (tryCheckMine(r, c + 1))
                {
                    mineCount++;
                }
                if (tryCheckMine(r, c - 1))
                {
                    mineCount++;
                }
                if (tryCheckMine(r + 1, c - 1))
                {
                    mineCount++;
                }
                if (tryCheckMine(r + 1, c))
                {
                    mineCount++;
                }
                if (tryCheckMine(r + 1, c + 1))
                {
                    mineCount++;
                }
                if (tryCheckMine(r - 1, c - 1))
                {
                    mineCount++;
                }
                if (tryCheckMine(r - 1, c))
                {
                    mineCount++;
                }
                if (tryCheckMine(r - 1, c + 1))
                {
                    mineCount++;
                }
                cells[r,c].cellState = (CellState)mineCount;
            }
        }

    }

    private void AllOpenCell()
    {
        for(int r = 0; r < cells.GetLength(0); r++)
        {
            for(int c = 0; c < cells.GetLength(1); c++)
            {
                cells[r,c].opend= true;
            }
        }
    }

    //private bool TryCellIndex(cell cell, out int row, out int col)
    //{
    //    for(int r = 0; r < cells.GetLength(0); r++)
    //    {
    //        for(int c = 0; c < cells.GetLength(1); c++)
    //        {
    //            if (cells[r,c] == cell)
    //            {
    //                row = r;
    //                col = c;
    //                return true;
    //            }
    //        }
    //    }

    //    row = col = -1;
    //    return false;
    //}

    void Update()
    {
        
    }
}
