using System;
using System.Collections.Generic;
using System.Text;
//Data Type representing an edge from vertex v to vertex w with an associated weight/cost;
//USE: used in EdgeWeightedDiGraph DT  to calculate weight of various paths from a source to a destination
namespace DirectionalGraphs
{
    class DirectedEdge
    {
        private int _v;
        private int _w;
        private double _weight;
        public DirectedEdge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        public int From() => _v;
        public int To() => _w;
        public double Weight() => _weight;
        public override string ToString()
        {
            return String.Format("Edge from: {0} To: {1} Weight: {2}", _v, _w, _weight);
        }

    }
}
