using Q.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Services.Helper
{
    public class MockService
    {
        public static string GetDataIdConfiguration(string entityType)
        {
            switch (entityType)
            {
                case "Assessment":
                    return "AM";
                case "AssetProperty":
                    return "AR";
                case "Task":
                    return "TA";
            }
            return string.Empty;
        }
    }

    public static class DataIdGenerationService
    {
        public static string GenerateDataId(int? id,string dataIdPrefix, string customDataId = "")
        {
            try
            {
                return (id != default(int) && id != null) ? GetDataId(Convert.ToString(id), dataIdPrefix) : string.Concat(dataIdPrefix, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetDataId(this string currentDataId, string dataIdPrefix)
        {
            string returnValue;

            if (!String.IsNullOrEmpty(currentDataId))
            {
                int incrementedValue;

                //We get the INT part from the current Data Id by taking out the Prefix from the FRONT part of the current data id
                //because we know, the prefix part is the section with which any data id will always start with
                var intPart = currentDataId.Replace(dataIdPrefix, "");

                if (Int32.TryParse(intPart, out incrementedValue))
                {
                    incrementedValue = incrementedValue + 1;
                    returnValue = String.Concat(dataIdPrefix, incrementedValue);
                }
                else
                {
                    returnValue = String.Concat(dataIdPrefix, 1);
                }
            }
            else
            {
                returnValue = String.Concat(dataIdPrefix, 1);
            }

            return returnValue;
        }
    }
}
