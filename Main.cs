using System;
using Gtk;

namespace Rechnerstukturen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			GUI gui = new GUI ();
			gui.Show ();
			Application.Run ();
		}
	}
}
