using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// The input group layout behaviour.
    /// </summary>
    public enum GroupLayout
    {
        /// <summary>
        /// Element is not part of an input group.
        /// </summary>
        None,
        /// <summary>
        /// Element is on the left side of an input group.
        /// </summary>
        Left,
        /// <summary>
        /// Element is on the right side of an input group.
        /// </summary>
        Right,
    }
}
