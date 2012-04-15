using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Rechnerstukturen
{
	public class ZweierKomp : BDInterface
	{	
		
		
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
			if (!this.analyse (wert)) {
				Returnstack result = new Returnstack ("Falsche Syntax!\nEs sind nur die Zeichen '0-9' und '-' erlaubt.");
				result.addStep ("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			
			int vorzeichen = 0;
			if (wert [0] == '-') {
				wert = wert.Remove (0, 1);
			    vorzeichen = 1;
			}
			Returnstack convert = new Dezimal ().convertToBin (wert) ;	
			
			if(vorzeichen == 1){
				convert.setResult( "1" + new Dualoperationen ().addieren (new Dualoperationen ().invert (convert.getResult ()), "1"));
			} else {	
				convert.setResult( "0" + convert.getResult ());
			}
			return convert;
		}

		public Returnstack convertFrom (String wert)
		{
			if (!this.analyse (wert)) {
				Returnstack result = new Returnstack ("Falsche Syntax!\nEs sind nur die Zeichen '0-1' erlaubt.");
				result.addStep ("Analyse ergabe Fehler in der Syntax.");
				return result;
			}
			
			Returnstack convert ;
					

			if (wert [0] == '1') {
				wert = wert.Remove (0, 1);
				convert = new Binaer ().convertToDez (new Dualoperationen ().invert (wert));
				convert.setResult( "-" + (int.Parse (convert.getResult ()) + 1).ToString ());
			} else {			
				convert = new Binaer ().convertToDez (wert);
			}
			return convert;
				
			
		}
			
			
			
	
			

	}
}
	


