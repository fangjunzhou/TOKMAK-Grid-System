using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace FinTOKMAK.GridSystem.Square.Sample
{
    public class SampleSquareGridElement3D : GridElement
    {
        #region Private Field

        private SampleSquareGridSelectState _selectState;

        private bool _isStart;
        private bool _isEnd;
        private bool _isObstacle;
        private bool _isPath;

        #endregion
        
        #region Public Field
        
        /// <summary>
        /// The text that display the coordinate of current grid
        /// </summary>
        [BoxGroup("Display")]
        public TextMesh coordinateText;

        /// <summary>
        /// The mesh renderer of current GameObject
        /// </summary>
        [BoxGroup("Display")]
        public MeshRenderer meshRenderer;

        [BoxGroup("State Material")]
        public Material blankMat;
        [BoxGroup("State Material")]
        public Material startMat;
        [BoxGroup("State Material")]
        public Material endMat;
        [BoxGroup("State Material")]
        public Material startEndMat;
        [BoxGroup("State Material")]
        public Material pathMat;

        [BoxGroup("Obstacle")]
        public GameObject obstacleRepresentation;

        #endregion

        #region Hide Public Field
        
        public bool isStart
        {
            get
            {
                return _isStart;
            }
            set
            {
                _isStart = value;
                OnChangeSelectBool();
            }
        }

        public bool isEnd
        {
            get
            {
                return _isEnd;
            }
            set
            {
                _isEnd = value;
                OnChangeSelectBool();
            }
        }

        public bool isObstacle
        {
            get
            {
                return _isObstacle;
            }
            set
            {
                _isObstacle = value;
                OnChangeSelectBool();
            }
        }

        public bool isPath
        {
            get
            {
                return _isPath;
            }
            set
            {
                _isPath = value;
                OnChangeSelectBool();
            }
        }

        #endregion
        
        #region Hide Public Field

        /// <summary>
        /// The SelectState of current Grid
        /// </summary>
        private SampleSquareGridSelectState selectState
        {
            get
            {
                return _selectState;
            }
            set
            {
                _selectState = value;
                OnChangeSelectState();
            }
        }
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Call when the SelectState is changed
        /// </summary>
        private void OnChangeSelectState()
        {
            // change the background color to different color in different cases
            switch (_selectState)
            {
                case SampleSquareGridSelectState.Blank:
                    meshRenderer.material = blankMat;
                    break;
                case SampleSquareGridSelectState.Start:
                    meshRenderer.material = startMat;
                    break;
                case SampleSquareGridSelectState.End:
                    meshRenderer.material = endMat;
                    break;
                case SampleSquareGridSelectState.Start_End:
                    meshRenderer.material = startEndMat;
                    break;
                case SampleSquareGridSelectState.Obstacle:
                    break;
                case SampleSquareGridSelectState.Path:
                    meshRenderer.material = pathMat;
                    break;
            }
        }

        /// <summary>
        /// Call when select bool changes
        /// </summary>
        private void OnChangeSelectBool()
        {
            if (_isStart && isEnd)
            {
                selectState = SampleSquareGridSelectState.Start_End;
            }
            else if (_isStart)
            {
                selectState = SampleSquareGridSelectState.Start;
            }
            else if (_isEnd)
            {
                selectState = SampleSquareGridSelectState.End;
            }
            else
            {
                if (_isPath)
                {
                    selectState = SampleSquareGridSelectState.Path;
                }
                else
                {
                    selectState = SampleSquareGridSelectState.Blank;
                }
            }
            
            // Obstacle
            if (_isObstacle)
            {
                obstacleRepresentation.SetActive(true);
            }
            else
            {
                obstacleRepresentation.SetActive(false);
            }

            CreateOrChangeSerializedData();
        }

        private void CreateOrChangeSerializedData()
        {
            if (gridDataContainer.serializableData == null)
            {
                gridDataContainer.serializableData = new SampleSquareGridElementData()
                {
                    isObstacle = _isObstacle,
                };

                return;
            }

            ((SampleSquareGridElementData) gridDataContainer.serializableData).isObstacle = _isObstacle;
        }

        #endregion

        #region Public Field

        /// <summary>
        /// Set the current object 
        /// </summary>
        public override void SelectCurrentGridElement()
        {
            gridEventHandler.currentGridObject = gameObject;
        }

        #endregion

        #region GridElement

        protected override void OnCoordinateChange()
        {
            coordinateText.text = gridCoordinate.ToString();
        }

        protected override void OnGridDataContainerChange()
        {
            if (gridDataContainer.serializableData != null)
            {
                _isObstacle = ((SampleSquareGridElementData) gridDataContainer.serializableData).isObstacle;
                OnChangeSelectBool();
            }
        }

        #endregion
    }
}
