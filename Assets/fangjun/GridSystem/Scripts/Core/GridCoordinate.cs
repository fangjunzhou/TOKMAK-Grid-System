namespace GridSystem
{
    public class GridCoordinate
    {
        #region Private Field

        // The x and y components of the coordinate
        private int m_x;
        private int m_y;

        #endregion

        #region Public Field

        /// <summary>
        /// The x component of the grid coordinate
        /// </summary>
        public int x
        {
            get
            {
                return m_x;
            }
            set
            {
                m_x = value;
            }
        }

        /// <summary>
        /// The y component of the coordinate
        /// </summary>
        public int y
        {
            get
            {
                return m_y;
            }
            set
            {
                m_y = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor for GridCoordinate
        /// the initial x and y in this constructor is all 0
        /// </summary>
        public GridCoordinate()
        {
            this.m_x = 0;
            this.m_y = 0;
        }

        /// <summary>
        /// Initialize the GridCoordinate with value
        /// </summary>
        /// <param name="x">the x component of the GridCoordinate</param>
        /// <param name="y">the y component of the GridCoordinate</param>
        public GridCoordinate(int x, int y)
        {
            this.m_x = x;
            this.m_y = y;
        }

        #endregion

        /// <summary>
        /// Override the ToString method for GridCoordinate
        /// </summary>
        /// <returns>the string representation of the GridCoordinate</returns>
        public override string ToString()
        {
            string res = "";
            res += "(";
            res += m_x.ToString();
            res += ", ";
            res += m_y.ToString();
            res += ")";
            return res;
        }
    }

}