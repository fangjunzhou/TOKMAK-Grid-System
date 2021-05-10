using System;
using UnityEngine;
using NaughtyAttributes;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square;
using FinTOKMAK.GridSystem.Square.Sample;

namespace FinTOKMAK.GridSystem.Square.Test
{
    public class TestSquareGridElement : MonoBehaviour
    {
        #region Public Field

        [BoxGroup("GridElement coordinate")]
        public int x;
        [BoxGroup("GridElement coordinate")]
        public int y;

        [BoxGroup("GridElement prefab")]
        public SampleSquareGridElement prefab;

        [BoxGroup("GridElelent root")]
        public GameObject root;

        #endregion

        [Button("Generate Grid")]
        private void TestGridElementGenerate()
        {
            Vector3 position = new Vector3(x * 115, y * 115, 0);
            SampleSquareGridElement sampleSquareGridElement = Instantiate(prefab, position, Quaternion.identity, root.transform);
            sampleSquareGridElement.gridCoordinate = new GridCoordinate(x, y);
        }
    }
}