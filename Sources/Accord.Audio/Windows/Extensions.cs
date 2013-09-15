﻿// Accord Audio Library
// The Accord.NET Framework
// http://accord-framework.net
//
// Copyright © César Souza, 2009-2013
// cesarsouza at gmail.com
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

namespace Accord.Audio.Windows
{

    /// <summary>
    ///   Extension methods.
    /// </summary>
    /// 
    public static class Extensions
    {
        /// <summary>
        ///   Applies forward fast Fourier transformation to a complex signal array.
        /// </summary>
        /// 
        public static void ForwardFourierTransform(this ComplexSignal[] windows)
        {
            foreach (ComplexSignal signal in windows)
                signal.ForwardFourierTransform();
        }

        /// <summary>
        ///   Applies backward fast Fourier transformation to a complex signal array.
        /// </summary>
        /// 
        public static void BackwardFourierTransform(this ComplexSignal[] windows)
        {
            foreach (ComplexSignal signal in windows)
                signal.BackwardFourierTransform();
        }

        /// <summary>
        ///   Applies forward fast Hilbert transformation to a complex signal array.
        /// </summary>
        /// 
        public static void ForwardHilbertTransform(this ComplexSignal[] windows)
        {
            foreach (ComplexSignal signal in windows)
                signal.ForwardHilbertTransform();
        }

        /// <summary>
        ///   Applies backward fast Hilbert transformation to a complex signal array.
        /// </summary>
        /// 
        public static void BackwardHilbertTransform(this ComplexSignal[] windows)
        {
            foreach (ComplexSignal signal in windows)
                signal.BackwardHilbertTransform();
        }

        /// <summary>
        ///   Splits a signal using a window
        /// </summary>
        /// 
        public static ComplexSignal[] Split(this ComplexSignal signal, IWindow window, int step)
        {
            int n = (int)System.Math.Floor(signal.Length / (double)step);

            ComplexSignal[] windows = new ComplexSignal[n];

            for (int i = 0; i < n; i++)
            {
                windows[i] = window.Apply(signal, i * step);
            }

            return windows;
        }

        /// <summary>
        ///   Splits a signal using a window
        /// </summary>
        /// 
        public static ComplexSignal[] Split(this ComplexSignal signal, int windowSize, int step)
        {
            return signal.Split(RaisedCosineWindow.Rectangular(windowSize), step);
        }

    }
}
