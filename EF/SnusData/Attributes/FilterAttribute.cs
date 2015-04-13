using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnusData.Attributes
{
    [Flags]
    public enum FilterFlag
    {
        ContainsInFilter = 1,
        ContainsFilterIn = 2,
        IntervalStart = 3,
        IntervalEnd = 4,
        Equal = 5
    }
    [System.AttributeUsage(System.AttributeTargets.Struct | AttributeTargets.Property, AllowMultiple=true)]
    public class FilterAttribute : Attribute
    {
        public FilterAttribute(FilterFlag flag, string propName)
        {
            Flag = flag;
            PropName = propName;
        }
        public FilterFlag Flag { get; set; }
        public string PropName { get; set; }
    }
}
