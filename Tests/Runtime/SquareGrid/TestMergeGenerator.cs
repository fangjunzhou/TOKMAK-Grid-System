using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.GridSystem;
using FinTOKMAK.GridSystem.Square.Generator;
using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.GridSystem.Square.Test
{
    public class TestMergeGenerator : MonoBehaviour
    {
        #region Public Field

        [BoxGroup("Generators")]
        public SquareGridGenerator currentGenerator;
        [BoxGroup("Generators")]
        public SquareGridGenerator targetGenerator;

        [BoxGroup("Merge Parameters")]
        public GridCoordinate currentFrom;
        [BoxGroup("Merge Parameters")]
        public GridCoordinate currentTo;
        [BoxGroup("Merge Parameters")]
        public MergeDirection direction;
        [BoxGroup("Merge Parameters")]
        public float weight;

        #endregion

        [Button("Test the merge method in the SquareGridGenerator")]
        private void TestMerge()
        {
            currentGenerator.Merge(targetGenerator, currentFrom, currentTo, direction, weight);
        }

        [Button("Test the separate method in the SquareGridGenerator")]
        private void TestSeparate()
        {
            currentGenerator.Separate(targetGenerator, currentFrom, currentTo, direction);
        }
    }
}
