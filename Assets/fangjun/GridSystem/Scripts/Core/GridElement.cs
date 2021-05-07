using UnityEngine;

namespace GridSystem
{
    /// <summary>
    /// The GridElement class that attach to GameObject representation of Vertex
    /// in the scene
    /// contain the coordinate of the vertex(Grid), reference to GridEventHandler
    /// </summary>
    public class GridElement : MonoBehaviour
    {
        #region Private Field

        /// <summary>
        /// The coordinate of current grid
        /// </summary>
        private protected GridCoordinate _coordinate;

        /// <summary>
        /// The GridEventHandler of current grid
        /// </summary>
        private protected IGridEventHandler _gridEventHandler;

        #endregion

        #region Public Field
        
        /// <summary>
        /// The coordinate of current grid
        /// </summary>
        public GridCoordinate gridCoordinate
        {
            get
            {
                return _coordinate;
            }
            set
            {
                _coordinate = value;
            }
        }

        /// <summary>
        /// The GridEventHandler of current grid
        /// </summary>
        public IGridEventHandler gridEventHandler
        {
            get
            {
                return _gridEventHandler;
            }
            set
            {
                _gridEventHandler = value;
            }
        }

        #endregion
    }
}