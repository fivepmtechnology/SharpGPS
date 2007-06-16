// Copyright 2006 - Morten Nielsen (www.iter.dk)
//
// This file is part of SharpGps.
// SharpGps is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpGps is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpGps; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Collections;
using System.Windows.Forms;

namespace SharpGis.SharpGps
{
	internal delegate void MethodCallInvoker (object[] o);

	/// <summary>
	/// Control.Invoke allows a method to be invoked on the same thread as the one
	/// the control was created on.  Unlike in the full .NET Framework, the .NET
	/// Compact Framework does not support the Control.Invoke overload for passing an 
	/// array of objects to pass as arguments.  This ControlInvoker class overcomes
	/// this limitation.
	/// </summary>
	internal class ControlInvoker
	{
		private class MethodCall 
		{
			public MethodCallInvoker invoker;
			public object[] arguments;

			public MethodCall (MethodCallInvoker invoker, object[] arguments) 
			{
				this.invoker = invoker;
				this.arguments = arguments;
			}
		}

		private Control control;
		private Queue argumentInvokeList = new Queue ();

		/// <summary>
		/// The constructor typically takes a form
		/// If not, this could be changed to an object.
		/// </summary>
		/// <param name="control">Control or Form that it should invoke</param>
		public ControlInvoker (Control control) 
		{
			this.control = control;
		}

		/// <summary>
		/// The delegate wrapping the method and its arguments 
		/// to be called on the same thread as the control.
		/// </summary>
		/// <param name="invoker"></param>
		/// <param name="arguments"></param>
		internal void Invoke (MethodCallInvoker invoker, params object[] arguments) 
		{
			this.argumentInvokeList.Enqueue (new MethodCall (invoker, arguments));
			try
			{
				control.Invoke(new EventHandler(ControlInvoke));
			}
			catch(System.Exception ex)
			{
				//For debugging:
				string blah = ex.Message;
			}
		}

		private void ControlInvoke (object sender, EventArgs e) 
		{
			MethodCall methodCall = (MethodCall) argumentInvokeList.Dequeue();
			methodCall.invoker (methodCall.arguments);
		}
	}
}

