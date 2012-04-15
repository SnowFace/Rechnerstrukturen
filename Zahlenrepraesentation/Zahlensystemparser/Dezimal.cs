using System;

namespace Rechnerstukturen
{
	public class Dezimal : ZDinterface
	{
		public Dezimal ()
		{
		}
		
		public Returnstack convertToDez (String zahl)
		{
			return new Returnstack (zahl);
		}

		public Returnstack convertToBin (String zahl)
		{
			Returnstack result = new Returnstack ();
			result.addStep ("Schreibe : von rechts(oben) ---> links(unten)\n\n ");
			int dezzahl = int.Parse (zahl);
			zahl = "";
			while (dezzahl!= 0) {
				zahl = dezzahl % 2 + zahl;
				result.addStep (dezzahl + "/ 2 = " + (dezzahl / 2).ToString () + " ---> R: " + (dezzahl % 2).ToString ());
				dezzahl = dezzahl / 2;
		
			}
			result.addStep ("_________________________");
			result.setResult (zahl);
			return result;
		}

		public Returnstack convertToHex (String zahl)
		{
			Returnstack result = new Returnstack ();
			result.addStep ("Schreibe : von rechts(unten) ---> links(oben)\n ");
			int dezzahl = int.Parse (zahl);
			String binzahl = "";
			while (dezzahl!= 0) {
				String synonym;
				switch (dezzahl % 16) {
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
					synonym = "F";
					break;
				default: 
					synonym = (dezzahl % 16).ToString (); 
					break;
				}
				binzahl = synonym + binzahl;
				result.addStep (dezzahl + "/ 16 = " + (dezzahl / 16).ToString () + " ---> R: " + synonym + "(" + (dezzahl % 16).ToString () + ")");
				dezzahl = dezzahl / 16;
			}
			result.addStep ("_________________________");
			result.setResult (binzahl);
			return result;
		}
	}
}

