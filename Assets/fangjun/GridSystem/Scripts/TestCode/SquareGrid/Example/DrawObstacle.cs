using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem.Square.Generator;
using UnityEngine;
using UnityEngine.UI;

public class DrawObstacle : MonoBehaviour, ISquareGridEventResponsor
{
    #region Private Field

    /// <summary>
    /// The singleton of SquareGridEventHandler
    /// </summary>
    private SquareGridEventHandler _squareGridEventHandler;
        
    /// <summary>
    /// The GameObject which is currently selected
    /// </summary>
    private GameObject _selectedGameObject;

    /// <summary>
    /// The GridElement of _selectedGameObject
    /// </summary>
    private SampleSquareGridElement _selectedGridElement;

    /// <summary>
    /// The state of Drawing button
    /// when the button is waiting user to draw, _isDrawing is true
    /// </summary>
    private bool _isDrawing = false;

    #endregion

    #region Public Field
    
    /// <summary>
    /// The text showing current state
    /// </summary>
    public Text showText;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectedGridUpdated()
    {
        // if the start button is waiting for the newly selected Grid
        if (_isDrawing)
        {
            // update the selected GameObject
            _selectedGameObject = _squareGridEventHandler.currentGridObject;
            _selectedGridElement = (SampleSquareGridElement)_squareGridEventHandler.currentGridElement;
            
            // change the select state of new Object
            _selectedGridElement.isObstacle = !_selectedGridElement.isObstacle;
            if (_selectedGridElement.isObstacle)
            {
                SquareGridGenerator.Instance.squareGridSystem.GetVertex(_selectedGridElement.gridCoordinate)
                    .cost = 20;
            }
            else
            {
                SquareGridGenerator.Instance.squareGridSystem.GetVertex(_selectedGridElement.gridCoordinate)
                    .cost = 0;
            }
        }
    }
    
    /// <summary>
    /// Change the state of Drawing button
    /// </summary>
    public void OnChangeWaitingState()
    {
        _isDrawing = !_isDrawing;
        if (_isDrawing)
        {
            showText.text = "Drawing Obstacles.";
        }
        else
        {
            showText.text = "Stop Drawing.";
        }
    }
}
