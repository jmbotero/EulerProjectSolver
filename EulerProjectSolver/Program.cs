using JuanMartin.Utilities;
using System;

namespace JuanMartin.EulerProject
{
    class Program
    {

        static void Main(string[] args)
        {
            var problems = UtilityEulerProjectSolver.problems;
            var validateProblems = Convert.ToBoolean(args[0]);
            var selectedPId = -1;
            if (args.Length > 0)
                selectedPId = Convert.ToInt32(args[1]);

            if (selectedPId==-1)
            {
                for (int i = 0; i < problems.Length; i++)
                {
                    var p = UtilityEulerProjectSolver.GetProblemById(i);
                    UtilityEulerProjectSolver.Launch(p.Script, p);
                }
            }
            else
            {
                var p = UtilityEulerProjectSolver.GetProblemById(selectedPId);
                UtilityEulerProjectSolver.Launch(p.Script, p);
            }

            if (validateProblems)
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
