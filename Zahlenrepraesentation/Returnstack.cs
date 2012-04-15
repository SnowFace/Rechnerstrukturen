using System;

namespace Rechnerstukturen
{
	public class Returnstack
	{
		private String reslut = null;
		private String stepbystep = "";
		
		public Returnstack ()
		{
		}
		
		public Returnstack (String result)
		{
			this.reslut = result;
		}
		
		public static Returnstack operator + (Returnstack a, String b)
		{
			Returnstack result = new Returnstack ();
			String aresult = a.getResult ();
			
			if (a == null) {
				aresult = "";
			}	
			
			result.setResult (aresult + b);
			result.addStep (a.getSteps ());
			
			return result;
		}

		public static Returnstack operator + (Returnstack a, Returnstack b)
		{
			
			if (b.getResult () != null) {
				a += b.getResult ();
			}
			a.addStep (b.getSteps ());
			return a;
			
		}

		public void setResult (String result)
		{
			this.reslut = result;
		}
		
		public void setResult (int result)
		{
			this.reslut = reslut.ToString ();
		}
		
		public void setResult (double reslut)
		{
			
			this.reslut = reslut.ToString ();
		}
		
		public String getResult ()
		{
			return this.reslut;
		}
		
		public void addStep (String[] steps)
		{
			String stepstring = "";
			if (steps != null) {
				for (int i = 0; i< steps.Length-1; i++) {
					stepstring += steps [i] + "|";
				}
			}
			this.addStep (stepstring.Remove (stepstring.Length - 1, 1));
		}
		
		public void addStep (String step)
		{
			if (stepbystep == null) {
				this.stepbystep = step + "|";
			} else 
				this.stepbystep += step + "|";			
		}
		
		public void addStep (int step)
		{
			addStep (step.ToString ());
		}
		
		public void addStep (double step)
		{
			addStep (step.ToString ());
		}
		
		public String[] getSteps ()
		{
			if (stepbystep == "")
				return null;
			stepbystep.Remove (stepbystep.Length - 1, 1);
			return this.stepbystep.Split ('|');
		}
		
		public override String ToString ()
		{
			return this.reslut;
		}
		
		
	}
}

