using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using GridSystem.Square;
using NaughtyAttributes;

/// <summary>
/// The square grid generator that uses SquareGridSystem
/// </summary>
public class SquareGridGenerator : MonoBehaviour, IGridGenerator
{
    #region Private Field

    /// <summary>
    /// The SquareGridSystem in this generator
    /// </summary>
    private SquareGridSystem<GridDataContainer> _squareGridSystem = new SquareGridSystem<GridDataContainer>();

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
    [BoxGroup("Grid generation prefab & root")]
    public GridElement gridElementPrefab;

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

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region IGridGenerator inteface

    public void GenerateMap(int width, int height)
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
                GridElement gridElement = Instantiate(gridElementPrefab, position, Quaternion.identity, sceneObjectRoot.transform);
                gridElement.coordinate = coordinate;
                
                // add the Vertex to the GridSystem
                _squareGridSystem.AddVertex(coordinate, 0, new GridDataContainer(gridElement.gameObject));
                // add the connection with right grid
                if (x < width - 1 && _squareGridSystem.GetVertex(new GridCoordinate(x + 1, y)) != null)
                {
                    _squareGridSystem.AddDoubleEdge(coordinate, new GridCoordinate(x + 1, y), 2);
                }
                // add the connection with left grid
                if (x > 0 && _squareGridSystem.GetVertex(new GridCoordinate(x - 1, y)) != null)
                {
                    _squareGridSystem.AddDoubleEdge(coordinate, new GridCoordinate(x - 1, y), 2);
                }
                // add the connection with top grid
                if (y < height - 1 && _squareGridSystem.GetVertex(new GridCoordinate(x, y + 1)) != null)
                {
                    _squareGridSystem.AddDoubleEdge(coordinate, new GridCoordinate(x, y + 1), 2);
                }
                // add the connection with bottom grid
                if (y > 0 && _squareGridSystem.GetVertex(new GridCoordinate(x, y - 1)) != null)
                {
                    _squareGridSystem.AddDoubleEdge(coordinate, new GridCoordinate(x, y - 1), 2);
                }
            }
        }
    }

    #endregion
}
