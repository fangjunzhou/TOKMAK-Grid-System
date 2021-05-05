using UnityEngine;
using GridSystem;
using TMPro;

public class SquareGridElement : GridElement
{
    #region Public Field

    /// <summary>
    /// the coordinate of current grid
    /// </summary>
    public GridCoordinate coordinate
    {
        get
        {
            return _coordinate;
        }
        set
        {
            _coordinate = value;
            UpdateCoordinateText(_coordinate);
        }
    }

    /// <summary>
    /// The text that display the coordinate of current grid
    /// </summary>
    public TMP_Text coordinateText;

    #endregion

    #region Private Methods

    /// <summary>
    /// Update the text that display current coordinate
    /// </summary>
    private void UpdateCoordinateText(GridCoordinate coordinate)
    {
        coordinateText.text = coordinate.ToString();
    }

    #endregion

}