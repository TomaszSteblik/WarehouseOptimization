﻿using System;

namespace Optimization.GeneticAlgorithms.Mutations
{
    internal abstract class Mutation
    {
        protected readonly Random Random;
        public double _mutationProbability;
        private int[][] _population;

        protected Mutation(double mutationProbability, int[][] population, Random random)
        {
            _mutationProbability = mutationProbability;
            _population = population;
            Random = random;
        }
        
        public virtual void Mutate(int[][] population)
        {
            if (_mutationProbability > 0d)
            {
                for (int m = (int) (0.1 * _population.Length); m < _population.Length; m++)
                {
                    if (Random.Next(0, 1000) <= _mutationProbability)
                    {
                        Mutate(_population[m]);
                    }
                }
            }
        }
        public abstract void Mutate(int[] chromosome);

    }

    public enum MutationMethod
    {
        CIM,
        RSM,
        THROAS,
        THRORS,
        TWORS,
        MRM,
        MAM
    }
}