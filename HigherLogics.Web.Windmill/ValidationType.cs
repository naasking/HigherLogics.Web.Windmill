using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// The type of validation feedback.
    /// </summary>
    public enum ValidationType
    {
        /// <summary>
        /// Provide the user with guidance, ie. your password must be at least X characters long.
        /// </summary>
        Notice,
        /// <summary>
        /// The input provided is valid.
        /// </summary>
        Valid,
        /// <summary>
        /// The input provided is not valid.
        /// </summary>
        Error,
    }
}
