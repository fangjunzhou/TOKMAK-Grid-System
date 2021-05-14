using System;
using UnityEngine;

namespace FinTOKMAK.GridSystem
{
    public interface IGridEventHandler
    {
        
        #region Public Field

        /// <summary>
        /// The GameObject that current cursor selected
        /// </summary>
        GameObject currentGridObject { get; set; }
        
        /// <summary>
        /// The action triggered when currentGridObject changes
        /// will get the ID of the event handler in the callback function
        /// </summary>
        Action<int> updateSelectedGrid { get; set; }

        #endregion
    }
}