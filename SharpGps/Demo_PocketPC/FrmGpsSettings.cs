// Copyright 2007 - Morten Nielsen
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_cs
{
	public partial class FrmGpsSettings : Form
	{
		public FrmGpsSettings()
		{
			InitializeComponent();
			cmbPorts.DataSource = System.IO.Ports.SerialPort.GetPortNames();
		}
		public string SerialPort
		{
			get { return cmbPorts.SelectedValue.ToString(); }
		}
		public int BaudRate
		{
			get { return int.Parse(tbBaudRate.Text); }
			set { tbBaudRate.Text = value.ToString(); }
		}
	}
}