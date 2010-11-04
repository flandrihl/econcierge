using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace eConcierge.Common
{
    public class QueryParamObj
    {
        internal void ClearAllValues()
        {
            paramName = string.Empty;
            dbType = DbType.String;
            paramValue = null;
            paramDirection = ParameterDirection.Input;
            paramLen = 0;
        }

        /// <summary>
        /// Parameter name
        /// </summary>
        private string paramName;
        public string ParamName { get { return paramName; } set { paramName = value; } }
        /// <summary>
        /// Type of parameter
        /// </summary>
        private DbType dbType = DbType.String;
        public DbType DBType { get { return dbType; } set { dbType = value; } }

        /// <summary>
        /// Value for the parameter
        /// </summary>
        private object paramValue;
        public object ParamValue { get { return paramValue; } set { paramValue = value; } }

        private int paramLen;
        public int ParamLen { get { return paramLen; } set { paramLen = value; } }

        /// <summary>
        /// Direction in out
        /// </summary>
        private ParameterDirection paramDirection = ParameterDirection.Input;
        public ParameterDirection ParamDirection { get { return paramDirection; } set { paramDirection = value; } }

        /// <summary>
        /// Constructors
        /// </summary>
        public QueryParamObj() { }
        public QueryParamObj(string paramName, object paramValue)
        {
            this.ParamName = paramName;
            this.ParamValue = paramValue;
        }

        public QueryParamObj(string paramName, DbType dbType, object paramValue)
        {
            this.ParamName = paramName;
            this.DBType = dbType;
            this.ParamValue = paramValue;
        }
        public QueryParamObj(string paramName, DbType dbType, object paramValue, ParameterDirection paramDirection)
        {
            this.ParamName = paramName;
            this.DBType = dbType;
            this.ParamValue = paramValue;
            this.ParamDirection = paramDirection;
        }
        public QueryParamObj(string paramName, DbType dbType, object paramValue, ParameterDirection paramDirection, int pParamLen)
        {
            this.ParamName = paramName;
            this.DBType = dbType;
            this.ParamValue = paramValue;
            this.ParamDirection = paramDirection;
            this.ParamLen = pParamLen;
        }
    }

    public class QueryParamList : Collection<QueryParamObj>
    {

        public QueryParamList() : base() { }


        /// <summary>
        /// returns param at position
        /// </summary>
        /// <param name="ndx"></param>
        /// <returns></returns>
        public QueryParamObj ParamAt(int ndx)
        {
            if (this.Count > ndx)
            {
                int i = 0;
                foreach (QueryParamObj obj in this)
                {
                    if (i++ == ndx)
                        return obj;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds param to collection
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public QueryParamObj AddParam(string paramName)
        {
            QueryParamObj obj = new QueryParamObj();
            obj.ParamName = paramName;
            this.Add(obj);
            return obj;
        }
        /// <summary>
        /// Adds param to collection
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public QueryParamObj AddParam(string paramName, object paramValue)
        {
            QueryParamObj obj = new QueryParamObj(paramName, paramValue);
            this.Add(obj);
            return obj;
        }
        /// <summary>
        /// Adds param to collection
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public QueryParamObj AddParam(string paramName, DbType dbType, object paramValue)
        {
            QueryParamObj obj = new QueryParamObj(paramName, dbType, paramValue);
            this.Add(obj);
            return obj;
        }
        /// <summary>
        /// Adds param to collection
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="dbType"></param>
        /// <param name="paramValue"></param>
        /// <param name="paramDirection"></param>
        /// <returns></returns>
        public QueryParamObj AddParam(string paramName, DbType dbType, object paramValue, ParameterDirection paramDirection)
        {
            QueryParamObj obj = new QueryParamObj(paramName, dbType, paramValue, paramDirection);
            this.Add(obj);
            return obj;
        }
        public QueryParamObj AddOutputParam(string paramName, DbType dbType, int pParamLen)
        {
            QueryParamObj obj = new QueryParamObj(paramName, dbType, null, ParameterDirection.Output, pParamLen);
            this.Add(obj);
            return obj;
        }
        /// <summary>
        /// returns param from collection
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public QueryParamObj Item(string paramName)
        {
            foreach (QueryParamObj obj in this)
            {
                if (obj.ParamName.ToLower().Equals(paramName.ToLower()))
                    return obj;
            }
            return null;
        }

        /// <summary>
        /// To determine if char is in set of chars
        /// </summary>
        /// <param name="pDelimeter"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool InSet(char[] pDelimeter, char c)
        {
            bool result = false;
            foreach (char ch in pDelimeter)
            {
                if (c.Equals(ch))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// Removes chars from string
        /// </summary>
        /// <param name="pDelimeter"></param>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string StripCharSet(char[] pDelimeter, string pStr)
        {
            string result = null;
            if (!String.IsNullOrEmpty(pStr))
            {
                StringBuilder buildStr = new StringBuilder();
                foreach (char c in pStr)
                {
                    if (!InSet(pDelimeter, c))
                    {
                        buildStr.Append(c);
                    }
                }
                result = buildStr.ToString();
            }
            return result;
        }

        public QueryParamObj ItemIgnoreAtSign(string paramName)
        {
            foreach (QueryParamObj obj in this)
            {
                string s = obj.ParamName.ToLower();
                s = StripCharSet(new char[] { '@' }, s);
                if (s.Equals(paramName.ToLower()))
                    return obj;
            }
            return null;
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);

        }
        protected override void ClearItems()
        {
            base.ClearItems();
        }
    }
}
