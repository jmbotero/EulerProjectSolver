using JuanMartin.Utilities;
using System;

namespace JuanMartin.EulerProject
{
    class Program
    {

        static void Main(string[] args)
        {
            var problems = UtilityEulerProjectSolver.problems;
            var onlyRunProblems = Convert.ToBoolean(args[0]);

            if (onlyRunProblems)
            {
                for (int i = 0; i < problems.Length; i++)
                {
                    var p = problems[i];
                    UtilityEulerProjectSolver.Launch(p.Script, p);
                }
            }
            else
            {
                Console.WriteLine("Verifying problem anwers...");
                UtilityEulerProjectSolver.ValidateProblems(problems);
            } 
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
