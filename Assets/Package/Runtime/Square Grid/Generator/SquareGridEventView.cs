using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;

namespace FinTOKMAK.GridSystem.Square.Generator
{
    public class SquareGridEventView : MonoBehaviour
    {
        #region Private Field
        
        /// <summary>
        /// The singleton of SquareGridEventHandler
        /// This dictionary contains all the event handlers in the scene
        /// </summary>
        private Dictionary<int, SquareGridEventHandler> _squareGridEventHandler;
        
        /// <summary>
        /// The GameObject which is currently selected
        /// </summary>
        private GameObject _selectedGameObject;

        /// <summary>
        /// The GridElement of _selectedGameObject
        /// </summary>
        private GridElement _selectedGridElement;

        #endregion

        #region Public Field

        /// <summary>
        /// A list of ISquareGridEventResponsors that will handle the OnSelectedGridUpdated event
        /// </summary>
        [ReorderableList, InterfaceType(typeof(ISquareGridEventResponsor))]
        public MonoBehaviour[] squareGridEventResponsors;

        #endregion

        private void Start()
        {
            // get the singleton of the SquareGridEventHandler
            _squareGridEventHandler = SquareGridEventHandler.Instances;
            
            // initialize all the ISquareGridEventResponsors
            EventResponsorsInit();

            // add all the callback functions to the delegate
            foreach (ISquareGridEventResponsor eventResponsor in squareGridEventResponsors)
            {
                foreach (SquareGridEventHandler eventHandler in _squareGridEventHandler.Values.ToList())
                {
                    eventHandler.updateSelectedGrid += eventResponsor.OnSelectedGridUpdated;
                }
            }
        }

        #region Private Methods

        /// <summary>
        /// Initialize all the squareGridEventHandler of IGridEventResponsors
        /// set all the squareGridEventHandler to the event handler singleton of current object
        /// </summary>
        private void EventResponsorsInit()
        {
            foreach (ISquareGridEventResponsor eventResponsor in squareGridEventResponsors)
            {
                eventResponsor.squareGridEventHandler = _squareGridEventHandler;
            }
        }

        #endregion
    }
}