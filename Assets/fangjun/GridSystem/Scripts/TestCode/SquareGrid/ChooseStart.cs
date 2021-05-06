using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseStart : MonoBehaviour
{
    #region Private Field

    /// <summary>
    /// The singleton of SquareGridEventHandler
    /// </summary>
    private SquareGridEventHandler _squareGridEventHandler;

    /// <summary>
    /// The state of ChooseStart button
    /// when the button is waiting user to choose a new grid, isWaitingSelect is true
    /// </summary>
    private bool _isWaitingSelect = true;

    /// <summary>
    /// The GameObject which is currently selected
    /// </summary>
    private GameObject _selectedGameObject;

    #endregion

    #region Public Field

    /// <summary>
    /// The text showing current state
    /// </summary>
    public Text showText;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        // get the singleton of the SquareGridEventHandler
        _squareGridEventHandler = SquareGridEventHandler.Instance;
        // add the callback function to the delegate
        _squareGridEventHandler.updateSelectedGrid += OnSelectedGridUpdated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Private Methods

    /// <summary>
    /// Call when the selected Grid is updated
    /// </summary>
    private void OnSelectedGridUpdated()
    {
        // if the start button is waiting for the newly selected Grid
        if (_isWaitingSelect)
        {
            // Change the select state of old Object
            if (_selectedGameObject != null)
                _selectedGameObject.GetComponent<SquareGridElement>().selectState = GridSelectState.Blank;
            
            // update the selected GameObject
            _selectedGameObject = _squareGridEventHandler.currentGridObject;
            
            // change the select state of new Object
            _selectedGameObject.GetComponent<SquareGridElement>().selectState = GridSelectState.Start;
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Change the state of ChooseStart button
    /// </summary>
    public void OnChangeWaitingState()
    {
        _isWaitingSelect = !_isWaitingSelect;
        if (_isWaitingSelect)
        {
            showText.text = "Choose start...";
        }
        else
        {
            showText.text = "Start have been chosen.";
        }
    }

    #endregion
}
