using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class SquareGridSystem<DataType> : IGridSystem<DataType>
    {

        #region Public Field
        #endregion

        #region Private Field
        #endregion

        #region Consttuctor
        #endregion


        #region IGridSystem interface

        public void AddDoubleEdge(GridCoordinate coordinate1, GridCoordinate coordinate2, float weight)
        {
            throw new System.NotImplementedException();
        }

        public void AddEdge(GridCoordinate start, GridCoordinate end, float weight)
        {
            throw new System.NotImplementedException();
        }

        public void AddVertex(GridCoordinate coordinate)
        {
            throw new System.NotImplementedException();
        }

        public List<Vertex<DataType>> FindShortestPath(GridCoordinate start, GridCoordinate end)
        {
            throw new System.NotImplementedException();
        }

        public float GetEdge(GridCoordinate start, GridCoordinate end)
        {
            throw new System.NotImplementedException();
        }

        public Vertex<DataType> GetVertex(GridCoordinate coordinate)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDoubleEdge(GridCoordinate coordinate1, GridCoordinate coordinate2)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveEdge(GridCoordinate start, GridCoordinate end)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveVertex(GridCoordinate coordinate)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
