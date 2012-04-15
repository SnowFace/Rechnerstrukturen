using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Rechnerstukturen
{
	public class Festkomma : BDInterface
	{
		
		private int parts;
		
		public Festkomma ()
		{
			
		
		}
		
		

		public Returnstack convertTo (String wert)
		{
			if(!this.analyse (wert)){
				Returnstack result = new Returnstack("Falsche Syntax!\nEs sind nur die Zeichen '0-9' und ',' erlaubt.");
				result.addStep("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			this.getParts (wert);
			
			String[] splited = wert.Split (',');				
			Returnstack erg = new Dezimal ().convertToBin (splited [0]);			
			if (this.parts == 2) {
					
				Double zwerg = Double.Parse ("0," + splited [1]);
				erg += ",";
				while (zwerg!=1) {
					zwerg = zwerg * 2;
					if (zwerg > 1) {
						zwerg -= 1;
						erg += "1";
					} else {
						if (zwerg == 1) {
							erg += "1";
							break;
						}
						erg += "0";
					}
				}
			}
		
			return erg;
		}

		public Returnstack convertFrom (String wert)
		{
			if(!this.analyse (wert)){
				Returnstack result = new Returnstack("Falsche Syntax!\nEs sind nur die Zeichen '0-1' und ',' erlaubt.");
				result.addStep("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			
			this.getParts (wert);
			String[] splited = wert.Split (',');
				
			Returnstack part1 = new Binaer ().convertToDez (splited [0]);
			if (this.parts == 2) {					
				Returnstack part2 = new Binaer ().convertToDez (splited [1]);						
				part2.setResult ((Double.Parse (part2.getResult ()) / (int)Math.Pow (2, splited [1].Length)).ToString ().Split (',') [1]);	
				part1 += "," + part2.getResult ();
			} else
				part1 += ",0";
			return part1;
		}
			
			
	
		private Boolean analyse (String wert)
		{
			String patter;
			switch (new StackTrace ().GetFrame (1).GetMethod ().Name) {
				case "convertTo":
					patter = "[^0-9,]";
					break;
				case "convertFrom":
					patter = "[^0-1,]";
					break;
				default:
					return false;
			}
			if (new Regex (patter).Match (wert).Success) 
				return false;
			else
				return true;
		}
		
		private void getParts (String wert)
		{
		
			String[] splited = wert.Split (',');
			
			if (wert [wert.Length - 1] == ',')
				this.parts = 1;
			else {
				if (splited.Length == 2)
					this.parts = 2;
				else
					this.parts = 1;
			}
			
		}	

	}
}
