using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas : MonoBehaviour
{

    [SerializeField] private int _row = 5;      // â°é≤
    [SerializeField] private int _col = 5;      // ècé≤

    private Image[,] _images;
    private int _selectRow = 0;
    private int _selectCol = 0;
    
    private void Start()
    {
        var cc = gameObject.GetComponent<GridLayoutGroup>();
        cc.constraintCount = _col;

        _images = new Image[_row, _col];
        for (int r = 0; r < _row; r++)
        {
            for (int c = 0; c < _col; c++)
            {
                var obj = new GameObject($"Cell({r}, {c}");
                obj.transform.parent = transform;

                var image = obj.AddComponent<Image>();
                if (r == 0 && c == 0) { image.color = Color.red; }
                else { image.color = Color.white; }
                _images[r, c] = image;
            
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {  _selectCol--; }// ç∂ÉLÅ[
        if (Input.GetKeyDown(KeyCode.RightArrow)) { _selectCol++; }   //  âEÉLÅ[
        if (Input.GetKeyDown(KeyCode.UpArrow)) { _selectRow--; }      //  è„ÉLÅ[
        if (Input.GetKeyDown(KeyCode.DownArrow)) { _selectRow++; }    //  â∫ÉLÅ[
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(_images[_selectRow, _selectCol]);
        }

        if(_selectCol < 0) { _selectCol = _col - 1; }   // â∫å¿ñ¢ñûÇÃâ°à⁄ìÆÇÃñhé~(ãtÉTÉCÉhÇ…à⁄ìÆ)
        if (_selectCol >= _col) { _selectCol = 0; }     // è„å¿à»è„ÇÃâ°à⁄ìÆÇÃñhé~(ãtÉTÉCÉhÇ…à⁄ìÆ)
        if (_selectRow < 0) { _selectRow = _row - 1; }  // â∫å¿ñ¢ñûÇÃècà⁄ìÆÇÃñhé~(ãtÉTÉCÉhÇ…à⁄ìÆ)
        if (_selectRow >= _row) { _selectRow = 0; }     // è„å¿à»è„ÇÃècà⁄ìÆÇÃñhé~(ãtÉTÉCÉhÇ…à⁄ìÆ)

        for (var r = 0; r < _row; r++) 
        {
            
            for (var c = 0; c < _col; c++)
            {
                if (_selectRow == r && _selectCol == c && _images[r, c] != null) 
                {
                    _images[r, c].color = Color.red;
                }
                else if(_images[r, c] != null)
                {
                    _images[r, c].color = Color.white;
                }
                
            }
        }

    }

}

