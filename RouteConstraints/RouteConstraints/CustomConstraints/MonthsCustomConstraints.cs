using System.Text.RegularExpressions;

namespace RouteConstraints.CustomConstraints
{
    //Eg: sales-report/2020/apr
    public class MonthsCustomConstraints : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //check whether the value is exists
            if (!values.ContainsKey(routeKey)) //month
            {
                return false; //not match
            }
            Regex regex=new Regex("^01[0125][0-9]{8}$");
            string? monthValue = Convert.ToString(values[routeKey]);

            if(regex.IsMatch(monthValue))
            {
                return true;
            }
            return false;

        }
    }
}
