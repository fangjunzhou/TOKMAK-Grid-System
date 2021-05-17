using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square;
using FinTOKMAK.GridSystem.Square.Generator;
using UnityEngine;
using UnityEngine.UI;

namespace FinTOKMAK.GridSystem.Square.Sample
{
    public class DrawObstacle : MonoBehaviour, ISquareGridEventResponsor
    {
        #region Private Field
        
        /// <summary>
        /// Square root of 2
        /// </summary>
        private const float SQRT_2 = 1.4142135623730950488f;

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
        /// The state of Drawing button
        /// when the button is waiting user to draw, _isDrawing is true
        /// </summary>
        private bool _isDrawing = false;

        #endregion

        #region Public Field

        public int obstacleCost;
        
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
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnSelectedGridUpdated(int ID)
        {
            // if the start button is waiting for the newly selected Grid
            if (_isDrawing)
            {
                // update the selected GameObject
                _selectedGameObject = _squareGridEventHandler[ID].currentGridObject;
                _selectedGridElement = (SampleSquareGridElement)_squareGridEventHandler[ID].currentGridElement;
                
                // change the select state of new Object
                _selectedGridElement.isObstacle = !_selectedGridElement.isObstacle;
                if (_selectedGridElement.isObstacle)
                {
                    SquareGridVertex<GridDataContainer> currentVertex = 
                        (SquareGridVertex<GridDataContainer>)SquareGridGenerator.
                            Instances[_squareGridEventHandler[ID].generatorID].squareGridSystem.
                            GetVertex(_selectedGridElement.gridCoordinate);
                    // change the cost of current selected Vertex
                    currentVertex.cost = obstacleCost;

                    GridCoordinate currentCoordinate = currentVertex.coordinate;
                    // travers four corner Vertices
                    string[] traverseList = new[] {"upLeft", "upRight", "downLeft", "downRight"};
                    foreach (string direction in traverseList)
                    {
                        // if the Edge to the certain direction do not exist
                        if (currentVertex.connection[direction] == null)
                            continue;

                        GridCoordinate toCoordinate = currentVertex.connection[direction].to;
                        int toID = currentVertex.connection[direction].toGridSystemID;
                        SampleSquareGridElement traverseElement =
                            (SampleSquareGridElement) SquareGridSystem<GridDataContainer>.Instances[toID]
                                .GetVertex(toCoordinate).data.gridElement;
                        // if the traverseGridElement is also an obstacle
                        if (traverseElement.isObstacle)
                        {
                            // set the Edge cost of opposite direction to 20
                            GridCoordinate edgeTargetA;
                            GridCoordinate edgeTargetB;
                            switch (direction)
                            {
                                // if the traverse direction is upLeft, change the edge from top to left
                                case "upLeft":
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y + 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x - 1, currentCoordinate.y);
                                    break;
                                // if the traverse direction is upRight, change the edge from top to right
                                case "upRight":
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y + 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x + 1, currentCoordinate.y);
                                    break;
                                // if the traverse direction is downLeft, change the edge from bottom to left
                                case "downLeft":
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y - 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x - 1, currentCoordinate.y);
                                    break;
                                // if the traverse direction is downRight, change the edge from bottom to right
                                default:
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y - 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x + 1, currentCoordinate.y);
                                    break;
                            }
                            SquareGridGenerator.Instances[_squareGridEventHandler[ID].generatorID].squareGridSystem.
                                SetDoubleEdge(edgeTargetA, _squareGridEventHandler[ID].generatorID, 
                                    edgeTargetB, _squareGridEventHandler[ID].generatorID, obstacleCost * SQRT_2);
                        }
                    }
                }
                else
                {
                    SquareGridVertex<GridDataContainer> currentVertex = 
                        (SquareGridVertex<GridDataContainer>)SquareGridGenerator.
                            Instances[_squareGridEventHandler[ID].generatorID].squareGridSystem.
                            GetVertex(_selectedGridElement.gridCoordinate);
                    // change the cost of current selected Vertex
                    currentVertex.cost = 1;

                    GridCoordinate currentCoordinate = currentVertex.coordinate;
                    // travers four corner Vertices
                    string[] traverseList = new[] {"upLeft", "upRight", "downLeft", "downRight"};
                    foreach (string direction in traverseList)
                    {
                        // if the Edge to the certain direction do not exist
                        if (currentVertex.connection[direction] == null)
                            continue;
                        
                        GridCoordinate toCoordinate = currentVertex.connection[direction].to;
                        int toID = currentVertex.connection[direction].toGridSystemID;
                        SampleSquareGridElement traverseElement =
                            (SampleSquareGridElement) SquareGridSystem<GridDataContainer>.Instances[toID]
                                .GetVertex(toCoordinate).data.gridElement;
                        // if the traverseGridElement is also an obstacle
                        if (traverseElement.isObstacle)
                        {
                            // set the Edge cost of opposite direction to 20
                            GridCoordinate edgeTargetA;
                            GridCoordinate edgeTargetB;
                            switch (direction)
                            {
                                // if the traverse direction is upLeft, change the edge from top to left
                                case "upLeft":
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y + 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x - 1, currentCoordinate.y);
                                    break;
                                // if the traverse direction is upRight, change the edge from top to right
                                case "upRight":
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y + 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x + 1, currentCoordinate.y);
                                    break;
                                // if the traverse direction is downLeft, change the edge from bottom to left
                                case "downLeft":
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y - 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x - 1, currentCoordinate.y);
                                    break;
                                // if the traverse direction is downRight, change the edge from bottom to right
                                default:
                                    edgeTargetA = new GridCoordinate(currentCoordinate.x, currentCoordinate.y - 1);
                                    edgeTargetB = new GridCoordinate(currentCoordinate.x - 1, currentCoordinate.y);
                                    break;
                            }
                            SquareGridGenerator.Instances[_squareGridEventHandler[ID].generatorID].squareGridSystem.
                                SetDoubleEdge(edgeTargetA, _squareGridEventHandler[ID].generatorID, 
                                    edgeTargetB, _squareGridEventHandler[ID].generatorID, 1 * SQRT_2);
                        }
                    }
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
}