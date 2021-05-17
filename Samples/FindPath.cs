using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square.Generator;
using UnityEngine;

namespace FinTOKMAK.GridSystem.Square.Sample
{
    public class FindPath : MonoBehaviour
    {
        #region Private Field

        private LinkedList<Vertex<GridDataContainer>> _lastPath = new LinkedList<Vertex<GridDataContainer>>();

        #endregion
        
        #region Public Field

        public ChooseStart chooseStart;
        public ChooseEnd chooseEnd;

        public bool useAccelerationTable;

        public int randomXMin;
        public int randomXMax;
        public int randomYMin;
        public int randomYMax;

        #endregion
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        #region Public Methods

        /// <summary>
        /// Find the path from the start vertex to the end vertex
        /// </summary>
        public void OnFindPath()
        {
            // Clear
            foreach (Vertex<GridDataContainer> vertex in _lastPath)
            {
                // get the generator id of specific vertex
                int id = vertex.data.gridElement.generatorID;
                ((SampleSquareGridElement) SquareGridGenerator.Instances[id].gridElements[vertex.coordinate]).isPath = false;
            }
            
            if (chooseStart.selectedGridElement == null || chooseEnd.selectedGridElement == null)
                return;

            int startID = chooseStart.selectedGridElement.generatorID;
            int endID = chooseEnd.selectedGridElement.generatorID;
            
            // find the path
            LinkedList<Vertex<GridDataContainer>> path = SquareGridGenerator.Instances[startID].
                squareGridSystem.FindShortestPath(
                chooseStart.selectedGridElement.gridCoordinate, startID,
                chooseEnd.selectedGridElement.gridCoordinate, endID, useAccelerationTable);
            
            if (path == null)
                return;
            
            // Display
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                ((SampleSquareGridElement) vertex.data.gridElement).isPath = true;
            }
            
            // record
            _lastPath = new LinkedList<Vertex<GridDataContainer>>();
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                _lastPath.AddLast(vertex);
            }
        }

        /// <summary>
        /// Find path for multiple times and test the speed of path finding
        /// </summary>
        /// <param name="num"></param>
        public void MassiveFindPath(int num)
        {
            // Clear
            foreach (Vertex<GridDataContainer> vertex in _lastPath)
            {
                // get the generator id of specific vertex
                int id = vertex.data.gridElement.generatorID;
                ((SampleSquareGridElement) SquareGridGenerator.Instances[id].gridElements[vertex.coordinate]).isPath = false;
            }
            
            if (chooseStart.selectedGridElement == null || chooseEnd.selectedGridElement == null)
                return;

            int startID = chooseStart.selectedGridElement.generatorID;
            int endID = chooseEnd.selectedGridElement.generatorID;

            LinkedList<Vertex<GridDataContainer>> path = null;

            float startTime = Time.realtimeSinceStartup;

            // find the path multiple times
            for (int i = 0; i < num; i++)
            {
                // find the path
                path = SquareGridGenerator.Instances[startID].
                    squareGridSystem.FindShortestPath(
                        chooseStart.selectedGridElement.gridCoordinate, startID,
                        chooseEnd.selectedGridElement.gridCoordinate, endID, useAccelerationTable);
            }
            
            float endTime = Time.realtimeSinceStartup;
            
            Debug.Log("Find path " + num + " times, takes " + (endTime - startTime) + " seconds.");
            Debug.Log("Average pathfinding time: " + ((endTime - startTime)/num) + " seconds");
            
            if (path == null)
                return;
            
            // Display
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                ((SampleSquareGridElement) vertex.data.gridElement).isPath = true;
            }
            
            // record
            _lastPath = new LinkedList<Vertex<GridDataContainer>>();
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                _lastPath.AddLast(vertex);
            }
        }

        public void RandomMassive(int num)
        {
            // Clear
            foreach (Vertex<GridDataContainer> vertex in _lastPath)
            {
                // get the generator id of specific vertex
                int id = vertex.data.gridElement.generatorID;
                ((SampleSquareGridElement) SquareGridGenerator.Instances[id].gridElements[vertex.coordinate]).isPath = false;
            }
            
            if (chooseStart.selectedGridElement == null || chooseEnd.selectedGridElement == null)
                return;

            int startID = chooseStart.selectedGridElement.generatorID;
            int endID = chooseEnd.selectedGridElement.generatorID;

            LinkedList<Vertex<GridDataContainer>> path = null;

            float startTime = Time.realtimeSinceStartup;

            // find the path multiple times
            for (int i = 0; i < num; i++)
            {
                // find the path
                path = SquareGridGenerator.Instances[startID].
                    squareGridSystem.FindShortestPath(
                        new GridCoordinate(Random.Range(randomXMin, randomXMax), Random.Range(randomYMin, randomYMax)), startID,
                        chooseEnd.selectedGridElement.gridCoordinate, endID, useAccelerationTable);
            }
            
            float endTime = Time.realtimeSinceStartup;
            
            Debug.Log("Find path " + num + " times, takes " + (endTime - startTime) + " seconds.");
            Debug.Log("Average pathfinding time: " + ((endTime - startTime)/num) + " seconds");
            
            if (path == null)
                return;
            
            // Display
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                ((SampleSquareGridElement) vertex.data.gridElement).isPath = true;
            }
            
            // record
            _lastPath = new LinkedList<Vertex<GridDataContainer>>();
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                _lastPath.AddLast(vertex);
            }
        }

        #endregion
    }
}