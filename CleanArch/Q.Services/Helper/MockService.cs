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
            return GetDataId(Convert.ToString(id.Value), dataIdPrefix);
        }

        private static string GetDataId(this string currentDataId, string dataIdPrefix)
        {
            string returnValue;

            if (!String.IsNullOrEmpty(currentDataId))
            {
                var intPart = currentDataId.Replace(dataIdPrefix, "");

                if (Int32.TryParse(intPart, out int incrementedValue))
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
