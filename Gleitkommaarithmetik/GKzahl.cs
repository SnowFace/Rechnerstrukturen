using System;
using System.Text.RegularExpressions;

namespace Rechnerstukturen
{
	public class GKzahl
	{
		private String VZ;
		private String Expo;
		private String Mant;
		//private String[] history;
		
		public GKzahl (String zahl)
		{
			if (new Regex ("[0-1]").Match (zahl).Success && zahl.Length == 32) {
				this.VZ = zahl.Substring (0, 1);
				this.Expo = zahl.Substring (1, 8);
				this.Mant = zahl.Substring (9, 23);
		
				int split = Mant.Length - 1;
				for (int i = Mant.Length-1; i> 0; i--) {
					if (String.Compare (Mant [i].ToString (), "0", true) == 0)
						split--;
					else
						break;
				}
				this.Mant = Mant.Remove (split + 1, Mant.Length - split - 1);				
			} else {
				this.VZ = null;
				this.Expo = null;
				this.Mant = null;
			}
			
		}

		public static GKzahl operator * (GKzahl zahla, GKzahl zahlb)
		{
			String VZ,trimmedexpo,Expo,Mantisse;
			Dualoperationen op = new Dualoperationen ();
			 VZ = op.xor (Char.Parse (zahla.getVZ ()), Char.Parse (zahlb.getVZ ())).ToString ();
			 trimmedexpo = op.addieren (zahlb.getExpo ().Remove (0, 1), "1");
			 Expo = op.addieren (zahla.getExpo (), trimmedexpo);
			 Mantisse = op.mult ("1" + zahla.getMantisse (), "1" + zahlb.getMantisse ());
			for (int i = 0; i < Mantisse.Length-(zahla.getMantisse().Length + zahlb.getMantisse ().Length+2); i++) {
				Expo = op.addieren (Expo, "1");
			}
			Mantisse = Mantisse.Remove (0, 1);
			String ergaenzendenullen = "";
			for (int i = Mantisse.Length; i <23; i++) {
				ergaenzendenullen += "0";	
			}
			return new GKzahl (VZ + Expo + Mantisse + ergaenzendenullen);
			
			
		}

		public String getVZ ()
		{
			return this.VZ;
		}

		public String getExpo ()
		{
			return this.Expo;
		}

		public String getMantisse ()
		{
			return this.Mant;
		}
		
		public String getGKZ ()
		{
			String ergaenzendenullen = "";
			for (int i = this.Mant.Length; i <23; i++) {
				ergaenzendenullen += "0";	
			}
			return this.VZ + this.Expo + this.Mant + ergaenzendenullen;
		}

		public static String formatDezToGkz (String zahl)
		{
			return "";
		}

		public static String fromatGkzToDez (String zahl)
		{
			return "";
		}

		public override String ToString ()
		{
			String help = this.Mant.Remove (0, 3);
			String formatiert = "";
			
			for (int i = 0; i < help.Length; i=i+4) {
				int grenze = 4;
				if (help.Length - i <= 0)
					grenze = (help.Length - i) % 4;
				
				for (int j = 0; j < grenze; j++)
					formatiert += help [j].ToString ();
				formatiert += " ";
				
			}
			return this.VZ + " " + this.Expo.Substring (0, 4) + " " + this.Expo.Substring (3, 4) + " " + this.Mant.Substring (0, 3) + " " + formatiert;
		}
	}
}

