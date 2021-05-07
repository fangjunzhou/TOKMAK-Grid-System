using System.Collections;
using System.Collections.Generic;
using GridSystem.Square.Generator;
using UnityEngine;

public class ChooseEnd : MonoBehaviour, ISquareGridEventResponsor
{
    #region Public Field

    public SquareGridEventHandler squareGridEventHandler { get; set; }

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ISquareGridEventResponsor Interface

    public void OnSelectedGridUpdated()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
