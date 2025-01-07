# GainTrack

## Uvod

GainTrack je aplikacija koja omogućava efikasno praćenje svojih treninga, rekorda te progresa u treningu kao i praćenje spiska i treninga svojih klijenata. Aplikacija je osmišljenja da pojednostavi praćenje planova treninga i olakša praćenje rezultata bez potrebe za zapisivanjem u bilješkama ili sličnim aplikacijama. Riječ je o desktop aplikaciji razvijenoj u C# programskom jeziku uz korištenje WPF (Windows Presentation Foundation) razvojnog okvira. Aplikacija koristi MySQL bazu podataka za čuvanje svih podataka. Za upotrebu aplikacije potreban je desktop ili laptop računar sa Windows operativnim sistemom i minimalnim hardverskim specifikacijama.
 
### Korisnički nalozi

GainTrack aplikacija je osmišljena tako da podržava 2 tipa korisničkih naloga: Vježbač i Trener. Svaki od tipovi ima pristup određenim funkcionalnostima same aplikacije koje odgovaraju njihovim potrebama.

* Vježbač predstavlja glavnu zamisao upotrebe aplikacije. Njegove mogućnosti su: pregled spostvenih treninga uz mogućnost dodavanja novog i brisanja postojećeg treninga kao i mogućnost unosa težina, ponavljanja, distance i vremena za serije svake vježbe odrađene na nekom treningu nekog datuma, pregled istorije svojih treninga uz prethodno unesene vrijednosti za serije svake od vježbi, unos novih mjerenja za neku mjeru koja postoji u sistemu(težina, struk, itd.) ili kreiranje nove mjere po potrebi a zatim unos vrijednosti, te mogućnosti praćenja istorije svake od mjera kao i istorije svake od vježbi. Važno je napomenuti da gdje god je moguć izbor vježbi, bilo pri kreiranju treninga ili pri pregledu progresa vježbi, moguće je izvršiti filtriranje prema tome da li je željena vježba kardio ili težinska vježba.

* Trener je uloga koja olakšava organizaciju klijenata i njihovih treninga osobama koje su treneri. Mogućnosti trenera su: efikasno upravljanje klijentima u vidu kreiranja i brisanja naloga klijenata, te mogućnost upravljanja treninzima za svakog od klijenata u vidu kreiranja, brisanja i pregleda sadržaja treninga.
