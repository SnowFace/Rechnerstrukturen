using System;
using Gtk;

public partial class GUI: Gtk.Window
{	
	public GUI (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected void OnBeendenActionActivated (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	protected void OnZdbconvertClicked (object sender, System.EventArgs e)
	{
		int cfrom = this.zdcbchosefrom.Active;
		int cto = this.zdcbchoseto.Active;
		String zahl = this.zdezahl.Text;	
		Rechnerstukturen.Zahlendarstellung z = new Rechnerstukturen.Zahlendarstellung (zahl, cfrom, cto);
		z.convert (new Rechnerstukturen.Ausgabe (this.textview1));
	}
	
	protected void OnZdbdarstellungClicked (object sender, System.EventArgs e)
	{
		Boolean rbto = this.zdrbto.Active;
		Boolean rbfrom = this.zdrbfrom.Active;
		String[] dart =  {"betrag","festbetr","vorbetr","1er","2er"};
		if (rbto) {
			new Rechnerstukturen.Binaerdarstellungen (new Rechnerstukturen.Ausgabe (this.textview1), dart[this.zdcbdarstellung.Active], "to", this.zdedarstellung.Text).convert ();
		} else {
			if (rbfrom) {
				new Rechnerstukturen.Binaerdarstellungen (new Rechnerstukturen.Ausgabe (this.textview1), dart[this.zdcbdarstellung.Active], "from", this.zdedarstellung.Text).convert ();
			}
		}
		
	}

	protected void OnRdbexzessClicked (object sender, System.EventArgs e)
	{
		Boolean rbto = this.zdrbexto.Active;
		Boolean rbfrom = this.zdrbexfrom.Active;
		if (rbto) {
			new Rechnerstukturen.Exzessdarstellung (this.zdeexzess.Text, this.zdebias.Text).convertTo ( );
		} else {
			if (rbfrom) {
			new Rechnerstukturen.Exzessdarstellung (this.zdeexzess.Text, this.zdebias.Text).convertFrom( );
			}
		}
	}

	protected void OnGKZBClicked (object sender, System.EventArgs e)
	{
	Rechnerstukturen.GKAGUIinterface inter =	new Rechnerstukturen.GKAGUIinterface(this.GKZ1E, this.GKZ2E, this.GKZ1Evz, this.GKZ1Eex, this.GKZ1Eman,this.GKZ2Evz, this.GKZ2Eex, this.GKZ2Eman,this.GKZEerg,this.GKZTV);
	new Rechnerstukturen.Gleitkommaarithmetik(inter, this.GKZ1E.Text,this.GKZ2E.Text).run();
	}
}

