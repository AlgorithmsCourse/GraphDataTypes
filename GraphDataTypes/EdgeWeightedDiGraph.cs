using System;
using System.Collections.Generic;
using System.Text;


namespace DirectionalGraphs
{   //DESC: represents a network where sites are connected by a single direction edge associated with a cost (DirectedEdge)
    class EdgeWeightedDiGraph
    {
        private int _v;
        private int _e;
        private LinkedList<DirectedEdge>[] _adj;

        //ctor takes num of vertices, and inits an empty v-vertex graph
        public EdgeWeightedDiGraph(int v)
        {
            _v = v;
            _e = 0;
            _adj = new LinkedList<DirectedEdge>[_v];
            for (int i =0; i<v; i++)
            {
                _adj[i] = new LinkedList<DirectedEdge>();
            }
        }
        //ctor takes in input passed from main method in form of string[], row 1 is num of verts, row 2 is num of Edges, and all remaining rows repr: [0] vertex v; [1]vertex w; [2] weight of the edge.
        //ctor passes relevatant information to other ctor and methods in order to contruct the graph from the data
        public EdgeWeightedDiGraph(string[] input): this(Convert.ToInt32(input[0]))
        {
            for(var i =2; i<input.Length; i++)
            {
                string[] temp = input[i].Split();
                int v = Convert.ToInt32(temp[0]);
                int w = Convert.ToInt32(temp[1]);
                double weight = Convert.ToDouble(temp[2]);
                var newEdge = new DirectedEdge(v, w, weight);
                AddEdge(newEdge);
            }
        }
        public int V { get => _v; }
        public int E { get => _e; set => _e = value; }
        public void AddEdge(DirectedEdge e)
        {
            _adj[e.From()].AddFirst(e);
        }
        //returns all edges adjacent to the given vertex v
        public IEnumerable<DirectedEdge> Adj(int v) => _adj[v];
        //returns a collection of all the edges; uses a list collection to allow size flex
        public IEnumerable<DirectedEdge> Edges()
        {
            var edges = new List<DirectedEdge>();
            for(var i = 0; i< _v; i++)
            {
                foreach( var edge in _adj[i])
                {
                    edges.Add(edge);
                }
            }
            return edges;
        }

        public override string ToString()
        {
            var strRep = new StringBuilder();
            for (var i = 0; i < _v; i++)
            {
                
                strRep.AppendFormat("Vertex {0} has edges to ", i);
                foreach (var edge in _adj[i])
                {
                    strRep.Append(edge.To() + " ");
                }
                strRep.Append("\n");
            }
            return strRep.ToString();
        }



    }
}
