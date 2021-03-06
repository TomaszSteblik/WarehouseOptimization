﻿using System;
using System.Linq;
using System.Threading;
using Optimization.GeneticAlgorithms;
using Optimization.GeneticAlgorithms.Crossovers;
using Optimization.GeneticAlgorithms.Eliminations;
using Optimization.GeneticAlgorithms.Initialization;
using Optimization.GeneticAlgorithms.Modules;
using Optimization.GeneticAlgorithms.Mutations;
using Optimization.GeneticAlgorithms.Selections;
using Optimization.Helpers;
using Optimization.Parameters;

namespace Optimization.GeneticAppliances.Warehouse
{
    internal class GeneticWarehouse
    {

        private int _warehouseSize;
        private BaseGenetic _genetic;
        private WarehouseModule wm;

        public GeneticWarehouse(OptimizationParameters optimizationParameters, int warehouseSize,
            DelegateFitness.CalcFitness calcFitness, CancellationToken ct, Random random)
        {
            _warehouseSize = warehouseSize;
            int[] itemsToSort = new int[_warehouseSize];
            for (int i = 1; i < _warehouseSize; i++)
            {
                itemsToSort[i - 1] = i;
            }

            var populationInitialization = new StandardPathInitialization(random);
            var population = populationInitialization.InitializePopulation( itemsToSort, optimizationParameters.PopulationSize, 0);
            _genetic = new BaseGenetic(optimizationParameters, population, calcFitness, ct, random);
             wm = new WarehouseModule();
            _genetic.LoadModule(wm);

        }

        public WarehouseResult Run()
        {
            var result = _genetic.OptimizeForBestIndividual();
            return new WarehouseResult()
            {
                BestChromosome = result,
                fitness = wm.GetFitnessHistory()
            };
        }

        
    }
}
