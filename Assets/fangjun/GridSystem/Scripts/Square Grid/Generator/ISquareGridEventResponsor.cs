using GridSystem.Square.Generator;

namespace GridSystem.Square.Generator
{
    public interface ISquareGridEventResponsor
    {
        #region Public Field

        /// <summary>
        /// The squareGridEventHandler which stored the selected GameObject and GridElement
        /// initialized by the EventView
        /// </summary>
        SquareGridEventHandler squareGridEventHandler { get; set; }

        #endregion

        #region Callback Functions
    
        /// <summary>
        /// Call when the selected GridElement and the GameObject in SquareGridEventHandler changes
        /// </summary>
        void OnSelectedGridUpdated();

        #endregion
    }
}