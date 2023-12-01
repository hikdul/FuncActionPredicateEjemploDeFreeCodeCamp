namespace FuncActionPredicateExample
{
    /// <summary>
    /// la extension no importa el nombre mas bien el el this despues del primer argumento
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Action general para el uso dentro de la extension
        /// </summary>
        /// <returns></returns>
        static Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($" id:{arg1}{Environment.NewLine} Name:{arg2}{Environment.NewLine} Last Name:{arg3}{Environment.NewLine} Salary:{arg4}{Environment.NewLine} Gender:{arg5}{Environment.NewLine} Mannagement:{arg6}{Environment.NewLine}{Environment.NewLine}");
        /// <summary>
        /// Genera el filtro directamente
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<Employee> FilterEmpleyees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filtered = new();
            foreach (var employ in employees)
                if(predicate(employ))
                    filtered.Add(employ);
            return filtered;
        }
        /// <summary>
        /// par aque imprima la data como un valor natural de su metodo
        /// </summary>
        /// <param name="employees"></param>
        public static void PrintDataEmploy(this List<Employee> employees)
        {
                foreach (var e in employees)
                    displayEmployeeRecords(e.Id, e.Name, e.LastName, e.AnnualSalary, e.Gender,e.Mannagement);
        }
    }
}