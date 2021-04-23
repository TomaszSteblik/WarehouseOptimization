using System;
using System.Collections.Generic;
using Optimization.GeneticAlgorithms.Crossovers.ConflictResolvers;

namespace Optimization.GeneticAlgorithms.Crossovers
{
    public abstract class Crossover
    {
        protected ConflictResolver ResolverConflict;
        protected ConflictResolver ResolverRandomized;
        protected readonly Random Random;
        protected int _resolveCount;
        protected int _randomizedResolvesCount;
        protected int _randomizationChances;

        public int[] difference;


        public Crossover(ConflictResolver resolverConflict, ConflictResolver resolverRandomized, Random random)
        {
            ResolverConflict = resolverConflict;
            ResolverRandomized = resolverRandomized;
            Random = random;
        }

        public int ResolveCount => _resolveCount;

        public int RandomizedResolvesCount => _randomizedResolvesCount;

        public int RandomizationChances => _randomizationChances;

        public abstract int[] GenerateOffspring(int[][] parents);
        public virtual int[][] GenerateOffsprings(int[][] parents, int numParentsForOneChild)
        {
            _resolveCount = 0;
            _randomizedResolvesCount = 0;
            _randomizationChances = 0;
            var parentsLength = parents.Length;
            var amountOfChildren = parentsLength / 2;
            difference = new int[amountOfChildren];
            int[][] offsprings = new int[amountOfChildren][];

            for (int c = 0; c < amountOfChildren; c++)
            {
                int[][] prnt = new int[numParentsForOneChild][];
                for (int i = 0; i < numParentsForOneChild; i++)
                {
                    prnt[i] = parents[Random.Next(parents.Length)];
                }

                if (prnt.Length == 2)
                {
                    for (int i = 0; i < prnt[0].Length; i++)
                    {
                        difference[c] += prnt[0][i] == prnt[1][i] ? 0 : 1;
                    }
                }
                

                offsprings[c] = GenerateOffspring(prnt);
            }

            return offsprings;
        }
        
        

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
        MAC,
        PMX,
        ERX
    }
}