using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Rechnerstukturen
{
	public class EinerKomp : BDInterface
	{
		
		public EinerKomp ()
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
			
		
			Returnstack dezimal = new Dezimal ().convertToBin (wert);
			
			String steps = "";
			for (int i = 0; i< dezimal.getSteps().Length; i++) {
				steps += dezimal.getSteps () [i] + "|";
			}
			
			if (wert [0] == '-') {
				wert = wert.Remove (0, 1);
				result.setResult ("1" + new Dualoperationen ().invert (dezimal.getResult ()));
				
			} else {
				result.setResult (dezimal.getResult ());
			}
	
			result.addStep (steps);
			return result;

		}
		
		public Returnstack convertFrom (String wert)
		{
			
			Returnstack result = new Returnstack ();
			
			if (!this.analyse (wert)) {
				result = new Returnstack ("Falsche Syntax!\nEs sind nur die Zeichen '0-1' erlaubt.");
				result.addStep("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			
			String vorzeichen = "";
			if (wert [0] == '1') {
				wert = wert.Remove (0, 1);
				vorzeichen = "-";
			}
			
			Returnstack dezimal = new Binaer ().convertToDez (new Dualoperationen ().invert (wert));
		
			String steps = "";
			for (int i = 0; i< dezimal.getSteps().Length; i++) {
				steps += dezimal.getSteps() [i] + "|";
			}	
			
			result.setResult (vorzeichen + dezimal.getResult ());
			result.addStep (steps);
			return result;
		}
			
				
		
					
	}
			
}


