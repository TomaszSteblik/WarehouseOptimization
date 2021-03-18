using Optimization.Parameters;
using Optimization.PathFinding;
using Optimization.Warehouse;

namespace Optimization.Helpers
{
    internal class Fitness
    {
        public static double CalculateFitness(int[] path, double[][] distancesMatrix)
        {
            var sum = 0d;
            for (int i = 0; i < path.Length - 1; i++)
                sum += distancesMatrix[path[i]][path[i + 1]];
            if (path[^1] != 0) sum += distancesMatrix[path[^1]][0];
            return sum;
        }

        public static double CalculateAllOrdersFitness(Orders orders, int[] chromosome, double[][] distancesMatrix, OptimizationParameters optimizationParameters)
        {
            double fitness = 0d;
            for (int k = 0; k < orders.OrdersCount; k++)
            {
                int[] order = Translator.TranslateWithChromosome(orders.OrdersList[k], chromosome);
                double pathLength = ShortestPath.Find(order, distancesMatrix, optimizationParameters);
                fitness += pathLength * orders.OrderRepeats[k];
            }

            return fitness;
        }
    }
}