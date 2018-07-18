using JuanMartin.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuanMartin.EulerProject
{
    class Program
    {

        static void Main(string[] args)
         {
            var problems = UtilityEulerProjectSolver.problems;
            var validateProblems = Convert.ToBoolean(args[0]);
            IEnumerable<int> problemIds = null;

            if (args.Length > 1)
                problemIds=args[1].Split(',').Select(i=>Convert.ToInt32(i)).ToArray();

            if (validateProblems)
            {
                Console.WriteLine("Verifying problem anwers...");
                UtilityEulerProjectSolver.ValidateProblems(problems);
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------");
                if (problemIds == null)
                {
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
                        var p = UtilityEulerProjectSolver.GetProblemById(id);
                        UtilityEulerProjectSolver.Launch(p.Script, p);
                    }
                }
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
