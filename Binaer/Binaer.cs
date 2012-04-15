using System;
using System.Text.RegularExpressions;

namespace Rechnerstukturen
{
	public class Binaer
	{
		private String wert;

		private Binaer (String wert)
		{
			this.wert = wert; 
		}
		
		public static Binaer create (String wert)
		{
			if (new Regex ("[0-1]").Match (zahl).Success) 
				return new Binaer (wert);
			else
				return null;			
		}
		
			public static Binaer operator *(Binaer wert1, Binaer wert2){
			
			String result = "0";
			for(int i = 0; i < wert2.Length; i++){
				if(String.Compare(wert2[i].ToString(),"1",true)== 0){
				result = addieren(result, wert1);
				}
				result+="0";
			}
			return result;
		}
		
		
		public String addieren (String wert1, String wert2)
		{
			if (wert1.Length < wert2.Length) {
				int x = wert2.Length - wert1.Length;
				for (int i = 1; i<=x; i++)
					wert1 = "0" + wert1;
			} else {
				int x = wert1.Length - wert2.Length;
				for (int i = 1; i<= x; i++)
					wert2 = "0" + wert2;
			}
			String[] result = addieren (wert1, wert2, 0);
			String uebertrag = String.Compare(result[1].ToString(),"1",true)==0?"1":"";
			return uebertrag+result[0];
		}

		private String[] addieren (String wert1, String wert2, int pos)
		{
			String[] a;
			String[] b;
			if (pos == wert1.Length - 1) {
					return berechneStelle(wert1[pos],wert2[pos],'0');
							
			} else {	
				a = addieren (wert1, wert2, pos + 1);
			}
			b = berechneStelle(wert1[pos],wert2[pos],Char.Parse(a[1]));
				b[0]=b[0]+a[0];
			return b;			
			
		}

		private String[] berechneStelle (char a, char b, char uebertrag)
		{
			String[] result = {"0","0"};
			if (String.Compare (a.ToString (), b.ToString (), true) == 0) {
				switch (a) {
				case '1':
					result [1] = "1";
					break;
				default:
					break;
				}
			} else {
				result [0] = "1";
			}
			if (String.Compare (result[0].ToString (), uebertrag.ToString (), true) == 0) {
				switch (Char.Parse(result[0])) {
				case '1':
					result [0] = "0";
					result [1] = "1";
					break;
				default:
					break;
				}
			} else {
				result [0] = "1";
			}
			return result;
		}
		
	}
	}


