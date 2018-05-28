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
using FontAwesome.WPF;

namespace vidus77GameXAML1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private FontAwesomeIcon elozokartya;

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
			var kartyapakli = new FontAwesomeIcon[6];

			// 0-tól az 5-ig 
			kartyapakli[0] = FontAwesomeIcon.Fax;
			kartyapakli[1] = FontAwesomeIcon.Female;
			kartyapakli[2] = FontAwesomeIcon.Download;
			kartyapakli[3] = FontAwesomeIcon.Edge;
			kartyapakli[4] = FontAwesomeIcon.Hashtag;
			kartyapakli[5] = FontAwesomeIcon.Mars;

			//létrehozunk egy dobókockát is ami alapokat húzza
			var dobokocka = new Random();
			//dobunk egyet 0 és 5 között (a dobas változó fogaja tudni mit dobtunk
			var dobas = dobokocka.Next(0, 5);

			// értékadás szabályai
			//az egyenlőségjel két részre osztja a sort
			//a bal oldali változó KAPJA az értéket és tárolja
			//a jobb oldali "kifejezés" ADJA az értéket

			//olyan változó kell, ami a más kódblokkaban is látszik
			// var elozokartya = CardQuestion.Icon; sorból törölni kell a var változónak a
			//meghatározását és Ctrl klikkel feladja a egy egy szinttel kintebb lévő véltozó létrehozását
			elozokartya = CardQuestion.Icon;

			//Vesszük a kartyapaklinak megfelelő ikont és megjelenítjük
			CardQuestion.Icon = kartyapakli[dobas];
		}

		private void ButtonStart_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Start gombot nyomtuk meg!");
			UjKartyaHuzasa();

			//le kell tiltani a *Start* gombot
			ButtonStart.IsEnabled = false;

			//engedélyezni kell az* Yes/ No * gombokat
			ButtonYes.IsEnabled = true;
			ButtonNo.IsEnabled = true; 
		}


		private void AnswerBad()
		{
			Debug.WriteLine("a válasz HELYTELEN volt");
			CardIconResult.Icon = FontAwesomeIcon.Times;
			CardIconResult.Foreground = Brushes.Red;
		}

		private void AnswerGood()
		{
			Debug.WriteLine("a válasz HELYES volt");
			CardIconResult.Icon = FontAwesomeIcon.CheckCircle;
			CardIconResult.Foreground = Brushes.LightGreen;
		}
		private void ButtonYes_Click(object sender, RoutedEventArgs e)
		{

			Debug.WriteLine("Yes gombot nyomtunk!");

			//El kell döntenünk, hogy egyeznek-e a kártyák 
			// FELTÉTELVIZSGÁLAT

			//ha az (előző kártya és a mostani megegyezik)

			//akkor a válasz jó

			//különben rossz

			if (elozokartya==CardQuestion.Icon) //a vizshógálat helye
			{ // igaz esetén a kódblokk
				AnswerGood();
			}
			else
			{ //ha akifejezés nem igaz
				AnswerBad();

			}

			UjKartyaHuzasa();

			CardIconResult.Icon = FontAwesomeIcon.Check;
		}

		private void ButtonNo_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine("Nem gombot nyomtunk!");

			if (elozokartya != CardQuestion.Icon) //a vizshógálat helye
			{ // igaz esetén a kódblokk
			  //Debug.WriteLine("a válasz HELYES volt");
				AnswerGood();
			}
			else
			{ //ha akifejezés nem igaz
			  //Debug.WriteLine("a válasz HELYTELEN volt");
				AnswerBad();
			}

			UjKartyaHuzasa();


			CardIconResult.Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle;
		}

	}
}
