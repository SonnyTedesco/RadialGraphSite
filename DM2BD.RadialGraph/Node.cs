using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DM2BD.RadialGraph
{
    public enum NodeShapes
    {
        ellipse, circle, database, box, text, image, circularImage, diamond, dot, star, triangle, triangleDown, hexagon, square, icon
    }

    /// <summary>
    /// http://visjs.org/docs/network/nodes.html
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 	The size is used to determine the size of node shapes that do not have the label inside of them. These shapes are: image, circularImage, diamond, dot, star, triangle, triangleDown, hexagon, square and icon
        /// </summary>
        public virtual double? size { get; set; }

        public virtual double? x { get; set; }
        public virtual double? y { get; set; }
        /// <summary>
        /// The id of the node. The id is mandatory for nodes and they have to be unique. This should obviously be set per node, not globally.
        /// </summary>
        public virtual int id { get; set; }

        /// <summary>
        /// The label is the piece of text shown in or under the node, depending on the shape.
        /// </summary>
        public virtual string label { get; set; }

        /// <summary>
        /// Title to be displayed when the user hovers over the node. The title can be an HTML element or a string containing plain text or HTML.
        /// </summary>
        public virtual string title { get; set; }

        /// <summary>
        /// The shape defines what the node looks like. There are two types of nodes. One type has the label inside of it and the other type has the label underneath it. The types with the label inside of it are: ellipse, circle, database, box, text. The ones with the label outside of it are: image, circularImage, diamond, dot, star, triangle, triangleDown, hexagon, square and icon.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual NodeShapes shape { get; set; }
        public virtual string image { get; set; }
        public virtual string brokenImage { get; set; }

        public virtual string group { get; set; }

        public virtual Color color { get; set; }

        //color: {background:'cyan', border:'blue',highlight:{background:'red',border:'blue'},hover:{background:'white',border:'red'}}}
        //])
    }

    public class ColorValues
    {
        public virtual string background { get; set; }
        public virtual string border { get; set; }
    }
    public class Color : ColorValues
    {
        public virtual ColorValues highlight { get; set; }
        public virtual ColorValues hover { get; set; }

    }   
}
