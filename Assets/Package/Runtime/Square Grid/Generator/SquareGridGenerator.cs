using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public static Dictionary<int, SquareGridGenerator> Instances = new Dictionary<int, SquareGridGenerator>();

        /// <summary>
        /// The next generated GridGenerator ID
        /// </summary>
        public static int nextGenerateID;

        #endregion
        
        #region Private Field

        /// <summary>
        /// The unique ID of current GridGenerator
        /// also the unique ID of the grid system
        /// </summary>
        private int generatorID;
        
        /// <summary>
        /// Square root of 2
        /// </summary>
        private const float SQRT_2 = 1.4142135623730950488f;

        /// <summary>
        /// The SquareGridSystem in this generator
        /// </summary>
        private SquareGridSystem<GridDataContainer> _squareGridSystem;

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
        
        [BoxGroup("Grid generation prefab & root")]
        public GridCoordinate offset;

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
            if (!Instances.Values.Contains(this))
            {
                generatorID = nextGenerateID;
                nextGenerateID++;
                Instances.Add(generatorID, this);
            }
            
            // initialize the grid system
            _squareGridSystem = new SquareGridSystem<GridDataContainer>(generatorID, offset);
            
            // create and initialize GridEventHandler
            _squareGridEventHandler = gameObject.AddComponent<SquareGridEventHandler>();
            _squareGridEventHandler.generatorID = generatorID;
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

        public void GenerateMap<ElementType> (int width, int height, float cost, GridGenerationDirection direction) 
            where ElementType: GridElement
        {
            // traverse all the grid
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // current coordinate
                    GridCoordinate coordinate = new GridCoordinate(x, y);
                    
                    // Generate a GridElement GameObject
                    Vector3 position;
                    // Vertical generation
                    if (direction == GridGenerationDirection.Vertical)
                    {
                        position = new Vector3(x * squareGridElementPrefab.width, 
                            y * squareGridElementPrefab.width, 0);
                    }
                    else
                    {
                        position = new Vector3(x * squareGridElementPrefab.width, 
                            0, y * squareGridElementPrefab.width);
                    }
                    ElementType squareGridElement = (ElementType)Instantiate(squareGridElementPrefab, position,
                        Quaternion.identity, sceneObjectRoot.transform);
                    squareGridElement.gameObject.transform.localPosition = position;
                    squareGridElement.generatorID = generatorID;
                    squareGridElement.gridCoordinate = coordinate;
                    squareGridElement.gridEventHandler = _squareGridEventHandler;
                    squareGridElement.gridDataContainer = new GridDataContainer(squareGridElement);
                    
                    // add the grid element to the _gridElements
                    _gridElements.Add(squareGridElement.gridCoordinate, squareGridElement);
                    
                    // add the Vertex to the GridSystem
                    _squareGridSystem.AddVertex(coordinate, cost, squareGridElement.gridDataContainer);
                    
                    // add the connection with the right grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x + 1, y)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate,_squareGridSystem.gridSystemID,
                            new GridCoordinate(x + 1, y),_squareGridSystem.gridSystemID, cost);
                    // add the connection with the left grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x - 1, y)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID, 
                            new GridCoordinate(x - 1, y), _squareGridSystem.gridSystemID, cost);
                    // add the connection with top grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x, y + 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID,
                            new GridCoordinate(x, y + 1), _squareGridSystem.gridSystemID, cost);
                    // add the connection with bottom grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x, y - 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID, 
                            new GridCoordinate(x, y - 1), _squareGridSystem.gridSystemID, cost);
                    // add the connection with the top left grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x - 1, y + 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID, 
                            new GridCoordinate(x - 1, y + 1), _squareGridSystem.gridSystemID, cost * SQRT_2);
                    // add the connection with the top right grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x + 1, y + 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID, 
                            new GridCoordinate(x + 1, y + 1), _squareGridSystem.gridSystemID, cost * SQRT_2);
                    // add the connection with the down left grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x - 1, y - 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID, 
                            new GridCoordinate(x - 1, y - 1), _squareGridSystem.gridSystemID, cost * SQRT_2);
                    // add the connection with the down right grid
                    if (_squareGridSystem.GetVertex(new GridCoordinate(x + 1, y - 1)) != null)
                        _squareGridSystem.SetDoubleEdge(coordinate, _squareGridSystem.gridSystemID, 
                            new GridCoordinate(x + 1, y - 1), _squareGridSystem.gridSystemID, cost * SQRT_2);
                }
            }
        }

        public void GenerateMap<ElementType>(string filePath, GridGenerationDirection direction) 
            where ElementType : GridElement
        {
            // get the list of VertexData
            List<VertexData<GridDataContainer>> vertexDatas = VertexSerializer.Deserialize<GridDataContainer>(filePath);
            // add Vertices
            foreach (VertexData<GridDataContainer> vertexData in vertexDatas)
            {
                int x = vertexData.coordinate[0];
                int y = vertexData.coordinate[1];
                // current coordinate
                GridCoordinate coordinate = new GridCoordinate(x, y);
                    
                // Generate a GridElement GameObject
                Vector3 position;
                // Vertical generation
                if (direction == GridGenerationDirection.Vertical)
                {
                    position = new Vector3(x * squareGridElementPrefab.width, 
                        y * squareGridElementPrefab.width, 0);
                }
                else
                {
                    position = new Vector3(x * squareGridElementPrefab.width, 
                        0, y * squareGridElementPrefab.width);
                }
                ElementType squareGridElement = (ElementType)Instantiate(squareGridElementPrefab, position,
                    Quaternion.identity, sceneObjectRoot.transform);
                squareGridElement.gameObject.transform.localPosition = position;
                squareGridElement.generatorID = generatorID;
                squareGridElement.gridCoordinate = coordinate;
                squareGridElement.gridEventHandler = _squareGridEventHandler;
                squareGridElement.gridDataContainer = new GridDataContainer(squareGridElement, vertexData.serializableData);
                
                // add the grid element to the _gridElements
                _gridElements.Add(squareGridElement.gridCoordinate, squareGridElement);
                    
                // add the Vertex to the GridSystem
                _squareGridSystem.AddVertex(coordinate, vertexData.cost, 
                    squareGridElement.gridDataContainer);
            }
            // add Edges
            foreach (VertexData<GridDataContainer> vertexData in vertexDatas)
            {
                GridCoordinate currentCoordinate = new GridCoordinate(vertexData.coordinate[0],
                    vertexData.coordinate[1]);
                for (int i = 0; i < vertexData.edgeCost.Length; i++)
                {
                    if (vertexData.edgeCost[i] != -1)
                    {
                        _squareGridSystem.SetEdge(currentCoordinate, 
                            _squareGridSystem.gridSystemID,
                            new GridCoordinate(vertexData.edgeTargets[i][0], vertexData.edgeTargets[i][1]), 
                            _squareGridSystem.gridSystemID,
                            vertexData.edgeCost[i]);
                    }
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
