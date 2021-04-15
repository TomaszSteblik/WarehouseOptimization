using System;
using System.Collections.Generic;
using Optimization.GeneticAlgorithms.Crossovers.ConflictResolvers;

namespace Optimization.GeneticAlgorithms.Crossovers
{
    public abstract class Crossover
    {
        protected ConflictResolver ConflictResolver;

        public Crossover(ConflictResolver resolver)
        {
            ConflictResolver = resolver;
        }
        public abstract int[] GenerateOffspring(int[][] parents);
        public virtual int[][] GenerateOffsprings(int[][] parents, int numParentsForOneChild)
        {
            var parentsLength = parents.Length;
            var amountOfChildren = parentsLength / 2;
            int[][] offsprings = new int[amountOfChildren][];

            for (int c = 0; c < amountOfChildren; c++)
            {
                int[][] prnt = new int[numParentsForOneChild][];
                for (int i = 0; i < numParentsForOneChild; i++)
                {
                    prnt[i] = parents[Random.Next(parents.Length)];
                }

                offsprings[c] = GenerateOffspring(prnt);
            }

            return offsprings;
        }
        protected readonly Random Random = new Random();
        
        

        protected bool IsThereGene(int[] chromosome, int a)
        {
            foreach (var t in chromosome)
            {
                if (t == a) return true;
            }
            return false;
        }
    }
    public enum CrossoverMethod
    {
        Aex,
        Cycle,
        Order,
        HGreX,
        HProX,
        HRndX,
        KPoint,
        MRC,
        MAC
    }
}