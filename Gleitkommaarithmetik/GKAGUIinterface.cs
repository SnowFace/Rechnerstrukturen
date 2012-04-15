using System;
using Gtk;

namespace Rechnerstukturen
{
	public class GKAGUIinterface
	{
		private Entry gkz1e;
		private Entry gkz2e;
		private Entry gkz1evz;
		private Entry gkz1eex;
		private Entry gkz1eman;
		private Entry gkz2evz;
		private Entry gkz2eex;
		private Entry gkz2eman;
		private Entry gkzeerg;
		private TextView gkztv;
		
		public GKAGUIinterface (Entry gkz1e, Entry gkz2e, Entry gkz1evz, Entry gkz1eex, Entry gkz1eman, Entry gkz2evz,
                             Entry gkz2eex, Entry gkz2eman, Entry gkzeerg, TextView gkztv)
		{
			this.gkz1e = gkz1e;
			this.gkz2e = gkz2e;
			this.gkz1evz = gkz1evz;
			this.gkz1eex = gkz1eex;
			this.gkz1eman = gkz1eman;
			this.gkz2evz = gkz2evz;
			this.gkz2eex = gkz2eex;
			this.gkz2eman = gkz2eman;
			this.gkzeerg = gkzeerg;
			this.gkztv = gkztv;
		}
		
		public void setVZ1 (String wert)
		{
			this.gkz1evz.Text = wert;
		}

		public void setMan1 (String wert)
		{
			this.gkz1eman.Text = wert;
		}
	
		public void setExpo1 (String wert)
		{
			this.gkz1eex.Text = wert;
		}
		
		public void setVZ2 (String wert)
		{
			this.gkz2evz.Text = wert;
		}

		public void setMan2 (String wert)
		{
			this.gkz2eman.Text = wert;
		}
	
		public void setExpo2 (String wert)
		{
			this.gkz2eex.Text = wert;
		}
		
		public void setErg (String wert)
		{
			this.gkzeerg.Text = wert;
		}
		
		public void writeLine (String wert)
		{
			if (this.gkztv.Buffer.Text == "")
				this.gkztv.Buffer.Text = wert;
			else
				this.gkztv.Buffer.Text = this.gkztv.Buffer.Text + "\n" + wert;
		}

		public void write (String wert)
		{
			this.gkztv.Buffer.Text = wert;
		}

		public void clear ()
		{
			this.gkztv.Buffer.Clear ();
		}
	}

}
