using System;

namespace Optimization.DistanceMode.GeneticAlgorithms.Eliminations
{
    public abstract class Elimination
    {
        public abstract void EliminateAndReplace(int[][] offsprings, double[] fitnessProductPlacement);
        protected readonly int[][] Population;
        protected readonly int PopulationSize;
        protected readonly Random Random= new Random();
        protected Elimination(ref int[][] population)
        {
            Population = population;
            PopulationSize = population.Length;
        }
    }
}