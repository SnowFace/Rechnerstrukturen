using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Rechnerstukturen
{
	public class Betragszahl : BDInterface
	{
		
		
		public Betragszahl ()
		{
		}
		
		private Boolean analyse (String wert)
		{
			String patter;
			switch (new StackTrace ().GetFrame (1).GetMethod ().Name) {
				case "convertTo":
					patter = "[^0-9]";
					break;
				case "convertFrom":
					patter = "[^0-1]";
					break;
				default:
					return false;
			}
			if (new Regex (patter).Match(wert).Success) 
				return false;
			else
				return true;
		}
		
		public Returnstack convertTo (String wert)
		{
			if(!this.analyse (wert)){
				Returnstack result = new Returnstack("Falsche Syntax!\nEs sind nur die Zeichen '0-9' erlaubt.");
				result.addStep("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			
			return new Dezimal ().convertToBin (wert);
		}

		public Returnstack convertFrom (String wert)
		{
			if(!this.analyse (wert)){
				Returnstack result = new Returnstack("Falsche Syntax!\nEs sind nur die Zeichen '0-1' erlaubt.");
				result.addStep("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			return new Binaer ().convertToDez (wert);	
		}
			
		
		
	}
}

