using UnityEngine;

namespace FinTOKMAK.GridSystem
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
                OnCoordinateChange();
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

        /// <summary>
        /// The width of the GameObject representation of the Vertex in the scene
        /// </summary>
        public float width;

        #endregion

        #region Private Methods
        
        
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Call this method when the coordinate changes
        /// </summary>
        protected virtual void OnCoordinateChange()
        {
            
        }

        #endregion
    }
}