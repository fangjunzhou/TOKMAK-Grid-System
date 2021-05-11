namespace FinTOKMAK.GridSystem
{
    public enum GridGenerationDirection
    {
        Vertical,
        Horizontal
    }
    
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
        /// <param name="cost">the initial cost of edges</param>
        /// <param name="direction">the direction of generated map, in 2D game can be Vertical,
        /// in most 3D games should be Horizontal</param>
        /// <typeparam name="ElementType">The Generic type of GridElement for method to cast</typeparam>
        void GenerateMap<ElementType>(int width, int height, float cost, GridGenerationDirection direction) 
            where ElementType : GridElement;
        
        /// <summary>
        /// Method to generate an empty map from a file
        /// </summary>
        /// <param name="filePath">The path of the map file</param>
        /// <param name="direction">the direction of generated map, in 2D game can be Vertical,
        /// in most 3D games should be Horizontal</param>
        /// <typeparam name="ElementType">The Generic type of GridElement for method to cast</typeparam>
        void GenerateMap<ElementType>(string filePath, GridGenerationDirection direction) 
            where ElementType : GridElement;

        /// <summary>
        /// Remove all the vertices in the GridSystem
        /// Remove all the corresponding GameObjects
        /// </summary>
        void ClearMap();
    }
}