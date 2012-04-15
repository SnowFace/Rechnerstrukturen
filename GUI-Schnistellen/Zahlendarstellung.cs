using System;
using System.Text.RegularExpressions;

namespace Rechnerstukturen
{
	public class Zahlendarstellung
	{
		private ZDinterface type;
		private String zahl;
		private int cto;
		private String[] legende = {"bin","dez","hex"};
		
		
		
	
		public Zahlendarstellung (String zahl, int cfrom, int cto)
		{
			this.zahl = zahl;
			this.cto = cto;
			if (new Regex ("[0-9a-zA-Z]*\\|[0-9]*:[0-9]*").Match (zahl).Success) {
				String[] syntax = zahl.Split ('|');
				this.zahl = syntax [0];
				syntax = syntax [1].Split (':');
				switch (syntax [0]) {
				case "2": 
					cfrom = 0;
					break;
				case"10":
					cfrom = 1;
					break;
				case"16":
					cfrom = 2;
					break;
				default:
					break;
					
				}
				
				switch (syntax [1]) {
				case "2": 
					this.cto = 0;
					break;
				case"10":
					this.cto = 1;
					break;
				case"16":
					this.cto = 2;
					break;
				default:
					break;
					
				}
			
			
			}
			
			switch (cfrom) {
			case 0 :
				this.type = new Binaer ();
				break;
			case 1:
				this.type = new Dezimal ();
				break;
			case 2:
				this.type = new Hexadezimal ();
				break;
			default:
				break;
				
			}
			
		}
		
		public void convert (Ausgabe ausgabe)
		{
			ausgabe.clear ();
			Regex patter = new Regex ("[^A-Za-z0-9]");
			Boolean ok = patter.Match (this.zahl).Success;
			if (ok) {
				ausgabe.write ("Wrong Syntax");
				return;
			}
			Returnstack result;
			switch (legende [this.cto]) {
				
			case "bin":			
				result = type.convertToBin (this.zahl);
				if (result.getSteps () != null) {
					for (int i = 0; i< result.getSteps().Length; i++) {
						ausgabe.writeLine (result.getSteps () [i]);
					}
				}
				ausgabe.writeLine ("Ergebnis: " + result.getResult ());
				
				break;
				
			case "dez":
				result = type.convertToDez (this.zahl);				
				if (result.getSteps () != null) {
					for (int i = 0; i< result.getSteps().Length; i++) {
						ausgabe.writeLine (result.getSteps () [i]);
					}
				}
				ausgabe.writeLine ("Ergebnis: " + result.getResult ());
				break;
				
			case "hex":
				result = type.convertToHex (this.zahl);				
				if (result.getSteps () != null) {
					for (int i = 0; i< result.getSteps().Length; i++) {
						ausgabe.writeLine (result.getSteps () [i]);
					}
				}
				ausgabe.writeLine ("Ergebnis: " + result.getResult ());
				break;
				
			default:
				break;
			}
			
		}
	}
}

