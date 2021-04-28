using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
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

        #endregion

        #region Public Field

        /// <summary>
        /// The GameObject representation in the scene
        /// </summary>
        public GameObject gameObject
        {
            get
            {
                return _gameObject;
            }
            set
            {
                _gameObject = value;
            }
        }

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
                info += "Position: " + _gameObject.transform.position;
            }
            else
            {
                info += "There's no GameObject representation in the scene";
            }

            return info;
        }
    }
}
