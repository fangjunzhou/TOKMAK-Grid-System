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
    public class SquareGridGenerator : MonoBehaviour, IGridGenerator<GridDataContainer>
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

        #region Constant Field
        
        /// <summary>
        /// Square root of 2
        /// </summary>
        private const float SQRT_2 = 1.4142135623730950488f;

        #endregion
        
        #region Private Field

        /// <summary>
        /// The unique ID of current GridGenerator
        /// also the unique ID of the grid system
        /// </summary>
        private int _generatorID;

        [SerializeField]
        [BoxGroup("Grid generation prefab & root")]
        private GridCoordinate _globalOffset;

        /// <summary>
        /// The SquareGridSystem in this generator
        /// </summary>
        private SquareGridSystem<GridDataContainer> _squareGridSystem;

        /// <summary>
        /// The SquareGridEventHandler of the current generator
        /// </summary>
        private SquareGridEventHandler _eventHandler;

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
        /// the unique ID of the GridGenerator
        /// </summary>
        public int generatorID
        {
            get
            {
                return _generatorID;
            }
        }

        /// <summary>
        /// The GridSystem of the generator
        /// </summary>
        public IGridSystem<GridDataContainer> gridSystem
        {
            get
            {
                return _squareGridSystem;
            }
        }

        
        /// <summary>
        /// The GridEventHandler of the generator
        /// </summary>
        public IGridEventHandler gridEventHandler
        {
            get
            {
                return _eventHandler;
            }
        }

        /// <summary>
        /// The global offset of all the Vertices in the GridSystem in current GirdGenerator
        /// </summary>
        public GridCoordinate globalOffset
        {
            get
            {
                return _globalOffset;
            }
            set
            {
                _globalOffset = value;
                // reset the globalOffset of the GridSystem
                _squareGridSystem.globalCoordinateOffset = value;
            }
        }


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
            if (!Instances.Values.Contains(this))
            {
                _generatorID = nextGenerateID;
                nextGenerateID++;
                Instances.Add(_generatorID, this);
            }
            
            // initialize the grid system
            _squareGridSystem = new SquareGridSystem<GridDataContainer>(_generatorID, globalOffset);
            
            // create and initialize GridEventHandler
            _squareGridEventHandler = gameObject.AddComponent<SquareGridEventHandler>();
            _squareGridEventHandler.generatorID = _generatorID;
            // call the finishInitialize delegate
            finishInitialize?.Invoke();
        }

        /// <summary>
        /// The initialize method for editor scripts
        /// </summary>
        public void EditorInitialize()
        {
            // initialize the singleton
            if (!Instances.Values.Contains(this))
            {
                _generatorID = nextGenerateID;
                nextGenerateID++;
                Instances.Add(_generatorID, this);
            }
            
            // initialize the grid system
            _squareGridSystem = new SquareGridSystem<GridDataContainer>(_generatorID, globalOffset);
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
                    squareGridElement.generatorID = _generatorID;
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
                squareGridElement.generatorID = _generatorID;
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

        /// <summary>
        /// Merge the GridSystem in current GridGenerator with GridSystem in another generator
        /// If the merge direction is up or down, the from should be on the left and to should be on the right
        /// If the merge direction is left or right, the from should be on the bottom and to should be on the top
        /// </summary>
        /// <param name="target">The target generator to merge</param>
        /// <param name="currentFrom">the start coordinate of the edge of current GridSystem</param>
        /// <param name="currentTo">the end coordinate of the edge of current GridSystem</param>
        /// <param name="direction">the merge direction</param>
        public void Merge(IGridGenerator<GridDataContainer> target, GridCoordinate currentFrom, GridCoordinate currentTo,
            MergeDirection direction, float weight)
        {
            int currentPos;
            int endPos;
            // if the MergeDirection is up or down, use the horizontal coordinate
            if (direction == MergeDirection.Down || direction == MergeDirection.Up)
            {
                currentPos = currentFrom.x;
                endPos = currentTo.x;
            }
            // if the MergeDirection is left or right, use the vertical coordinate
            else
            {
                currentPos = currentFrom.y;
                endPos = currentTo.y;
            }

            while (currentPos <= endPos)
            {
                // construct the current coordinate position
                GridCoordinate currentCoordinate;
                if (direction == MergeDirection.Down || direction == MergeDirection.Up)
                {
                    currentCoordinate = new GridCoordinate(currentPos, currentFrom.y);
                }
                else
                {
                    currentCoordinate = new GridCoordinate(currentFrom.x, currentPos);
                }
                
                // find the relative coordinate of current coordinate to the target GridSystem
                int relativeX = currentCoordinate.x + squareGridSystem.globalCoordinateOffset.x -
                                target.gridSystem.globalCoordinateOffset.x;
                int relativeY = currentCoordinate.y + squareGridSystem.globalCoordinateOffset.y -
                                target.gridSystem.globalCoordinateOffset.y;
                GridCoordinate relativeCoordinate = new GridCoordinate(relativeX, relativeY);
                GridCoordinate targetCoordinate;

                switch (direction)
                {
                    case MergeDirection.Up:
                        // merge the current Vertex and top left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the top Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the top right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        break;
                    case MergeDirection.Down:
                        // merge the current Vertex and bottom left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the bottom Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the bottom right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        break;
                    case MergeDirection.Left:
                        // merge the current Vertex and top left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the bottom left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        break;
                    case MergeDirection.Right:
                        // merge the current Vertex and top right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        // merge the current Vertex and the bottom right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.SetDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID, weight);
                        }
                        break;
                }

                // self increment current position until it reached the end position
                currentPos++;
            }
        }
        
        /// <summary>
        /// Separate the GridSystem in current GridGenerator with GridSystem in another generator
        /// </summary>
        /// <param name="target">The target generator to separate</param>
        /// <param name="currentFrom">the start coordinate of the edge of current GridSystem</param>
        /// <param name="currentTo">the end coordinate of the edge of current GridSystem</param>
        /// <param name="direction">the separate direction</param>
        public void Separate(IGridGenerator<GridDataContainer> target, GridCoordinate currentFrom, GridCoordinate currentTo,
            MergeDirection direction)
        {
            int currentPos;
            int endPos;
            // if the MergeDirection is up or down, use the horizontal coordinate
            if (direction == MergeDirection.Down || direction == MergeDirection.Up)
            {
                currentPos = currentFrom.x;
                endPos = currentTo.x;
            }
            // if the MergeDirection is left or right, use the vertical coordinate
            else
            {
                currentPos = currentFrom.y;
                endPos = currentTo.y;
            }

            while (currentPos <= endPos)
            {
                // construct the current coordinate position
                GridCoordinate currentCoordinate;
                if (direction == MergeDirection.Down || direction == MergeDirection.Up)
                {
                    currentCoordinate = new GridCoordinate(currentPos, currentFrom.y);
                }
                else
                {
                    currentCoordinate = new GridCoordinate(currentFrom.x, currentPos);
                }
                
                // find the relative coordinate of current coordinate to the target GridSystem
                int relativeX = currentCoordinate.x + squareGridSystem.globalCoordinateOffset.x -
                                target.gridSystem.globalCoordinateOffset.x;
                int relativeY = currentCoordinate.y + squareGridSystem.globalCoordinateOffset.y -
                                target.gridSystem.globalCoordinateOffset.y;
                GridCoordinate relativeCoordinate = new GridCoordinate(relativeX, relativeY);
                GridCoordinate targetCoordinate;

                switch (direction)
                {
                    case MergeDirection.Up:
                        // merge the current Vertex and top left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the top Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the top right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        break;
                    case MergeDirection.Down:
                        // merge the current Vertex and bottom left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the bottom Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the bottom right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        break;
                    case MergeDirection.Left:
                        // merge the current Vertex and top left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the bottom left Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x - 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        break;
                    case MergeDirection.Right:
                        // merge the current Vertex and top right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y + 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        // merge the current Vertex and the bottom right Vertex
                        targetCoordinate = new GridCoordinate(relativeCoordinate.x + 1, relativeCoordinate.y - 1);
                        if (target.gridSystem.GetVertex(targetCoordinate) != null)
                        {
                            squareGridSystem.RemoveDoubleEdge(currentCoordinate, squareGridSystem.gridSystemID,
                                targetCoordinate, target.gridSystem.gridSystemID);
                        }
                        break;
                }

                // self increment current position until it reached the end position
                currentPos++;
            }
        }
        
        /// <summary>
        /// Remove all the vertices in the GridSystem
        /// Remove all the corresponding GameObjects
        /// </summary>
        public void ClearMap()
        {
            // Traverse all the GridElement in _gridElements
            foreach (GridElement gridElement in _gridElements.Values)
            {
                // remove the vertex in the GridSystem
                _squareGridSystem.RemoveVertex(gridElement.gridCoordinate);
                
                // destroy the GameObject
                DestroyImmediate(gridElement.gameObject);
            }
            // Clear the _gridElement List
            _gridElements.Clear();
        }

        #endregion
    }
    
}
