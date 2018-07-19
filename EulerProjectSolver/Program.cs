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

            try
            {
                if (args.Length > 1)
                    problemIds = args[1].Split(',').Select(i => Convert.ToInt32(i)).ToArray();
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
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Verifying problem answers...");
                UtilityEulerProjectSolver.ValidateProblems(problems);
            }
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
