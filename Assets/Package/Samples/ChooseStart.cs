using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square.Generator;
using UnityEngine;
using UnityEngine.UI;

namespace FinTOKMAK.GridSystem.Square.Sample
{
    public class ChooseStart : MonoBehaviour, ISquareGridEventResponsor
    {
        #region Private Field

        /// <summary>
        /// The singleton of SquareGridEventHandler
        /// </summary>
        private Dictionary<int, SquareGridEventHandler> _squareGridEventHandler;
            
        /// <summary>
        /// The GameObject which is currently selected
        /// </summary>
        private GameObject _selectedGameObject;

        /// <summary>
        /// The GridElement of _selectedGameObject
        /// </summary>
        private SampleSquareGridElement _selectedGridElement;

        /// <summary>
        /// The state of ChooseStart button
        /// when the button is waiting user to choose a new grid, isWaitingSelect is true
        /// </summary>
        private bool _isWaitingSelect = true;

        #endregion

        #region Public Field

        /// <summary>
        /// The text showing current state
        /// </summary>
        public Text showText;

        public Dictionary<int, SquareGridEventHandler> squareGridEventHandler
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

        #region Hide Public Field

        public SampleSquareGridElement selectedGridElement
        {
            get
            {
                return _selectedGridElement;
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

        #region Private Methods
        
        public void OnSelectedGridUpdated(int ID)
        {
            // if the start button is waiting for the newly selected Grid
            if (_isWaitingSelect)
            {
                // Change the select state of old Object
                if (_selectedGridElement != null)
                    _selectedGridElement.isStart = false;
                
                // update the selected GameObject
                _selectedGameObject = _squareGridEventHandler[ID].currentGridObject;
                _selectedGridElement = (SampleSquareGridElement)_squareGridEventHandler[ID].currentGridElement;
                
                // change the select state of new Object
                _selectedGridElement.isStart = true;
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
}
