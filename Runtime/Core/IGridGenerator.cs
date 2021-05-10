namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The interface for a basic grid generate system
    /// Including operations like initialized the map with a certain map size
    /// </summary>
    public interface IGridGenerator
    {
        /// <summary>
        /// Method to generate an empty map with the generator
        /// </summary>
        /// <param name="width">the width of the map</param>
        /// <param name="height">the height of the map</param>
        /// <param name="cost">the cost of edges</param>
        /// <typeparam name="ElementType"> The Generic type of GridElement for method to cast</typeparam>
        void GenerateMap<ElementType>(int width, int height, float cost) where ElementType : GridElement;

        /// <summary>
        /// Remove all the vertices in the GridSystem
        /// Remove all the corresponding GameObjects
        /// </summary>
        void ClearMap();
    }
}