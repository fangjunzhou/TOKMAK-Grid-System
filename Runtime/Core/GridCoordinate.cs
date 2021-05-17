using System;
using UnityEngine;

namespace FinTOKMAK.GridSystem
{
    [System.Serializable]
    public struct GridCoordinate
    {
        #region Private Field

        // The x and y components of the coordinate
        [SerializeField]
        private int _x;
        [SerializeField]
        private int _y;

        #endregion

        #region Public Field

        /// <summary>
        /// The x component of the grid coordinate
        /// </summary>
        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// The y component of the coordinate
        /// </summary>
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize the GridCoordinate with value
        /// </summary>
        /// <param name="x">the x component of the GridCoordinate</param>
        /// <param name="y">the y component of the GridCoordinate</param>
        public GridCoordinate(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generate a new hash code from two hash code
        /// </summary>
        /// <param name="hash1">first hash code</param>
        /// <param name="hash2">second hash code</param>
        /// <returns>new hash code</returns>
        private int HashCodeHelper(int hash1, int hash2)
        {
            return (((hash1 << 5) + hash1) ^ hash2);
        }

        #endregion

        /// <summary>
        /// Override the ToString method for GridCoordinate
        /// </summary>
        /// <returns>the string representation of the GridCoordinate</returns>
        public override string ToString()
        {
            string res = "";
            res += "(";
            res += _x.ToString();
            res += ", ";
            res += _y.ToString();
            res += ")";
            return res;
        }

        /// <summary>
        /// Override the Equals method of GridCoordinate
        /// </summary>
        /// <param name="obj">the target object to compare</param>
        /// <returns>true if two coordinate have the same x and y</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is GridCoordinate))
                return false;

            GridCoordinate target = (GridCoordinate)obj;
            if (this._x == target._x && this._y == target._y)
                return true;

            return false;
        }

        /// <summary>
        /// Override the GetHashCode method of GridCoordinate so that it can be used in hash table
        /// </summary>
        /// <returns>the hash code calculated from x and y values</returns>
        public override int GetHashCode()
        {
            int hash = _x.GetHashCode();
            hash = HashCodeHelper(hash, _y.GetHashCode());

            return hash;
        }
    }

}