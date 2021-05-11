using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The class that serialize and deserialize VertexData
    /// </summary>
    public static class VertexSerializer
    {
        #region Static Public Methods

        /// <summary>
        /// Serialize a list of VertexData
        /// </summary>
        /// <param name="dataList">the VertexData list</param>
        /// <param name="path">the file path to write</param>
        /// <typeparam name="DataType">the data type of Vertex</typeparam>
        public static void Serialize<DataType>(List<VertexData<DataType>> dataList, string path)
            where DataType : GridDataContainer
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            // if the file exists, delete the original file
            if (File.Exists(path)) File.Delete(path);
            // Create and write into the file
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            
            // serialize
            binaryFormatter.Serialize(fileStream, dataList);
            
            // close the file stream
            fileStream.Close();
        }

        /// <summary>
        /// Deserialize the VertexData list from file
        /// </summary>
        /// <param name="path">the file path to read</param>
        /// <typeparam name="DataType">the data type of Vertex</typeparam>
        /// <returns>the VertexData list</returns>
        public static List<VertexData<DataType>> Deserialize<DataType>(string path)
            where DataType : GridDataContainer
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            // Open and read the file
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            
            // deserialize
            List<VertexData<DataType>> res = (List<VertexData<DataType>>)binaryFormatter.Deserialize(fileStream);
            
            // close the file stream
            fileStream.Close();
            
            // return the result
            return res;
        }

        #endregion
    }
}