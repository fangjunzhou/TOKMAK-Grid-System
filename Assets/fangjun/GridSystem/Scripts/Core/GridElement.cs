using UnityEngine;

namespace GridSystem
{
    public class GridElement : MonoBehaviour
    {
        #region Private Field

        /// <summary>
        /// The coordinate of current grid
        /// </summary>
        private protected GridCoordinate _coordinate;

        private protected IGridEventHandler _gridEventHandler;

        #endregion

        #region Public Field

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

        #endregion
    }
}