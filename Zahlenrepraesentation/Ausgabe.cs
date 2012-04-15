using System;
using Gtk;

namespace Rechnerstukturen
{
	public class Ausgabe
	{
		private TextView ausgabefeld;
		public Ausgabe (TextView ausgabe)
		{
			this.ausgabefeld = ausgabe;
		}
		public void clear(){
			ausgabefeld.Buffer.Clear();
		}
		public void write(String s){
			ausgabefeld.Buffer.Text = ausgabefeld.Buffer.Text + s;
		}
		public void writeLine(String s){
			ausgabefeld.Buffer.Text = ausgabefeld.Buffer.Text +"\r\n"+s;
		}
	}
}

