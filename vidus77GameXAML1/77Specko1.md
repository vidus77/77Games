﻿﻿# A Memória-kártyajáték specifikációja Nekifutás 05-24

#### a File helye
 local C:\Users\...\Documents\Visual Studio 2015\Projects\vidus77Projects\vidus77Games


## Szerző helyesebben interpretáló
Vida Zoltán ( [Plesz Gábor, NetAcademia, 2018 tananyaga](https://github.com/Xaml201805) alapján)


## A programozáshoz felhasznált környezet
### Visual Studio 2015
 - Community csomag
 - GitHub környezet
   - A telepitéshez használtam a github normal windows aplikácioját 
 - Markdown [Extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor) felhasználásával 
   - Javasolt *.md formátum UTF8 


## A specifikáció feladata

 - bár a játék teljes mértékben a fent emített tanfolyami anyagra épül, a kiviteklezás különbözni fog egy kicsit, más tervezéssel egy-két apró változtatással másik játékot csinálni belőle. 
 - A markánsan különböző funkciókat részletesebben is specifikálandók. 
 - A fejlesztés Deklaratív és procedulális programozásra épül.

## Általános bemutatás
Szeretnénk készíteni egy reakcióidő mérő játékot. A játék egymás után mutat kártyalapokat, és nekünk meg kell mondanunk, hogy a mutatott lap egyezik-e az előzővel, vagy sem. Ha jól válaszolunk pontot kapunk. A játék méri az egyes reakcióidőt, és az átlagos reakcióidőt is. A végén a top 5 eredményt is megmutatja.

## Forgatókönyv
 A _Felhasználó_ elindítja a játékot és és néhány játékot játszik, ezáltal képet nyer az aktuális reakció idejéről, koncentrációképességéről.

## A Játékmenet
- [x] Kezdéskor kapunk egy kártyát, 
- [x] Amikor megnyomjuk a STart gombot megindul a játék folyamata
- [x] Az, hogy jó-e a káártya elóre el kell döljön, nem a lapok számától füg
  - [x] (1.) A kártyának vagy jónak vagy nem jónak kell lennie nagyjából 50% eséllyel
- [ ] majd a játék indításával a kártyánkat egy új váltja fel. A játék indítása, az Indítás gombbal megy.
- [x] A visszajelzésünkre (egyforma/nem egyforma) 
- [ ] a játék jelzi egy zöld pipával/piros kereszttel, hogy a válaszunk helyes vagy helytelen.
- [ ] a játékot billentyűzettel lehessen játszani
- [ ] A válasznak megfelelő pontot számolja, 
- [ ] méri az egyes reakcióidőt 
- [ ] és az átlagos reakcióidőt is. 
- [ ] A játék meghatározott ideig tart, amit a kezdéstől egy visszaszámláló óra jelez. 
- [ ] A játék végén látjuk a pontszámunkat, 
- [ ] és a top 5 pontszámot. 
- [ ] Ha akarjuk újrakezdhetjük a játékot, vagy kiléphetünk.
- 
## A markánsan különböző funkciók
 1. Tekintettel arra, hogy játék közben két gombot használunk, azok lenyomásának esélyeit ki kell egyenlítenünk.  
 2. Az eredeti programtól eltérő lesz a gombok elhelyezkedése
 3. Jó lenne visszaszámlálással indítani a játékot az első lap megjelenéséig. 

## A játék főképernyőjének eredeti verziója

```
+---------------------------------------------------------------------------------------------------+
| +----------+  +---------------------------------------------------------------------------------+ |
| |          |  | Információk, eredmény, visszajelzés                                             | |
| | Toplista |  +---------------------------------------------------------------------------------+ |
| |          |                                                                                      |
| |          |                                                                                      |
| |          |         +---------------------------+         +---------------------------+          |
| |          |         |                           |         |                           |          |
| |          |         |  Visszajelzés, hogy a     |         |                           |          |
| |          |         |  válasz jó volt+e         |         |   Kártya a játékhoz       |          |
| |          |         |  vagy sem                 |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         |                           |         |                           |          |
| |          |         +---------------------------+         +---------------------------+          |
| |          |                                                                                      |
| |          |  +---------------------------------------------------------------------------------+ |
| |          |  | Különböző gombok, amik egymás mellett szépen következnek                        | |
| |          |  |                                                                                 | |
| +----------+  +---------------------------------------------------------------------------------+ |
+---------------------------------------------------------------------------------------------------+
```
# A játék főképernyőjének módosított verziója

```
+---------------------------------------------------------------------------------------------------+
|   +-----------+  +---------------------------------------------------------------------------+    |
|   |           |  |                  Információk, eredmény, ^isszajelzés                      |    |
|   |  Toplista |  +---------------------------------------------------------------------------+    |
|   |           |                                                                                   |
|   |           |                                                                                   |
|   |           |  +--------------------+   +---------------------------+   +------------------+    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  | Visszajelzés, hogy |   |    Kártya a játékhoz      |   |  Diagrammok      |    |
|   |           |  | ^álasz jó ^olt+e   |   |                           |   |                  |    |
|   |           |  | vagy sem           |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   |           |  |                    |   |                           |   |                  |    |
|   +-----------+  +--------------------+   +---------------------------+   +------------------+    |
|                                                                                                   |
|   +------------------------------------------------------------------------------------------+    |
|   |    Különböző gombok, amik egymás mellett szépen következnek                              |    |
|   |                                                                                          |    |
|   +------------------------------------------------------------------------------------------+    |
|                                                                                                   |
+---------------------------------------------------------------------------------------------------+
```

 - A képernyőn lesz két fő sor, az alsóban a kezelő gombok, a fölső sorban minden más
  - a felső rész baloldalán lesz egy tartalomfüggő szélességű (nem nyújyható ) és egy változtatható szálességű oszlop minden a fejlécnek és a grafikus elemeknek
  - Az alsó sor gombjai WrapPanelben középen lesznek 
  - - A gombok feliratai es nyilai is lesznek. 
    - A rossz valasz nyila jobboldalon lesz a felirathoz képest
  - A kártyák kezeléséhez a FontAwesamot használjuk, amit először is a csomagkeresésen keresztül meg kell keresni
    - megkerressük a *Manage Nuget Packages* a *Solution Exploreren* keresztül. a FontAwesome.WPF csomagját
    - A *Nuget * végzi a verziófrissitést
    - A *Nuget* a függőségeket is kezeli (Depences)
     - *Package Menager Console* segítségével is lehetett volna telpíteni, de nem az a jobb megoldás
     - Létrejön a projekktben a package.config állomány ami jelzi a program számáraa hasznáálhatóságot
  - Ahhoz, hogy a konkr;t projektben is haszn'lhat= legyen a a MainWindow.xaml-ban be kell tenni a z 'llom'nyt 
    - Ehhez az * xmlns:fa* sz-veget kezdj-k elbeg;pelni ;s ut'na ki kell v'lasztania az *="http://schemas.fontawesome.io/icons/"*  html-t 
    - Ezutánn az *fa:* beütésével fel fogaj ajánlani, hogy fontot / ikont stb. használjunk a kódban

## Kódolási jegyzet
Feladatok 
- a gombokra kattintaskor történjen valami
- legyen a kártyáknak egy hamaza, amiből kattintára egyet megjelenítünk véletlenszerűen
- de előtte düntsük el 50/50 százalék esállyel új vagy régi kártya jöjjön
- létrehozunk egy tömbüt ami a hlyes válasz valószínüségét határozza meg 0 / 1
- mondjunk egy véletlen számot ami eldönti, új kártyát húzunk vagy az előzőt mutatjuk meg. 
  - Magunknak a kártyáknak létrehozunk egy polcot (tömböt), amire kártyát tudunk tenni,
    - a polc egyes elemeire kiteszünk kártyákat
    - a polc egye elemei meg vanak számozva a kártyák száma-1 -ig,
    - mondjunk egy véletlen számot, és az annyiadik kártyát levesszük a polcról

- az *.xaml a vizualis tervező 

## Feladatok
- Induláskor cdak a Start gombra lehessen kattintani
- A játék indulása után a Start gombra már ne lehessen kattintani

### Programozás 
- [X] Amikor elindul az alkalmazás
  - [x] le kell tiltani a *Yes/No* gombokat
  - [x] engedélyezni kell az indítást 
- [X] Amikor az indítást megnyomjuk
  - [x] le kell tiltani a *Start* gombot
  - [x] engedélyezni kell az *Yes/No* gombokat

## Feladatok
- értékelni kel, hogy jó gombot nyomtunk-e meg, vagyis tudni kell, hogy a két kártya egyforma-e

### Programozás
- [X] el kell tárolni az előző kártya értékét
  - [x] ehhez nem volt elég lokális változót használni, hanem un. osztályszintű változó (mező/field) kellett
- [x] el kellett dönteni, hogy az előző és a mostani kártya egyezik-e (egyezőség vizsgálat)
  - [x] ha egyezik ezt írja ki a debugban
  - [x] ha NEM egyezik ezt írja ki a debugban
  - [ ] 
 
## Feladatok
- ikonnal jellezzük, hogy a válasz helyes-e
- [x] legyenek más színei az ikonoknak
- [x] mas-mas ikon legyen

## Feladatok
- ki kell egyenlíteni a Yes és No gombok esélyeit
- de csak akkor, ha már van mit ismételi

### Programozás
Pénzfeldobással eldöntjük hogy új lapot húzunk vagy sorsolunk
- [x]  Előzetesen meg kell győzödni, van-e mit ismételni
  - [x] ha már van mit ismételni és az érme is úgy döntött akkor kell egy út, ami az előző kártyát ismétli (ilyenkor nem kell változtatni a lapon) csak kiírjuk debugban
  - [x] kell egy út, ami a dobókocka eredményét mutatja meg.
- [x] különbven a dobokocka által kiválasztoott lapot mutatjuk meg

## Feladatok
- a válasz helyességének ikonja tűnjön el egy idő után

### Programozás
-animációval átállítjuk a kártya *Opacity* értékét 100%-ról 0%-ra

## Feladatok 
- Billentyűvel is lehessen  játékot játszani. Ehhez:
  - Játékot lehesssen indítani billentyűvel (felfelé nyíl)
  - igen és nem-et lehessen válaszolni billentyűvel (jobbra/balra nyíl)

### Programozás
- [x] el kell tudnunk kapni a billentyűleütést;
- [x] meg kell tudni mondani, hogy felfelé/balra/jobbra nyíl;
- [x] ennek megfelelően kel a játékot folytatni.
<<<<<<< HEAD

## Feladatok

=======
>>>>>>> 598ec102f1aaf62eec1af088796ef621d3771a44
