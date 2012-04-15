using System;

namespace Rechnerstukturen
{
	public class Binaer : ZDinterface
	{
		public Binaer ()
		{
		}

		public Returnstack convertToBin (String zahl)
		{
			return new Returnstack(zahl);
		}
		
		public Returnstack convertToDez (String zahl)
		{
			Returnstack result = new Returnstack ();
			
			int z = 0;
			for (int i = 0; i < zahl.Length; i++) {
				int help = int.Parse (zahl[zahl.Length-1-i].ToString ());
				z += help * (int)Math.Pow (2, i);
			result.addStep(help+" *2^"+i+" = "+(help * (int)Math.Pow (2, i)));
				
			}
			result.addStep("__________________________");
			result.setResult(z.ToString());
			return result;
		}
		
		public Returnstack convertToHex (String zahl)
		{
			String z = "";
			Returnstack result = new Returnstack();
			result.addStep("[Info] Binaerzahlen ließt man von rechts -> links.");
			result.addStep("Vier Stellen einer Binaerzahl ergeben eine Stelle einer Hexzahl. ");
			result.addStep("Berechnung:");
			result.addStep("Hexstelle = binSt[1]*2^0 + binSt[2]*2^1 + binSt[3]*2^2 + binSt[4]*2^3");
			result.addStep("Wenn 9 < Hexstelle < 16 werden die Zahlen durch die Buchstaben A-F ersetzt. ");
			result.addStep("Hexstelle kann nicht <= 16 sein, da 1111(Bin) = 15 (Dez)");
			result.addStep("Oben ist rechts, unten links");
			result.addStep("\n\n");
			
			
			
			for (int i = 0; i < zahl.Length; i+=4) {
				int x = 0;
				String binzahl ="";
				for (int j = 0; j <=3; j++) {
					if (i + j < zahl.Length) {
						binzahl= zahl [zahl.Length-1-i - j].ToString()+"*2^"+j.ToString()+" "+binzahl;
						x += Convert.ToInt32 (zahl [zahl.Length-1-i - j].ToString ()) * (int)Math.Pow (2, j);
					} else
				
						break;
				}
					String synonym ;
				switch (x) {
				case 10:
					synonym = "A";
					break;
				case 11:
					synonym = "B";
					break;
				case 12:
					synonym = "C";
					break;
				case 13:
					synonym = "D";
					break;
				case 14: 
					synonym = "E";
					break;
				case 15:
					synonym= "F";
					break;
				default: 
				 synonym = x.ToString ();
					break;
				}
				
				z = synonym + z;
				result.addStep(binzahl+" = "+synonym+" ("+x.ToString()+")");
			}
			
			result.setResult(z);
			return result;
			
		}	
	}
}

