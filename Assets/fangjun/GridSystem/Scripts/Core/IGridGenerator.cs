namespace GridSystem
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
        void GenerateMap(int width, int height);
    }
}