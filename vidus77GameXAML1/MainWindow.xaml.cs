using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace vidus77GameXAML1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		/// <summary>
		/// AZ Ablak un. létrehozó függvénye az un. (Construktor)
		/// az ablak képernyőre rajzolásakor lefut
		/// </summary>
        public MainWindow()
        {
			// Ez a sor elintézi az adminisztrációt
			//a saját kódunkat utánna írjuk
            InitializeComponent();

			//engedélyezzük a Start gombot
			ButtonStart.IsEnabled = true;

			//letiltjuk a Yes/No gombokat
			ButtonYes.IsEnabled = false;
			ButtonNo.IsEnabled = false;

			UjKartyaHuzasa();
        }

		private void ButtonYes_Click(object sender, RoutedEventArgs e)
		{

			Debug.WriteLine("Yes gombot nyomtunk!");

			UjKartyaHuzasa();

			CardIconResult.Icon = FontAwesome.WPF.FontAwesomeIcon.Check;
		}

		/// <summary>
		/// Ebbe a függvénybe szerveztük ki a káryahúzással kapcsolatos feladatokat
		/// </summary>
		private void UjKartyaHuzasa()
		{
			// Szigurúan típusos nyelv a c# ezért megmondjuk, 
			// hogy a polcunkoon mi lehet
			// a polc programozói neve: "tömb"


			//var a variable rövidítése aza változó
			//egy oéyan változót hozunk létre, amibne 6 db ilyen 
			//ikon nevet tartalmazhat 
			// attól változó a változó, hogy változhat az értéke 
			var kartyapakli = new FontAwesome.WPF.FontAwesomeIcon[6];

			// 0-tól az 5-ig 
			kartyapakli[0] = FontAwesome.WPF.FontAwesomeIcon.Fax;
			kartyapakli[1] = FontAwesome.WPF.FontAwesomeIcon.Female;
			kartyapakli[2] = FontAwesome.WPF.FontAwesomeIcon.Download;
			kartyapakli[3] = FontAwesome.WPF.FontAwesomeIcon.Edge;
			kartyapakli[4] = FontAwesome.WPF.FontAwesomeIcon.Hashtag;
			kartyapakli[5] = FontAwesome.WPF.FontAwesomeIcon.Mars;

			//létrehozunk egy dobókockát is ami alapokat húzza
			var dobokocka = new Random();
			//dobunk egyet 0 és 5 között (a dobas változó fogaja tudni mit dobtunk
			var dobas = dobokocka.Next(0, 5);

			//Vesszük a kartyapaklinak megfelelő ikont és megjelenítjük
			CardQuestion.Icon = kartyapakli[dobas];
		}

		private void ButtonNo_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Nem gombot nyomtunk!");
			UjKartyaHuzasa();


			CardIconResult.Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle;
		}

		private void ButtonStart_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Start gombot nyomtuk meg!");
			UjKartyaHuzasa();

		}
	}
}
