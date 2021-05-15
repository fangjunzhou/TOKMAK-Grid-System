using System;
using FinTOKMAK.GridSystem;
using NaughtyAttributes;
using UnityEngine;

namespace Package.Runtime
{
    public class GridElementRaycastManager : MonoBehaviour
    {
        #region Public Field

        /// <summary>
        /// The layer mask for Grid Element
        /// </summary>
        [BoxGroup("Raycast Parameter")]
        public LayerMask gridElementMask;

        /// <summary>
        /// The farthest GridElement system can detect
        /// </summary>
        [BoxGroup("Raycast Parameter")]
        public float maxDetectDistance;

        #endregion

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectRayCast();
            }
        }

        #region Private Field

        private void SelectRayCast()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDetectDistance, gridElementMask))
            {
                GridElement gridElement = hit.collider.gameObject.GetComponent<GridElement>();
                if (gridElement != null)
                {
                    gridElement.SelectCurrentGridElement();
                } 
            }
        }

        #endregion
    }
}