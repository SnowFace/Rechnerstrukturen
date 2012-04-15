using System;
using System.Text.RegularExpressions;

namespace Rechnerstukturen
{
	public class Exzessdarstellung
	{
		private String wert;
		private String bias;
		
		public Exzessdarstellung (String wert, String bias)
		{
			this.bias = bias;
			this.wert = wert;
		}

		public Returnstack convertTo ()
		{
			return convert ("to");
		}

		public Returnstack convertFrom ()
		{
			return convert ("from");
		}
		
		private Returnstack convert (String type)
		{
			Returnstack convert = new Returnstack ();
			convert.addStep ("Prüfen der ausgangs Parameter;");
				
			if (wert == "") {
				convert.setResult ("Kein Wert");
				return convert;
			}
			if (bias == "") {
				convert.setResult ("Missing Bias");
				return convert;
			}
			if (new Regex ("[^0-9]").Match (this.bias).Success) {
				convert.setResult ("Wrong Syntax");
				return convert;
			}
			
			switch (type) {
				
				case "to":	
					if (new Regex ("[^0-9\\-]").Match (this.wert).Success) {
						convert.setResult ("Wrong Syntax");
						return convert;
					}
			    
				
					String erg = ((int)(Double.Parse (wert) + Double.Parse (bias))).ToString ();
					convert = new Dezimal ().convertToBin (erg);	
					return convert;

				case "from": 
				
					if (new Regex ("[^0-1]").Match (this.wert).Success) {
						convert.setResult ("Wrong Syntax");
						return convert;
					}
				
				
					convert = new Binaer ().convertToDez (wert);
					convert.setResult (((int)(Double.Parse (convert.getResult ()) - Double.Parse (bias))).ToString ());
					return convert;				
				default : 
					return convert;
			}
			
			
			
	
			

		}
	}
}

