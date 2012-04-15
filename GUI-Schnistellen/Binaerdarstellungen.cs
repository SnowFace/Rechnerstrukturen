using System;

namespace Rechnerstukturen
{
	public class Binaerdarstellungen
	{
		private Ausgabe ausgabe;
		private BDInterface dart; //  {"betrag","festbetr","vorbetr","1er","2er"}
		private String wert;
		private String type;
		
		public Binaerdarstellungen (Ausgabe ausgabe, String darstellungsart, String type, String wert)
		{
			this.ausgabe = ausgabe;
			switch (darstellungsart) {
			case "betrag":
				this.dart = new Betragszahl ();
				break;
			case "festbetr":
				this.dart =  new Festkomma ();
				break;
			case "vorbetr":
				this.dart =  new Vorzeichenbetrag ();
				break;
			case "1er":
				this.dart =  new EinerKomp ();
				break;
			case "2er":
				this.dart =  new ZweierKomp ();
				break;
			default:
				break;
			}
			this.wert = wert;
			this.type = type;
		}
		
		
		public void convert ()
		{
			//if (!analyzing (dart ))
			//	return;
			Returnstack result ;
			ausgabe.clear();
			switch(type){
				case "to":
					result = dart.convertTo(wert);
					if(result.getSteps()!=null){
				for (int i = 0; i< result.getSteps().Length; i++) {
					ausgabe.writeLine (result.getSteps () [i]);
				}
				}
				ausgabe.writeLine ("Ergebnis: " + result.getResult ());
					break;
				case "from":
					result = dart.convertFrom(wert);
					if(result.getSteps()!=null){
				for (int i = 0; i< result.getSteps().Length; i++) {
					ausgabe.writeLine (result.getSteps () [i]);
				}
				}
				ausgabe.writeLine ("Ergebnis: " + result.getResult ());
					break;
				default:
					return;
			}
			
			
		}
	}
}

