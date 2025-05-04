using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCDependecyInjection.BLL.Helper
{
    public static class StringExtension
    {
        public static bool HasValue ([NotNullWhen(true)] this string? input, bool allowWhiteSpaceAsEmpty = true)
        {
           return allowWhiteSpaceAsEmpty ? !string.IsNullOrWhiteSpace(input) : !string.IsNullOrEmpty(input);
        }
    }
}
