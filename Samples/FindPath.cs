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
            
            if (chooseStart.selectedGridElement.generatorID != chooseEnd.selectedGridElement.generatorID)
                return;

            int generatorID = chooseStart.selectedGridElement.generatorID;
            
            // find the path
            LinkedList<Vertex<GridDataContainer>> path = SquareGridGenerator.Instances[generatorID].
                squareGridSystem.FindShortestPath(
                chooseStart.selectedGridElement.gridCoordinate,
                chooseEnd.selectedGridElement.gridCoordinate);
            
            
            // Display
            foreach (Vertex<GridDataContainer> vertex in path)
            {
                ((SampleSquareGridElement) SquareGridGenerator.Instances[generatorID]
                    .gridElements[vertex.coordinate]).isPath = true;
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