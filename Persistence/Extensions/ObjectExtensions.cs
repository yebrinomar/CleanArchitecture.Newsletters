using Newtonsoft.Json;

namespace Api.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// The string representation of null.
        /// </summary>
        private static readonly string Null = "null";

        /// <summary>
        /// The string representation of exception.
        /// </summary>
        private static readonly string Exception = "Exception";

        /// <summary>
        /// To json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The Json of any object.</returns>
        public static string ToJson(this object value)
        {
            if (value == null) return Null;

            try
            {
                string json = JsonConvert.SerializeObject(value);
                return json;
            }
            catch (Exception exception)
            {
                //log exception but dont throw one
                return Exception;
            }
        }
    }
}
