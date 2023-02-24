using UnityEngine;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour
{
    
    [SerializeField] private Color _nomalCell = Color.white;
    [SerializeField] private Color _selectedCell = Color.cyan;
    [SerializeField] private Sprite _circle = null;
    [SerializeField] private Sprite _cross = null;
    
    private const int Size = 3;
    private int _selectedRow;
    private int _selectedCol;
     bool roll = false;
    bool win = false;

    private Image[,] _cells;
    
    // Start is called before the first frame update
    void Start()
    {
        _cells = new Image[Size, Size];
        for (var r = 0; r <_cells.GetLength(0); r++)
        {
            for(var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r},{c})");
                cell.transform.parent = transform;
                var image = cell.AddComponent<Image>();
                _cells[r, c] = image;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var blank = GetComponent<Image>();
        var image = _cells[_selectedRow, _selectedCol];
        //var image = cell.GetComponent<Image>();

        if (Input.GetKeyUp(KeyCode.LeftArrow)) { _selectedCol--; }
        if (Input.GetKeyUp(KeyCode.RightArrow)) { _selectedCol++; }
        if (Input.GetKeyUp(KeyCode.UpArrow)) { _selectedRow--; }
        if (Input.GetKeyUp(KeyCode.DownArrow)) { _selectedRow++; }

        if (_selectedCol < 0) { _selectedCol = 0; }
        if (_selectedCol >= Size) { _selectedCol = Size - 1; }
        if (_selectedRow < 0) { _selectedRow = 0; }
        if (_selectedRow >= Size) { _selectedRow = Size - 1; }

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var image1 = _cells[r, c];
                //var image1 = cell1.GetComponent<Image>();
                image1.color = (r == _selectedRow && c == _selectedCol) ? _selectedCell : _nomalCell;
            }
        }
        if (roll == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && image.sprite != _circle)
            {
                image.sprite = _cross;
                roll = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && image.sprite != _cross)
            {
                image.sprite = _circle;
                roll = true;
            }
            /*èüóòèåè
             * 1.ècÇ…3Ç¬ÇªÇÎÇ§
             * 2.â°Ç…3Ç¬ÇªÇÎÇ§
             * 3.éŒÇﬂÇ…3Ç¬ÇªÇÎÇ§
             */
            var sprites = new Sprite[Size];
            var spr = new Sprite[Size];
            var spr2 = new Sprite[Size];
            var spr4 = new Sprite[Size];
            for (var r = 0; r < _cells.GetLength(0); r++)
            {
                for (var c = 0; c < _cells.GetLength(1); c++)
                {
                    sprites[c] = _cells[r, c].sprite;
                    spr[c] = _cells[c, r].sprite;
                }
                winchecker(sprites);
                winchecker(spr);
                spr2[r] = _cells[r, r].sprite;
                spr4[r] = _cells[r, _cells.GetLength(1) - 1 - r].sprite;
            }
            winchecker(spr2);
            winchecker(spr4);


        }
    }
    bool winchecker(Sprite[] _sprite) 
    {
        if (_sprite[0] != _circleÅ@&& _sprite[0] != _cross) return false;
        for(var i = 0; i < _sprite.Length - 1; i++)
        {
            if (_sprite[i] != _sprite[i + 1])
            {
                return false;
            }
        }

        if (_sprite[0] == _circle)
        {
            Debug.Log("ÅZÇÃèüÇø");
        }
        else
        {
            Debug.Log("Å~ÇÃèüÇø");
        }
        return true;
    }
}

