using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square.Generator;
using UnityEngine;

public class DebugChoose : MonoBehaviour, ISquareGridEventResponsor
{
    #region Private Field

    private SquareGridEventHandler _squareGridEventHandler;

    /// <summary>
    /// The selected GameObject
    /// </summary>
    private GameObject _gridObject;
    /// <summary>
    /// The GridElement of _gridObject
    /// </summary>
    private GridElement _gridElement;

    #endregion
    
    #region Public Field

    public SquareGridEventHandler squareGridEventHandler
    {
        get
        {
            return _squareGridEventHandler;
        }
        set
        {
            _squareGridEventHandler = value;
        }
    }

    #endregion

    #region ISquareGridEventResponsor Interface

    public void OnSelectedGridUpdated()
    {
        _gridObject = _squareGridEventHandler.currentGridObject;
        _gridElement = _squareGridEventHandler.currentGridElement;
    }
    
    #endregion

    #region Public Field

    public void OnButtonClicked()
    {
        Debug.Log(SquareGridGenerator.Instance.squareGridSystem.GetVertex(_gridElement.gridCoordinate).ToString());
    }

    #endregion
}