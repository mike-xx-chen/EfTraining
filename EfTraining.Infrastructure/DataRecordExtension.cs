using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EfTraining.Infrastructure
{
    /// <summary>
    /// Extends IDataRecoard to deal with nullable value types and look for its value via column name.
    /// </summary>
    public static class DataRecordExtension
    {
        private static void CheckNotNull(IDataRecord dataReader, string fieldName)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader");
            }

            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("fieldName");
            }
        }

        /// <summary>
        /// Gets the nullable value of the specified column as a Boolean.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static bool? GetNullableBoolean(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (bool?)dataReader.GetBoolean(index);
        }

        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static bool GetBoolean(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetBoolean(index);
        }

        /// <summary>
        /// Gets the 8-bit unsigned integer of the specified column as a Byte.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static byte GetByte(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetByte(index);
        }

        /// <summary>
        /// Gets the nullable 8-bit unsigned integer value of the specified column as a Byte?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static byte? GetNullableByte(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (byte?)dataReader.GetByte(index);
        }

        /// <summary>
        /// Gets the character value of the specified column as a Char.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static char GetChar(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetChar(index);
        }

        /// <summary>
        /// Gets the nullable character value of the specified column as a Char?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static char? GetNullableChar(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (char?)dataReader.GetChar(index);
        }

        /// <summary>
        /// Gets the date and time data value of the specified column as a DateTime.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static DateTime GetDateTime(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetDateTime(index);
        }

        /// <summary>
        /// Gets the nullable date and time data value of the specified column as a DateTime?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static DateTime? GetNullableDateTime(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (DateTime?)dataReader.GetDateTime(index);
        }

        /// <summary>
        /// Gets the fixed-position numeric value of the specified column as a Decimal.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static decimal GetDecimal(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetDecimal(index);
        }

        /// <summary>
        /// Gets the nullable fixed-position numeric value of the specified column as a Decimal?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static decimal? GetNullableDecimal(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (decimal?)dataReader.GetDecimal(index);
        }

        /// <summary>
        /// Gets the double-precision floating point number of the specified column as a Double.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static double GetDouble(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetDouble(index);
        }

        /// <summary>
        /// Gets the nullable double-precision floating point number of the specified column as a Double?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static double? GetNullableDouble(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (double?)dataReader.GetDouble(index);
        }

        /// <summary>
        /// Gets the single-precision floating point number of the specified column as a Float.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static float GetFloat(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetFloat(index);
        }

        /// <summary>
        /// Gets the nullable single-precision floating point number of the specified column as a Float?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static float? GetNullableFloat(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (float?)dataReader.GetFloat(index);
        }

        /// <summary>
        /// Gets the GUID value of the specified column as a GUID.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static Guid GetGuid(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetGuid(index);
        }

        /// <summary>
        /// Gets the nullable GUID value of the specified column as a GUID?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static Guid? GetNullableGuid(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (Guid?)dataReader.GetGuid(index);
        }

        /// <summary>
        /// Gets the 16-bit signed integer value of the specified column as a Int16.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static short GetInt16(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetInt16(index);
        }

        /// <summary>
        /// Gets the nullable 16-bit signed integer value of the specified column as a Int16?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static short? GetNullableInt16(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (short?)dataReader.GetInt16(index);
        }

        /// <summary>
        /// Gets the 32-bit signed integer value of the specified column as a Int32.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static int GetInt32(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetInt32(index);
        }

        /// <summary>
        /// Gets the nullable 32-bit signed integer value of the specified column as a Int32?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static int? GetNullableInt32(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(index) ? null : (int?)dataReader.GetInt32(index);
        }

        /// <summary>
        /// Gets the 64-bit signed integer value of the specified column as a Int64.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static long GetInt64(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetInt64(fieldName);
            return dataReader.GetInt64((int)index);
        }

        /// <summary>
        /// Gets the nullable 64-bit signed integer value of the specified column as a Int64?.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static long? GetNullableInt64(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetInt64(fieldName);
            return dataReader.IsDBNull((int)index)? null : (long?)dataReader.GetInt64((int)index);
        }

        /// <summary>
        /// Gets the string value of the specified column as a string.
        /// </summary>
        /// <param name="dataReader">The extended DataReader</param>
        /// <param name="fieldName">The column name</param>
        /// <returns></returns>
        public static string GetString(this IDataRecord dataReader, string fieldName)
        {
            CheckNotNull(dataReader, fieldName);

            var index = dataReader.GetOrdinal(fieldName);
            return dataReader.GetString(index);
        }
    }
}
