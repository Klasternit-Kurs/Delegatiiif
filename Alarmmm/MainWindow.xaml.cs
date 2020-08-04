using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alarmmm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Protivpozarni pp = new Protivpozarni();
			Vatrogasac v1 = new Vatrogasac();
			Vatrogasac v2 = new Vatrogasac();
			Civil c = new Civil();
			pp.PpAlarm += c.Panici;
			pp.PpAlarm += v1.CujesAlarm;
			pp.PpAlarm += v2.CujesAlarm;


			pp.Zvoni();
		}
	}

	public class Protivpozarni
	{
		public delegate void Alarm(string x);
		public event Alarm PpAlarm;

		public void Zvoni()
		{
			PpAlarm?.Invoke("Zdravo :)");
		}
	}

	public class Civil
	{
		public void Panici(string x) { }
	}

	public class Vatrogasac
	{
		public bool CuoAlarm;

		public void CujesAlarm(string x) => CuoAlarm = true;
	}

	public class Policajac
	{
		public bool CuoAlarm;

		public void CujesAlarm(string x) => CuoAlarm = true;
	}
}
