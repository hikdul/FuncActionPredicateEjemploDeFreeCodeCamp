using System;

namespace  FuncActionPredicateExample
{
    class Program
    {
        
        #region  Func<>
        // ? la volvi publica para usarla luego
        static Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($" id:{arg1}{Environment.NewLine} Name:{arg2}{Environment.NewLine} Last Name:{arg3}{Environment.NewLine} Salary:{arg4}{Environment.NewLine} Gender:{arg5}{Environment.NewLine} Mannagement:{arg6}{Environment.NewLine}{Environment.NewLine}");
        
        // ? estos elementos son para iniciar entendiendo el uso de Func
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// un ejemplo base de como se usa
        /// </summary>
        static void usingClass() 
        {
            MathClass mathClass = new();
            Func<int, int, int> calc = mathClass.Sum;
            
            int resurl = calc(1,2);
            
            Console.WriteLine(resurl);
        }
        /// <summary>
        /// otro modo de usarlo
        /// </summary>
        static void usingDelegate() 
        {

            Func<int, int, int> calc = delegate(int a, int b) {return a+b;};
            
            int resurl = calc(1,2);
            
            Console.WriteLine(resurl);
        }
        /// <summary>
        /// El modo mas comun de como se usa
        /// </summary>
        static void usingDelegateSimple() 
        {
            Func<int, int, int> calc = (a, b) => a+b;
            
            int resurl = calc(1,2);
            
            Console.WriteLine(resurl);
        }
        /// <summary>
        /// Creando delegate de manera manual
        /// </summary>
        static void usingmyFunc() 
        {
            Func2<int, int, int> calc = (a, b) => a+b;
            
            int resurl = calc(1,2);
            
            Console.WriteLine(resurl);
        }
        /// <summary>
        /// Un ejemplo de uno para Func un poco mas tirado
        /// </summary>
        static void completeExample()
        {
            float a = 2.3f, b=4.56f;
            int c = 3;
            
            Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) + arg3;
            
            Console.WriteLine(calc2(a,b,c));
        }
        /// <summary>
        /// Forma mas "real" del uso de func
        /// </summary>
        static void calculateTotalAnnualSalary()
        {
            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (annualSalary, bonusPercentage) => annualSalary + (annualSalary * (bonusPercentage / 100));
            Console.WriteLine(calculateTotalAnnualSalary(14100,3));
        }
        /// <summary>
        /// Resumen de todo lo visto para usar Func<...>(...) con cada elemento explicado
        /// </summary>
        static void useFunc()
        {
            Console.WriteLine("whit class");
            usingClass();
            Console.WriteLine("whit Delegate");
            usingDelegate();
            Console.WriteLine("whit Delegate in Lambda expretion");
            usingDelegateSimple();
            Console.WriteLine("the same example whit use my Func");
            usingmyFunc();
            Console.WriteLine("more complex example");
            completeExample();
            Console.WriteLine("calculate anully salary");
            calculateTotalAnnualSalary();
            
        }
        #endregion
        
        #region Action
        /// <summary>
        /// Un ejemplo sencillo de lo que es Action<...>(...)
        /// </summary>
        static void actionSimpleExample()
        {
            // ? la volvi global para usarla en otro punto del ejemplo
            //Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($" id:{arg1}{Environment.NewLine} Name:{arg2}{Environment.NewLine} Last Name:{arg3}{Environment.NewLine} Salary:{arg4}{Environment.NewLine} Gender:{arg5}{Environment.NewLine} Mannagement:{arg6}{Environment.NewLine}{Environment.NewLine}");
            
            displayEmployeeRecords(1,"Hector", "Contreras",14000,'M',true);
            displayEmployeeRecords(1,"Victor", "Robles",16000,'F',true);
        }
        
        /// <summary>
        /// Funcion que lleva con sigo un predicado
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        static List<Employee> FilterEmpleyees(List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filtered = new();
            foreach (var employ in employees)
                if(predicate(employ))
                    filtered.Add(employ);
            return filtered;
        }
        /// <summary>
        /// aca van los detalles de este ejemplo
        /// * uso de una clase para agrupar les elementos en clase
        /// * uso de un predicado para generar un filtro de la lista
        /// * uso de una extencion directamente para generar el mismo filtro
        /// * generando prueba para que la impresion se haga desde una clase extencion
        /// </summary>
        static void actionSimpleWhitClass()
        {
            List<Employee> employees = new()
            {
                new(1, "Hector", "Contreras", 14000, 'M', true),
                new(2, "Victor", "Robles", 16000, 'F', true),
                new(3, "Pamela", "Ricardi", 6000, 'F', true),
                new(4, "Jose", "Vicente", 10000, 'M', true)
            };
            
            var filtered = FilterEmpleyees(employees,e => e.AnnualSalary < 10001);
            var filtered2 = employees.FilterEmpleyees(e => e.AnnualSalary < 10001);
            
            Console.WriteLine("manually");
            foreach (var e in filtered)
                displayEmployeeRecords(e.Id, e.Name, e.LastName, e.AnnualSalary, e.Gender,e.Mannagement);

            Console.WriteLine("elegant");
            filtered2.PrintDataEmploy();
        }
        
        static void useActions()
        {
            // Console.WriteLine("Actions simple example");
            // actionSimpleExample();
            Console.WriteLine("uso de clases");
            actionSimpleWhitClass();
            
        }
        #endregion

        static void Main(string[] args)
        {
            useFunc();
            useActions();
            Console.ReadKey();
        }
    }
}
