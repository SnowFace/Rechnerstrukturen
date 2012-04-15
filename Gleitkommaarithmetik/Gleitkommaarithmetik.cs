using System;

namespace Rechnerstukturen
{
	public class Gleitkommaarithmetik
	{
		private GKzahl a;
		private GKzahl b;
		private GKAGUIinterface inter;
		public Gleitkommaarithmetik (GKAGUIinterface inter, String zahl1, String zahl2)
		{
			this.a = new GKzahl(zahl1);
			this.b = new GKzahl(zahl2);
			this.inter = inter;
		}
		
		public void run(){
			GKzahl result = a*b;
			inter.setVZ1(a.getVZ());
			inter.setVZ2(b.getVZ());
			inter.setExpo1(a.getExpo());
			inter.setExpo2(b.getExpo());
			inter.setMan1(a.getMantisse());
			inter.setMan2(b.getMantisse());
			inter.setErg(result.getGKZ());
			inter.writeLine(result.ToString());
		}
	}
}

