using System;

namespace Rechnerstukturen
{
	public class Dualoperationen
	{
		public Dualoperationen ()
		{
		}
		
		public String invert (String wert)
		{
			String erg = "";
			for (int i = 0; i < wert.Length; i++)
				if (String.Compare (wert [i].ToString (), '1'.ToString (), true) == 0)
					erg += 0;
				else
					erg += 1;
			return erg;
		}
		
		public Char xor(Char a, Char b){
			if(String.Compare(a.ToString(),b.ToString(),true)==0){
				return '0';
			}
			return '1';
		}
	}
	
}

