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

        /// <summary>
        /// The GridDataContainer Object in the Vertex
        /// </summary>
        private protected GridDataContainer _gridDataContainer;

        #endregion

        #region Public Field

        /// <summary>
        /// The generator ID of GridGenerator current Grid is in
        /// </summary>
        [HideInInspector]
        public int generatorID;
        
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
        /// The GridDataContainer Object in the Vertex
        /// </summary>
        public GridDataContainer gridDataContainer
        {
            get
            {
                return _gridDataContainer;
            }
            set
            {
                _gridDataContainer = value;
                OnGridDataContainerChange();
            }
        }

        /// <summary>
        /// The width of the GameObject representation of the Vertex in the scene
        /// </summary>
        public float width;

        #endregion

        #region Private Methods
        
        
        
        #endregion

        #region Public Field

        public virtual void SelectCurrentGridElement()
        {
            
        }

        #endregion

        #region Proteced Methods

        /// <summary>
        /// Call this method when the coordinate changes
        /// Suggest only use when the gridCoordinate initialize
        /// </summary>
        protected virtual void OnCoordinateChange()
        {
            
        }

        /// <summary>
        /// Call this method when gridDataContainer changes
        /// Suggest only use when the gridCoordinate initialize
        /// </summary>
        protected virtual void OnGridDataContainerChange()
        {
            
        }

        #endregion
    }
}