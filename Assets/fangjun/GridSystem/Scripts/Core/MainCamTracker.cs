using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinTOKMAK.GridSystem
{
    public class MainCamTracker : MonoBehaviour
    {
        #region Singleton

        public static Camera mainCamera;

        #endregion
        
        // Start is called before the first frame update
        void Awake()
        {
            mainCamera = gameObject.GetComponent<Camera>();
        }
    }
}
