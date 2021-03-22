using System;

namespace Optimization.GeneticAlgorithms.Eliminations
{
    public abstract class Elimination
    {
        public abstract void EliminateAndReplace(int[][] offsprings, double[] fitnessProductPlacement);
        protected readonly int[][] Population;
        protected readonly int PopulationSize;
        protected readonly Random Random= new Random();
        protected Elimination(int[][] population)
        {
            Population = population;
            PopulationSize = population.Length;
        }
        public enum EliminationType
        {
            Elitism,
            RouletteWheel
        }
    }
}