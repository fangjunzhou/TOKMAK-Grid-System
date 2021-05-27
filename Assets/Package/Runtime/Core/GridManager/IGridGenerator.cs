namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The generate direction of the GridGenerator
    /// Vertical generation is often used in 2D projects
    /// Horizontal generation is often used in 3D projects
    /// </summary>
    public enum GridGenerationDirection
    {
        Vertical,
        Horizontal
    }

    /// <summary>
    /// The merge direction of merge method
    /// describe the target generator direction
    /// </summary>
    public enum MergeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    
    /// <summary>
    /// The interface for a basic grid generate system
    /// Including operations like initialized the map with a certain map size
    /// </summary>
    public interface IGridGenerator<DataType> where DataType : GridDataContainer
    {
        #region Public Field

        /// <summary>
        /// the unique ID of the GridGenerator
        /// </summary>
        int generatorID { get; }
        
        /// <summary>
        /// The GridSystem of the generator
        /// </summary>
        IGridSystem<DataType> gridSystem { get; }
        
        /// <summary>
        /// The GridEventHandler of the generator
        /// </summary>
        IGridEventHandler gridEventHandler { get; }

        /// <summary>
        /// The global offset of all the Vertices in the GridSystem in current GirdGenerator
        /// </summary>
        GridCoordinate globalOffset { get; set; }

        #endregion
        
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
        /// Merge the GridSystem in current GridGenerator with GridSystem in another generator
        /// </summary>
        /// <param name="target">The target generator to merge</param>
        /// <param name="currentFrom">the start coordinate of the edge of current GridSystem</param>
        /// <param name="currentTo">the end coordinate of the edge of current GridSystem</param>
        /// <param name="direction">the merge direction</param>
        void Merge(IGridGenerator<DataType> target, GridCoordinate currentFrom, GridCoordinate currentTo, MergeDirection direction, float weight);

        /// <summary>
        /// Separate the GridSystem in current GridGenerator with GridSystem in another generator
        /// </summary>
        /// <param name="target">The target generator to separate</param>
        /// <param name="currentFrom">the start coordinate of the edge of current GridSystem</param>
        /// <param name="currentTo">the end coordinate of the edge of current GridSystem</param>
        /// <param name="direction">the separate direction</param>
        void Separate(IGridGenerator<DataType> target, GridCoordinate currentFrom, GridCoordinate currentTo,  MergeDirection direction);

        /// <summary>
        /// Remove all the vertices in the GridSystem
        /// Remove all the corresponding GameObjects
        /// </summary>
        void ClearMap();
    }
}