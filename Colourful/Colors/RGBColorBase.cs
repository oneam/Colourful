﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;

namespace Colourful.Colors
{
    /// <summary>
    /// RGB color without working space
    /// </summary>
    public class RGBColorBase : IColorVector
    {
        #region Constructor

        internal RGBColorBase(double r, double g, double b)
        {
            R = r.CheckRange(0, 1);
            G = g.CheckRange(0, 1);
            B = b.CheckRange(0, 1);
        }

        #endregion

        #region Channels

        public double R { get; private set; }
        public double G { get; private set; }
        public double B { get; private set; }

        public Vector<double> Vector
        {
            get { return DenseVector.OfEnumerable(new[] { R, G, B }); }
        }

        #endregion

        #region Equality

        protected bool Equals(RGBColorBase other)
        {
            return R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RGBColorBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = R.GetHashCode();
                hashCode = (hashCode*397) ^ G.GetHashCode();
                hashCode = (hashCode*397) ^ B.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(RGBColorBase left, RGBColorBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RGBColorBase left, RGBColorBase right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}