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
using System.Windows.Media.Animation;

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

			Debug.WriteLine(CardQuestion.Icon);
			elozokartya = CardQuestion.Icon;

			//VZ letrehozunk egy sorsolast ami pénzfeldobással eldönti, régi kártyát vagy a dobokocka eredményét mutatjuk fel 
			//VZ Ez azt jelenti, hogy a dobokocka nem feltétleneül adja a CardQuestion Icoját.
			var penzfeldobas = new Random();

			//var ermeoldala = penzfeldobas.Next(0, 1); //valamiert mindig nullat ad
			var ermeoldala = penzfeldobas.Next(0, 2);
			Debug.Write("Érmeoldala: ");
			
			Debug.WriteLine(ermeoldala);


			if ((CardQuestion.Icon != FontAwesomeIcon.Question) & (ermeoldala == 0))
			{   //VZ ha lapunk már nem a kezdőikon ÉS
				//VZ az érme oldala 0 
				//VZ akkor marad az előző lap
				Debug.WriteLine("Marad az előző lap");
			}
			else
			{
				//Vesszük a kartyapaklinak megfelelő ikont és megjelenítjük
				Debug.WriteLine("Jön az újrasorsolt lap");
				CardQuestion.Icon = kartyapakli[dobas];
			}

			
		}

	
		private void AnswerBad()
		{
			Debug.WriteLine("a válasz HELYTELEN volt");
			CardIconResult.Icon = FontAwesomeIcon.ThumbsDown;
			CardIconResult.Foreground = Brushes.Red;

			VisszajelzeesEltuntetese();
		}

		private void VisszajelzeesEltuntetese()
		{
			//Animáció: egy érték változása az idő függvényben
			//egy szám folyamatosan változik 0-tól 1-ig
			//az egyik tizedes türt neve: Double
			//innen az animáció neve: DoubleAnimation
			//a névteret Ctrl ponttal tültjük be

			//időszakasz C# -ban:  TimeSpan
			// Opacity 100% : 1
			// Opacity 0% : 01

			var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));

			CardIconResult.BeginAnimation(OpacityProperty, animation);
		}

		private void AnswerGood()
		{
			Debug.WriteLine("a válasz HELYES volt");
			CardIconResult.Icon = FontAwesomeIcon.ThumbsUp;
			CardIconResult.Foreground = Brushes.LightGreen;

			VisszajelzeesEltuntetese();
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
		}

	}
}
