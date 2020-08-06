using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
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
			DrugiAlarm da = new DrugiAlarm();
			Vatrogasac v1 = new Vatrogasac();
			Vatrogasac v2 = new Vatrogasac();
			Civil c = new Civil();

			pp.PpAlarm += c.Panici;
			//da.DrugiAlarmm += c.Panici;

			pp.PpAlarm += v1.CujesAlarm;
			pp.PpAlarm += v2.CujesAlarm;

			pp.Zvoni();

			dgm.Click += dgm_Click;
			dgm2.Click += dgm_Click;

			ObservableCollection<int> oc = new ObservableCollection<int>();
	
			oc.CollectionChanged += Promena;

			oc.Add(4);
			oc.Add(5);
			oc.Remove(5);
		}

		public void Promena(object c, NotifyCollectionChangedEventArgs a)
		{
			if (a.Action == NotifyCollectionChangedAction.Add)
				MessageBox.Show(a.NewItems[0].ToString());
			else if (a.Action == NotifyCollectionChangedAction.Remove)
				MessageBox.Show("Uklonjeno! : " + a.OldItems[0].ToString());
		}

		private void dgm_Click(object sender, RoutedEventArgs e)
		{
			
			MessageBox.Show(sender.ToString());
		}
	}

	public class AlarmEventArgs : EventArgs
	{
		public int temp;
		public string info; 
	}

	public class Protivpozarni
	{
		public delegate void Alarm(object KoSalje,
			AlarmEventArgs  a);
		public event Alarm PpAlarm;

		public void Zvoni()
		{
			PpAlarm?.Invoke(this,  new AlarmEventArgs());
		}
	}

	public class DrugiAlarm
	{
		public delegate void Alarm(object KoSalje, string x);
		public event Alarm DrugiAlarmm;

		public void Zvoni()
		{
			DrugiAlarmm?.Invoke(this, "Zdravo :)");
		}
	}

	public class Civil
	{
		public void Panici(object govornik, AlarmEventArgs a) 
		{
			if (govornik is Protivpozarni pp && a.temp > 7)
			{

			} else
			{

			}
		}
	}

	public class Vatrogasac
	{
		public bool CuoAlarm;

		public void CujesAlarm(object govornik, AlarmEventArgs a) => CuoAlarm = true;
	}

	public class Policajac
	{
		public bool CuoAlarm;

		public void CujesAlarm(object govornik, AlarmEventArgs a) => CuoAlarm = true;
	}
}
