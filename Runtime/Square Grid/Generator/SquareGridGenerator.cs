using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square;
using NaughtyAttributes;
using UnityEngine.Serialization;

namespace FinTOKMAK.GridSystem.Square.Generator
{
    
    /// <summary>
    /// The square grid generator that uses SquareGridSystem
    /// </summary>
    public class SquareGridGenerator : MonoBehaviour, IGridGenerator
    {
        #region Singleton

        /// <summary>
        /// The singleton of SquareGridGenerator
        /// </summary>
        public static SquareGridGenerator Instance;

        #endregion
        
        #region Private Field
        
        /// <summary>
        /// Square root of 2
        /// </summary>
        private const float SQRT_2 = 1.4142135623730950488f;

        /// <summary>
        /// The SquareGridSystem in this generator
        /// </summary>
        private SquareGridSystem<GridDataContainer> _squareGridSystem = new SquareGridSystem<GridDataContainer>();

        /// <summary>
        /// The SquareGridEventHandler which will be instantiate in current object
        /// This MonoBehavior component will be added to the current MapGenerator GameObject
        /// </summary>
        private SquareGridEventHandler _squareGridEventHandler;

        /// <summary>
        /// A list that stores all the GridElements
        /// </summary>
        private Dictionary<GridCoordinate, GridElement> _gridElements = new Dictionary<GridCoordinate, GridElement>();

        #endregion

        #region Public Field

        /// <summary>
        /// The root object that all the GridElements will be generate in
        /// </summary>
        [BoxGroup("Grid generation prefab & root")]
        public GameObject sceneObjectRoot;

        /// <summary>
        /// The GridElement prefab for all the grid to be generate
        /// </summary>
        [FormerlySerializedAs("gridElementPrefab")] [BoxGroup("Grid generation prefab & root")]
        public GridElement squareGridElementPrefab;

        /// <summary>
        /// The SquareGridSystem in this generator
        /// </summary>
        public SquareGridSystem<GridDataContainer> squareGridSystem
        {
            get
            {
                return _squareGridSystem;
            }
        }

        public Dictionary<GridCoordinate, GridElement> gridElements
        {
            get
            {
                return _gridElements;
            }
        }

        /// <summary>
        /// The action called when SquareGridGenerator finish the initialization of all the other child components
        /// </summary>
        public Action finishInitialize;
        

        #endregion

        private void Awake()
        {
            // initialize the singleton
            Instance = this;
            
            // create and initialize GridEventHandler
            _squareGridEventHandler = gameObject.AddComponent<SquareGridEventHandler>();
            // call the finishInitialize delegate
            finishInitialize?.Invoke();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        #region Private Methods

        

        #endregion

        #region IGridGenerator inteface

        public void GenerateMap<ElementType> (int width, int height, float cost) where ElementType: GridElement
        {
            // traverse all the grid
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // current coordinate
                    GridCoordinate coordinate = new GridCoordinate(x, y);
                    
                    // Generate a GridElement GameObject
                    Vector3 position = new Vector3(x * 115, y * 115, 0);
                    ElementType squareGridElement = (ElementType)Instantiate(squareGridElementPrefab, position, Quaternion.identity, sceneObjectRoot.transform);
                    squareGridElement.gridCoordinate = coordinate;
                    squareGridElement.gridEventHandler = _squareGridEventHandler;
                    
                    // add the grid element to the _gridElements
                    _gridElements.Add(squareGridElement.gridCoordinate, squareGridElement);
                    
                    // add the Vertex to the GridSystem
                    _squareGridSystem.AddVertex(coordinate, cost, new GridDataContainer(squareGridElement));
                    
                    // add the connection with the right grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x + 1, y)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x + 1, y), cost);
                    // add the connection with the left grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x - 1, y)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x - 1, y), cost);
                    // add the connection with top grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x, y + 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x, y + 1), cost);
                    // add the connection with bottom grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x, y - 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x, y - 1), cost);
                    // add the connection with the top left grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x - 1, y + 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x - 1, y + 1), cost * SQRT_2);
                    // add the connection with the top right grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x + 1, y + 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x + 1, y + 1), cost * SQRT_2);
                    // add the connection with the down left grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x - 1, y - 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x - 1, y - 1), cost * SQRT_2);
                    // add the connection with the down right grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x + 1, y - 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, new GridCoordinate(x + 1, y - 1), cost * SQRT_2);
                }
            }
        }

        public void ClearMap()
        {
            // Traverse all the GridElement in _gridElements
            foreach (GridElement gridElement in _gridElements.Values)
            {
                // remove the vertex in the GridSystem
                _squareGridSystem.RemoveVertex(gridElement.gridCoordinate);
                
                // destroy the GameObject
                Destroy(gridElement.gameObject);
            }
            // Clear the _gridElement List
            _gridElements.Clear();
        }

        #endregion
    }
    
}
