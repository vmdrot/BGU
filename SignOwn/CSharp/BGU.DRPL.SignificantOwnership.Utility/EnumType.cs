using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace BGU.DRPL.SignificantOwnership.Utility
{
    [Serializable]
    public class EnumType
    {
        #region ClassVariables
        private string m_sKey = "";
        private string m_sValue = "";       
        private readonly Enum m_eEnumValue;
        #endregion ClassVariables

        #region Constructors
        public EnumType()
        {
        }
        public EnumType(string sKey, string sValue)
        {
            m_sKey = sKey;
            m_sValue = sValue;
        }
        public EnumType(string sKey, string sValue, Enum enumValue)
            : this(sKey, sValue)
        {
            m_eEnumValue = enumValue;
        }
        #endregion Constructors

        #region Properties
        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public string Value
        {
            get { return m_sValue; }
            set { m_sValue = value; }
        }

        public Enum EnumValue
        {
            get { return m_eEnumValue; }
        }
        #endregion Properties

        #region Type Casts

        public static implicit operator Enum(EnumType enumTypeValue)
        {
            return enumTypeValue.m_eEnumValue;
        }

        public static implicit operator EnumType(Enum enumValue)
        {
            string sKey = Enum.Format(enumValue.GetType(), enumValue, "D");
            return new EnumType(sKey, GetEnumDescription(enumValue), enumValue);
        }

        #endregion

        #region Public methods
        static public List<EnumType> GetEnumList(Type typeEnum)
        {
            return GetEnumList(typeEnum, true);
        }

        static public List<EnumType> GetEnumList(Type typeEnum, bool bIgnoreNullType)
        {
            List<KeyValuePair<int, EnumType>> listEnumType = new List<KeyValuePair<int, EnumType>>();
            foreach (int iVal in Enum.GetValues(typeEnum))
            {
                if (iVal == 0 && bIgnoreNullType)
                    continue;

                Enum enumValue = (Enum) (Enum.Parse(typeEnum, iVal.ToString()));
                string text = GetEnumDescription(enumValue);
                if(string.IsNullOrEmpty(text))
                    text = enumValue.ToString();
                EnumType oEnumType = new EnumType(iVal.ToString(), text, enumValue);
                listEnumType.Add(new KeyValuePair<int, EnumType>(GetEnumOrder(enumValue), oEnumType));
            }
            return SortAndConvertToListOfEnumType(listEnumType);
        }

        /// <summary>
        /// Gets a list of EnumType from enum by category name (category attribute)
        /// </summary>
        /// <param name="sCategoryName">category name</param>
        /// <param name="typeEnumMember">enum to be filtered by category name</param>
        /// <returns></returns>
        static public List<EnumType> GetEnumListByCategory(string sCategoryName, Type typeEnumMember)
        {
            List<KeyValuePair<int, EnumType>> listEnumType = new List<KeyValuePair<int, EnumType>>();
            foreach (int iVal in Enum.GetValues(typeEnumMember))
            {
                FieldInfo fi = typeEnumMember.GetField(Enum.GetName(typeEnumMember, iVal));
                Enum enumValue = (Enum)(Enum.Parse(typeEnumMember, iVal.ToString()));
                if (GetEnumCategory(fi) == sCategoryName)
                {
                    EnumType oEnumType = new EnumType(iVal.ToString(), GetEnumDescription(fi), enumValue);
                    listEnumType.Add(new KeyValuePair<int, EnumType>(GetEnumOrder(enumValue), oEnumType));
                }
            }
            return SortAndConvertToListOfEnumType(listEnumType);
        }

        private static List<EnumType> SortAndConvertToListOfEnumType(List<KeyValuePair<int, EnumType>> listEnumType)
        {
            bool sortingNeeded = false;
            foreach (KeyValuePair<int, EnumType> pair in listEnumType)
                if (pair.Key != 0)
                {
                    sortingNeeded = true;
                    break;
                }
            if (sortingNeeded)
            {
                listEnumType.Sort(delegate(KeyValuePair<int, EnumType> obj1, KeyValuePair<int, EnumType> obj2)
                                      {
                                          if (obj1.Key > obj2.Key) return 1;
                                          else if (obj1.Key < obj2.Key) return -1;
                                          else return 0;
                                      }
                    );
            }
            List<EnumType> result = new List<EnumType>(listEnumType.Count);
            foreach (KeyValuePair<int, EnumType> pair in listEnumType)
                result.Add(pair.Value);
            return result;
        }

        public static string GetEnumDescription(Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
            if (null != fi)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : enumValue.ToString();
            }
            return enumValue.ToString();
        }

        public static int GetEnumOrder(Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
            if (null != fi)
            {
                OrderAttribute[] attributes = (OrderAttribute[])fi.GetCustomAttributes(typeof(OrderAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Order : 0;
            }
            return 0;
        }

        public static bool IsValidEnumValue(Type enumType, int value)
        {
            if(!enumType.IsEnum)
                throw new Exception(enumType + " is not enum type");
            bool result = false;
            foreach(int intVal in Enum.GetValues(enumType))
                if(intVal == value)
                {
                    result = true;
                    break;
                }
            return result;
        }

        /// <summary>
        /// Get Attributes of type T from enum value
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="enumField">enum value</param>
        /// <returns>Array of T Attributes</returns>
        public static T[] GetEnumFieldAttributes<T>(Enum enumField)
        {
            List<T> result = new List<T>();
            FieldInfo fi = enumField.GetType().GetField(enumField.ToString());
            if (fi != null)
            {
                object[] res = fi.GetCustomAttributes(typeof(T), false);
                if (res.Length > 0)
                {
                    result = new List<T>(res.Length);
                    foreach(T attr in res)
                        result.Add(attr);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// parse enum value
        /// </summary>
        /// <typeparam name="T">enum type</typeparam>
        /// <param name="value">value</param>
        /// <returns>enum value</returns>
        public static T Parse<T>(string value)
        {
            return (T) Enum.Parse(typeof (T), value);
        }

        public static EnumType CreateFromEnumValue<E>(E enumValue)
        {
            if (!(enumValue is Enum))
            {
                throw new ArgumentException("Parameter must be Enum", "enumValue");
            }

            return new EnumType(EnumToValueInd(enumValue), GetEnumDescription(enumValue as Enum));
        }

        #endregion Public methods

        #region Protected and override methods
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            EnumType oEnumType = obj as EnumType;
            if (oEnumType == null)
                return false;

            if (oEnumType.m_sKey == m_sKey && oEnumType.m_sValue == m_sValue)
                return true;
            else
                return false;
        }


        public override int GetHashCode()
        {
            return (m_sKey ?? string.Empty).GetHashCode() ^ (m_sValue ?? string.Empty).GetHashCode();
        }

        #endregion

        #region Private methods
        private static string GetEnumDescription(FieldInfo fi)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : "";
        }

        private static string GetEnumCategory(FieldInfo fi)
        {
            CategoryAttribute[] attributes = (CategoryAttribute[])fi.GetCustomAttributes(typeof(CategoryAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Category : "";
        }


        #endregion Private methods

        #region Auxiliary methods
        /// <summary>
        /// Comparer to feed as Sort() method argument
        /// </summary>
        /// <param name="x">this parameter is used behind the scenes by List.Sort() method</param>
        /// <param name="y">this parameter is used behind the scenes by List.Sort() method</param>
        /// <returns></returns>
        public static int CompareEnumsByValues(EnumType x, EnumType y)
        {
            return String.Compare(x.Value, y.Value);
        }
        #endregion

        #region Generic Methods

        /// <summary>
        /// Converts text or index value to the E enum type value; or returns enum's NULL value (the 0)
        /// </summary>
        public static E ValueToEnum<E>(string svalue)
        {
            if (string.IsNullOrEmpty(svalue))
                return GetDefaultValue<E>();

            E eResult;
            try
            {
                eResult = (E)Enum.Parse(typeof(E), svalue);
            }
            catch (ArgumentException)
            {
                eResult = GetDefaultValue<E>();
            }
            return eResult;
        }

        /// <summary>
        /// Get default value for enum
        /// </summary>
        /// <typeparam name="E">Enum type</typeparam>
        /// <returns>value</returns>
        public static E GetDefaultValue<E>()
        {
            E eResult = ((E[])Enum.GetValues(typeof(E)))[0];
            return eResult;
        }

        public static int EnumToValue(Enum enumValue)
        {
            int result = (int) enumValue.GetType().GetField(enumValue.ToString()).GetValue(enumValue);
            return result;
        }



        /// <summary>
        /// Converts enum value to the index represented by string
        /// </summary>
        public static string EnumToValueInd<E>(E evalue)
        {
            return String.Format("{0}", Enum.Format(typeof(E), evalue, "D"));
        }

        /// <summary>
        /// Converts enum value to the string values
        /// </summary>
        public static string EnumToValue<E>(E evalue)
        {
            return String.Format("{0}", Enum.Format(typeof(E), evalue, "G"));
        }

        #endregion
    }

    /// <summary>
    /// Attrubute for ordering EnumType items returning by GetEnumList and GetEnumListByCategory methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false), Serializable]
    public class OrderAttribute : Attribute
    {
        public readonly int Order;

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }

}
