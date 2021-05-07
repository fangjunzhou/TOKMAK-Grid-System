using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using GridSystem;
using GridSystem.Square;
using GridSystem.Square.Generator;

public enum SampleSquareGridSelectState
{
    Blank,
    Start,
    End
}

public class SampleSquareGridElement : GridElement
{
    #region Private Field

    private SampleSquareGridSelectState _selectState;

    #endregion
    
    #region Public Field

    /// <summary>
    /// the GridEventHandler of the current grid element
    /// </summary>
    public SquareGridEventHandler gridEventHandler
    {
        get
        {
            return (SquareGridEventHandler)_gridEventHandler;
        }
        set
        {
            _gridEventHandler = value;
        }
    }

    /// <summary>
    /// The text that display the coordinate of current grid
    /// </summary>
    public TMP_Text coordinateText;

    /// <summary>
    /// The background image of the GridElement
    /// </summary>
    public Image backgroundImg;

    #endregion
    
    #region Hide Public Field

    /// <summary>
    /// The SelectState of current Grid
    /// </summary>
    public SampleSquareGridSelectState selectState
    {
        get
        {
            return _selectState;
        }
        set
        {
            _selectState = value;
            OnChangeSelectState();
        }
    }
    
    #endregion

    #region Private Methods

    /// <summary>
    /// Call when the SelectState is changed
    /// </summary>
    private void OnChangeSelectState()
    {
        // change the background color to different color in different cases
        switch (_selectState)
        {
            case SampleSquareGridSelectState.Blank:
                backgroundImg.color = Color.white;
                break;
            case SampleSquareGridSelectState.Start:
                backgroundImg.color = Color.yellow;
                break;
            case SampleSquareGridSelectState.End:
                backgroundImg.color = Color.green;
                break;
        }
    }

    #endregion

    #region Public Field

    /// <summary>
    /// Set the current object 
    /// </summary>
    public void SetCurrentObject()
    {
        _gridEventHandler.currentGridObject = gameObject;
    }

    #endregion

    #region GridElement

    protected override void OnCoordinateChange()
    {
        coordinateText.text = _coordinate.ToString();
    }

    #endregion
}