/*
    Copyright (c) 2017 Marcin Szeniak (https://github.com/Klocman/)
    Apache License Version 2.0
*/

using System.Windows.Forms;
using Klocman.Properties;
using Klocman.Resources;

namespace Klocman.Extensions
{
    public static class BooleanTools
    {
        /// <summary>
        ///     Convert boolean value to string contained in Localisation.Yes and Localisation.No resources. Can be localised.
        /// </summary>
        public static string ToYesNo(this bool value)
        {
            return value ? Localisation.Yes : Localisation.No;
        }

        /// <summary>
        ///     Convert nullable boolean value to string contained in
        ///     Localisation.Yes, Localisation.No and CommonStrings.Unknown resources. Can be localised.
        /// </summary>
        public static string ToYesNo(this bool? value)
        {
            return value.HasValue ? value.Value.ToYesNo() : CommonStrings.Unknown;
        }
    }
}
