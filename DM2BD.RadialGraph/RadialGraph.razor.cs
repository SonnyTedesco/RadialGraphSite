using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM2BD.RadialGraph
{
    public partial class RadialGraph<TItem> : ComponentBase
    {
        [Parameter]
        public List<Node> Nodes { get; set; }
        [Parameter]
        public List<Edge> Edges { get; set; }
        [Parameter]
        public int CenterNodeId { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public List<List<Node>> Rings { get; set; }
        public List<List<bool>> AdjacencyMatrix { get; set; } = new List<List<bool>>();

        public List<List<Coordinate<Node>>> RingCoordinates { get; set; } = new List<List<Coordinate<Node>>>();

        public int CenterX { get; set; } = 250;
        public int CenterY { get; set; } = 250;

        public int Radius { get; set; }

        public Node CenterNode { get; private set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Radius = 200;
            MakeAdjacencyMatrix();
        }

        private void MakeAdjacencyMatrix()
        {
            Rings = new List<List<Node>>();
            try
            {
                CenterNode = Nodes.Where(x => x.id == CenterNodeId).First();
                Rings.Add(new List<Node> { CenterNode });
                for (int i = 0; i < Nodes.Count; i++)
                {
                    List<bool> bools = new List<bool>();
                    foreach (Node node in Nodes)
                    {
                        bools.Add(false);
                    }
                    AdjacencyMatrix.Add(bools);
                }
                foreach (Edge edge in Edges)
                {
                    AdjacencyMatrix[edge.from][edge.to] = true;
                }

                List<Node> ringOne = new List<Node>();
                Rings.Add(ringOne);

                List<Node> orderDrawn = new List<Node>();

                int edgeTo = 0;
                foreach (bool hasEdge in AdjacencyMatrix[CenterNode.id])
                {
                    if (hasEdge)
                    {
                        Node drawLineTo = Nodes[edgeTo];
                        ringOne.Add(drawLineTo);
                        orderDrawn.Add(drawLineTo);
                    }
                    edgeTo++;
                }

                while (orderDrawn.Count != 0)
                {
                    Dictionary<int, List<int>> edgeMap = new Dictionary<int, List<int>>();
                    List<Node> orderDrawnLocal = new List<Node>(orderDrawn);
                    foreach (Node node in orderDrawnLocal)
                    {
                        orderDrawn = new List<Node>();
                        edgeTo = 0;
                        List<Node> ringX = new List<Node>();
                        foreach (bool hasEdge in AdjacencyMatrix[node.id])
                        {
                            if (hasEdge && edgeTo != CenterNodeId && !orderDrawnLocal.Contains(Nodes[edgeTo]) && (edgeMap.ContainsKey(edgeTo) ? !edgeMap[edgeTo].Contains(node.id) : true))
                            {
                                if (!edgeMap.ContainsKey(node.id))
                                    edgeMap.Add(node.id, new List<int>());

                                edgeMap[node.id].Add(edgeTo);

                                Node drawLineTo = Nodes[edgeTo];
                                ringX.Add(drawLineTo);
                                orderDrawn.Add(drawLineTo);
                            }
                            edgeTo++;
                        }
                        if (ringX.Count != 0) Rings.Add(ringX);
                    }
                }
                DrawRings();
            }
            catch (InvalidOperationException)
            {
                Errors.Add("CenterNodeId not found in Nodes");
                StateHasChanged();
            }
        }

        private void DrawRings()
        {
            int ringCounter = 0;
            foreach (List<Node> ring in Rings.Skip(1))
            {
                double radius = Radius * ((ringCounter + 1.0) / (Rings.Count - 1.0));
                RingCoordinates.Add(new List<Coordinate<Node>>());
                double angle = 0;
                double incrementor = 2.0 * Math.PI / ring.Count;
                foreach (Node item in ring)
                {
                    RingCoordinates[ringCounter].Add(new Coordinate<Node> { CoordinateX = CenterX + (radius * Math.Cos(angle)), CoordinateY = CenterY + (radius * Math.Sin(angle)), Item = item });
                    angle += incrementor;
                }
                ringCounter++;
            }
        }
    }
}
