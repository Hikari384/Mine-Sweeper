using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class lightsOut : MonoBehaviour, IPointerClickHandler
{

    private int score = 0;
    private float time;
    [SerializeField] private int _row = 5;
    [SerializeField] private int _col = 5;
    private GameObject[,] _cells;

    // Start is called before the first frame update
    void Start()
    {
        int chengeColor = 0;

        _cells = new GameObject[_row, _col];
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell{r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                var img = cell.GetComponent<Image>();
                _cells[r, c] = cell;
            
                chengeColor =Random.Range(0, 2);
                if(chengeColor == 0)
                {
                    img.color = Color.white;
                }
                else
                {
                    img.color = Color.black;
                }
            }
        }
    }

    public void OnPointerClick (PointerEventData eventData)
    {

        var cell = eventData.pointerCurrentRaycast.gameObject;
        var image = cell.GetComponent<Image>();

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {

                if(cell == _cells[r, c])
                {
                    TryswhichColor(r, c);
                    TryswhichColor(r + 1, c);
                    TryswhichColor(r - 1, c);
                    TryswhichColor(r, c + 1);
                    TryswhichColor(r, c - 1);
                }
                
            }
        }
        score++;
    }

    void TryswhichColor(int r, int c) {
        if(r < 0 || r > _row - 1)
        {
            return;
        }
        if (c < 0 || c > _col - 1)
        {
            return;
        }
        var image = _cells[r, c].GetComponent<Image>();
        image.color = image.color == Color.black ? Color.white : Color.black;
    }

    bool allAlign()
    {
        var std = _cells[0, 0].GetComponent<Image>().color;
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for(var c = 0; c < _cells.GetLength(1); c++)
            {
                var image = _cells[r, c].GetComponent<Image>();
                if (image.color != std) return false;
            }
        }
        return true;
    }
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(score);
        allAlign();
        
        Debug.Log($"{time:F0}");
    }
}
