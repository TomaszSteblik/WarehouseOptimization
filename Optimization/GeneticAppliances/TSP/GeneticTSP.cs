﻿using System;
using System.Linq;
using System.Threading;
using Optimization.GeneticAlgorithms;
using Optimization.GeneticAlgorithms.Initialization;
using Optimization.GeneticAlgorithms.Modules;
using Optimization.Helpers;
using Optimization.Parameters;

namespace Optimization.GeneticAppliances.TSP
{
    public class GeneticTSP
    {
        private BaseGenetic _genetic;
        private bool _use2opt;
        public GeneticTSP(int[] order, OptimizationParameters parameters, DelegateFitness.CalcFitness calcFitness, CancellationToken ct)
        {
            _use2opt = parameters.Use2opt;
            var populationInitialization = new StandardPathInitialization();
            var population = populationInitialization.InitializePopulation(order, parameters.PopulationSize, parameters.StartingId);
            _genetic = new BaseGenetic(parameters, population, calcFitness, ct);
            
            if(parameters.StopAfterEpochsWithoutChange)
                _genetic.LoadModule(new TerminationModule(parameters.StopAfterEpochCount));
            
            _genetic.LoadModule(new CataclysmModule(populationInitialization));
            _genetic.LoadModule(new TSPModule());
        }

        

        public TSPResult Run()
        {
            var result = _genetic.OptimizeForBestIndividual();
            if (_use2opt) result = Optimizer2Opt.Optimize(result);
            var tsp = (TSPModule) _genetic.GetModule(typeof(TSPModule));
            var fitness = tsp.GetFitnessHistory();
            return new TSPResult(fitness, result);
        }
    }
}