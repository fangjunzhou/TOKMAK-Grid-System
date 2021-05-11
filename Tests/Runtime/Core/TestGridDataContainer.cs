using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem;
using UnityEngine;
using NaughtyAttributes;

namespace FinTOKMAK.GridSystem.Core.Test
{
    public class TestGridDataContainer : MonoBehaviour
    {
        #region Public Field

        [BoxGroup("Exposed public field")]
        public GameObject testObject;

        #endregion

        [Button("Test the constructor of the GridDataContainer class")]
        private void TestConstructor()
        {
            // test the default constructor of GridDataContainer
            GridDataContainer dataContainer = new GridDataContainer();
            Debug.Log(dataContainer.ToString());
        
            // test the constructor with GameObject representation
            GridDataContainer dataContainer2 = new GridDataContainer(testObject);
            Debug.Log(dataContainer2.ToString());
        }
    }
}