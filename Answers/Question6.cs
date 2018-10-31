using System;
//using System.Collections.Generic;
using Dijkstra.NET.Extensions;
using Dijkstra.NET.Model;

namespace credit_suisse
{


public class Question6
    {
        
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            // Initialise new Graph
            var graph = new Graph<int, string>();

            for(int i=0; i<numOfServers; i++)
                {graph.AddNode(i);}
            
            // Populate Graph With Adjacency Matrix
            for(int i=0; i<numOfServers; i++)
                {
                for(uint j=0; j<numOfServers; j++)
                    graph.Connect(Convert.ToUInt32(i), j, connectionTimeMatrix[i,j], "n/a");
                    
                }

            // Calculate shortest route
            ShortestPathResult result = graph.Dijkstra(0,Convert.ToUInt32(targetServer)); //result contains the shortest path

            return result.Distance;
        }

    }
}
