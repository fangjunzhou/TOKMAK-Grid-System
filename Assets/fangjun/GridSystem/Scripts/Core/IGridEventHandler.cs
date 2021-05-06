using System;
using UnityEngine;

namespace GridSystem
{
    public interface IGridEventHandler
    {
        #region Public Field

        /// <summary>
        /// The GameObject that current cursor selected
        /// </summary>
        GameObject currentGridObject { get; set; }
        
        /// <summary>
        /// The event triggered when currentGridObject changes
        /// </summary>
        Action updateSelectedGrid { get; set; }

        #endregion
    }
}