using System;
using System.Collections.Generic;
using System.Text;

namespace ECount.CoreBase
{
	public static class ConditionExtentions
	{

        #region [All Type]
        public static bool vIsNull<T>(this T source)
        {
            if (source == null) {
                return true;
            }
            return false;
        }

        public static bool vIsEmpty<T>(this T source)
        {
            return source.vIsNull();
        }

        public static bool vIsNotEmpty<T>(this T source)
        {
            return !source.vIsEmpty();
        }

        public static bool vIsDefault<T>(this T source)
        {
            // default(bool) 활용
            if (EqualityComparer<T>.Default.Equals(source,default(T))) {
                return true;
            }
            return false;
        }
        #endregion



        #region [Bool Type]
        public static bool vIsNull(this bool? source)
		{
			if (source == null)
			{
				return true;
			}
			return false;
		}

		public static bool vIsEmpty(this bool? source)
		{
			return source.vIsNull();
		}

		public static bool vIsNotEmpty(this bool? source)
		{
			return !source.vIsEmpty();
		}

		public static bool vIsDefault(this bool? source)
		{
			// default(bool) 활용
			if (default(bool) == source)
			{
				return true;
			}
			return false;
		}
		#endregion


		#region [String Type]
		public static bool vIsNull(this string source)
		{
			if (source == null)
			{
				return true;
			}
			return false;
		}

		public static bool vIsEmpty(this string source)
		{
			if (source.vIsNull() == false)
			{
				if (source == string.Empty)
				{
					return true;
				}
			}
			return false;
		}

		public static bool vIsNotEmpty(this string source)
		{
			return !source.vIsEmpty();
		}

		public static bool vIsDefault(this string source)
		{
			// default(bool) 활용
			if (default(string) == source)
			{
				return true;
			}
			return false;
		}
		#endregion

		#region [Int Type]
		public static bool vIsNull(this int? source)
		{
			if (source == null)
			{
				return true;
			}
			return false;
		}

		public static bool vIsEmpty(this int? source)
		{
			return source.vIsNull();
		}

		public static bool vIsNotEmpty(this int? source)
		{
			return !source.vIsEmpty();

		}

		public static bool vIsDefault(this int? source)
		{
			// default(bool) 활용
			if (default(int) == source)
			{
				return true;
			}
			return false;
		}
		#endregion

	}
}
