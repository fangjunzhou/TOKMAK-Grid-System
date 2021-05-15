using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace FinTOKMAK.GridSystem
{
    /// <summary>
    /// The container of all the data stored in a Vertex
    /// Can be inherited to expand the data that can be stored in a Vertex
    /// </summary>
    public class GridDataContainer
    {
        #region Private Field

        /// <summary>
        /// The GameObject representation in the scene
        /// </summary>
        private GameObject _gameObject;

        /// <summary>
        /// The GridElement component of _gameObject
        /// </summary>
        private GridElement _gridElement;

        #endregion

        #region Public Field

        /// <summary>
        /// The GameObject representation in the scene
        /// When use the set method of this property, anyGameObject can be passed in
        /// </summary>
        public GameObject gameObject
        {
            get
            {
                return _gameObject;
            }
            set
            {
                // set the _gameObject
                _gameObject = value;
            }
        }

        /// <summary>
        /// The GridElement component of _gameObject
        /// </summary>
        public GridElement gridElement
        {
            get
            {
                return _gridElement;
            }
        }

        /// <summary>
        /// Serializable data that stores in the GridDataContainer
        /// </summary>
        public ISerializable serializableData { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The basic no parameter constructor of teh GridDataContainer class
        /// the gameObject field is set to null by default
        /// </summary>
        public GridDataContainer()
        {
            _gameObject = null;
        }

        /// <summary>
        /// The one parameter constructor that initialize gameObject field for
        /// GridDataContainer
        /// </summary>
        /// <param name="gameObject">the GameObject representation of current Vertex in the scene</param>
        public GridDataContainer(GameObject gameObject)
        {
            this._gameObject = gameObject;
        }

        /// <summary>
        /// The one parameter constructor that initialize gameObject field and the gridElement field
        /// for GridDataContainer
        /// </summary>
        /// <param name="gridElement">the GridElement of the GameObject stored in the DataContainer</param>
        public GridDataContainer(GridElement gridElement)
        {
            this._gameObject = gridElement.gameObject;
            this._gridElement = gridElement;
        }

        /// <summary>
        /// The two parameter constructor that initialize gameObject field, gridElement field,
        /// and serializableData field
        /// </summary>
        /// <param name="gridElement">the GridElement of the GameObject stored in the DataContainer</param>
        /// <param name="serializableData">serializable data that will store in the GridDataContainer</param>
        public GridDataContainer(GridElement gridElement, ISerializable serializableData)
        {
            this._gameObject = gridElement.gameObject;
            this._gridElement = gridElement;
            this.serializableData = serializableData;
        }

        #endregion

        /// <summary>
        /// Get the info of data stored in current container
        /// If the gameObject field is not null, including:
        /// 1. name of the GameObject
        /// 2. Position of the GameObject
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string info = "";
            if (_gameObject != null)
            {
                info += "Name of gameObject in scene: " + _gameObject.name + "\n";
                info += "Position: " + _gameObject.transform.position + "\n";
            }
            else
            {
                info += "There's no GameObject representation in the scene";
            }

            if (serializableData != null)
            {
                info += "Serializable Data: " + serializableData.ToString();
            }
            else
            {
                info += "Serializable Data: null";
            }

            return info;
        }
    }
}
