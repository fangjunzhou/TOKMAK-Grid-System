using System.Collections.Generic;
using FinTOKMAK.GridSystem.Square.Generator;

namespace FinTOKMAK.GridSystem.Square.Generator
{
    public interface ISquareGridEventResponsor
    {
        #region Public Field

        /// <summary>
        /// The squareGridEventHandler which stored the selected GameObject and GridElement
        /// initialized by the EventView
        /// </summary>
        Dictionary<int, SquareGridEventHandler> squareGridEventHandler { get; set; }

        #endregion

        #region Callback Functions
    
        /// <summary>
        /// Call when the selected GridElement and the GameObject in SquareGridEventHandler changes
        /// <param name="ID">the ID of the event handler that raise the event</param>
        /// </summary>
        void OnSelectedGridUpdated(int ID);

        #endregion
    }
}