using System;

namespace Optimization.GeneticAlgorithms.Mutations
{
    internal class TWORSMutation : Mutation
    {
        public TWORSMutation(double mutationProbability, int[][] population, Random random) : base(mutationProbability, population, random)
        {
        }

        public override void Mutate(int[] chromosome)
        {
            var pointA = Random.Next(1, chromosome.Length);
            var pointB = Random.Next(1, chromosome.Length);
            var temp = chromosome[pointB];
            chromosome[pointB] = chromosome[pointA];
            chromosome[pointA] = temp;
        }
    }
}