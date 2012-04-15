using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Rechnerstukturen
{
	public class Vorzeichenbetrag : BDInterface
	{
		
		
		public Vorzeichenbetrag ()
		{
		}
		
		private Boolean analyse (String wert)
		{
			String patter;
			switch (new StackTrace ().GetFrame (1).GetMethod ().Name) {
				case "convertTo":
					patter = "[^0-9\\-]";
					break;
				case "convertFrom":
					patter = "[^0-1]";
					break;
				default:
					return false;
			}
			if (new Regex (patter).Match (wert).Success) 
				return false;
			else
				return true;
		}
		
		public Returnstack convertTo (String wert)
		{
			Returnstack result = new Returnstack ();
					
			if (!this.analyse (wert)) {
				result = new Returnstack ("Falsche Syntax!\nEs sind nur die Zeichen '0-9' und '-' erlaubt.");
				result.addStep ("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
				
			if (wert [0] == '-') {
				wert = wert.Remove (0, 1);
				result += "1";
			}
			result += new Dezimal ().convertToBin (wert);
			return result;
		}

		public Returnstack convertFrom (String wert)
		{ 
			
			Returnstack result = new Returnstack ();
			
			if (!this.analyse (wert)) {
				result = new Returnstack ("Falsche Syntax!\nEs sind nur die Zeichen '0-1' erlaubt.");
				result.addStep ("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			if (wert [0] == '1') {
				wert = wert.Remove (0, 1);
				result += "-";
			}
			result += new Binaer ().convertToDez (wert).getResult ();
			return result;
				
		}
			
			
		
			

	}
}


