using System.Collections.Generic;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square.Generator;
using UnityEngine;
using UnityEngine.UI;

namespace FinTOKMAK.GridSystem.Square.Sample
{
    public class DebugChoose : MonoBehaviour, ISquareGridEventResponsor
    {
        #region Private Field

        /// <summary>
        /// A dictionary of SquareGridEventHandler, contains all the event handler in the scene
        /// </summary>
        private Dictionary<int, SquareGridEventHandler> _squareGridEventHandler;

        /// <summary>
        /// The selected GameObject
        /// </summary>
        private GameObject _gridObject;
        /// <summary>
        /// The GridElement of _gridObject
        /// </summary>
        private GridElement _gridElement;

        private bool isDebugging = true;

        #endregion

        #region Public Field

        public Text showText;

        #endregion
    
        #region Hide Public Field

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

        #region ISquareGridEventResponsor Interface

        public void OnSelectedGridUpdated(int ID)
        {
            if (isDebugging)
            {
                _gridObject = _squareGridEventHandler[ID].currentGridObject;
                _gridElement = _squareGridEventHandler[ID].currentGridElement;
                Debug.Log(SquareGridGenerator.Instances[_squareGridEventHandler[ID].generatorID].squareGridSystem.GetVertex(_gridElement.gridCoordinate).ToString());
            }
        }
    
        #endregion

        #region Public Field

        public void OnButtonClicked()
        {
            isDebugging = !isDebugging;
            if (isDebugging)
            {
                showText.text = "Debug Choose";
            }
            else
            {
                showText.text = "Debug Disabled";
            }
        }

        #endregion
    }
}