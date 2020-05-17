using JuanMartin.Utilities.Euler;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JuanMartin.EulerProject
{
    class Program
    {
        private const string separator = "------------------------------------------------------------------------";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        static void Main(string[] args)
         {
            JuanMartin.Models.Problem[] problems = UtilityEulerProjectSolver.problems;

            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");

            var validateProblems = Convert.ToBoolean(args[0],cultures);
            IEnumerable<int> problemIds = null;

            try
            {
                if (args.Length > 1)
                    problemIds = args[1].Split(',').Select(i => Convert.ToInt32(i,cultures)).ToArray();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                problemIds = null;
            }
            if (problemIds == null)
            {
                validateProblems = false;

                for (int i = 0; i < problems.Length; i++)
                {
                    var p = UtilityEulerProjectSolver.GetProblemById(i);
                    UtilityEulerProjectSolver.Launch(p.Script, p);
                }
            }
            else
            {
                foreach (int id in problemIds)
                {
                    if (id == -1)
                        break;

                    var p = UtilityEulerProjectSolver.GetProblemById(id);
                    UtilityEulerProjectSolver.Launch(p.Script, p);
                }
            }

            if (validateProblems)
            {
                Console.WriteLine(separator);
                Console.WriteLine("Verifying problem answers...");
                UtilityEulerProjectSolver.ValidateProblems(problems);
            }
            Console.WriteLine(separator);
            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
