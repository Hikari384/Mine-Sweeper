using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
    public enum CellState
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,

        //still = -2,//ñ¢äJïï
        Mine = -1,
    }

public class cell : MonoBehaviour
{


    [SerializeField] private Text _view = null;
    [SerializeField] private CellState _cellState = CellState.None;
    public Image thisCell;
    //public int status = 0;
    private bool _opend = false;

    public CellState cellState
    {
        get => _cellState;
        set
        {
            _cellState = value;
            //_cellState = (CellState)status;
            OnCellStateChanged();
        }
    }

    public bool opend
    {
        get => _opend;
        set
        {
            _opend = value;
            OnCellStateChanged();
        }
    }
   private void Start()
    {
        thisCell = GetComponent<Image>();
    }
    // Start is called before the first frame update
    private void OnValidate()
    {
       
        OnCellStateChanged();
        //Clicked();
    }

    private void OnCellStateChanged()
    {
        if(_view == null) { return; }
        
        if (_cellState == CellState.None || !_opend )
        {
            _view.text = "";
        }
        else if (_cellState == CellState.Mine )
        {
            _view.text = "Å~";
            _view.color = Color.red;
        }
        else
        {
            _view.text = ((int)_cellState).ToString();
            _view.color = Color.blue;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!_opend)
        {
            thisCell.color = new Color(0.458f, 0.921f, 0.98f, 1);

        }
        else
        {
            thisCell.color = Color.white;
        }
    }
  
}
