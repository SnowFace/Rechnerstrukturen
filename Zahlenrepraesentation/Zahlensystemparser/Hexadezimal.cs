using System;

namespace Rechnerstukturen
{
	public class Hexadezimal : ZDinterface
	{
		public Hexadezimal ()
		{
		}

	
		public Returnstack convertToHex (String zahl)
		{
		return new Returnstack(zahl);
		}

		public Returnstack convertToBin (String zahl)
		{
			Returnstack result = new Returnstack();
			Returnstack interimresult = convertToDez (zahl);
			result.addStep("In Dezimal umwandeln.\n");	
			result+=interimresult;	
			result.addStep("Zwischenergebnis: " + interimresult.getResult ());
			interimresult = new Dezimal().convertToBin(interimresult.getResult());
			result.addStep("\n Von Dezimal in Binaer umwandeln.\n");
			result+=interimresult;
			result.setResult(interimresult.getResult());
			return result;
			
		}

		public Returnstack convertToDez (String zahl)
		{
			Returnstack result = new Returnstack();
			int dezzahl = 0;
			for (int i = 0; i < zahl.Length; i++) {
				int zwergebnis= table(zahl [zahl.Length-1-i])*(int)(Math.Pow(16,i));
				result.addStep((zahl [zahl.Length-1-i]).ToString()+": " + (table(zahl [zahl.Length-1-i])).ToString()+"*"+((int)(Math.Pow(16,i))).ToString() );
				dezzahl += zwergebnis;
			}
			result.addStep("__________________________");
			result.setResult(dezzahl.ToString());
			return result;
		}
		
		private int table (char zahl)
		{
			switch (zahl.ToString ().ToUpper ()) {
			case "A":
				return 10;
			case "B":
				return 11;
			case "C":
				return 12;
			case "D":
				return 13;
			case "E":
				return 14;
			case "F":
				return 15;
			default:
				return int.Parse (zahl.ToString ());
				
			}
			
		}
	}
}

