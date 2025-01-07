# GainTrack

## Uvod

GainTrack je aplikacija koja omogućava efikasno praćenje svojih treninga, rekorda te progresa u treningu kao i praćenje spiska i treninga svojih klijenata. Aplikacija je osmišljenja da pojednostavi praćenje planova treninga i olakša praćenje rezultata bez potrebe za zapisivanjem u bilješkama ili sličnim aplikacijama. Riječ je o desktop aplikaciji razvijenoj u C# programskom jeziku uz korištenje WPF (Windows Presentation Foundation) razvojnog okvira. Aplikacija koristi MySQL bazu podataka za čuvanje svih podataka. Za upotrebu aplikacije potreban je desktop ili laptop računar sa Windows operativnim sistemom i minimalnim hardverskim specifikacijama.
 
### Korisnički nalozi

GainTrack aplikacija je osmišljena tako da podržava 2 tipa korisničkih naloga: Vježbač i Trener. Svaki od tipovi ima pristup određenim funkcionalnostima same aplikacije koje odgovaraju njihovim potrebama.

* Vježbač predstavlja glavnu zamisao upotrebe aplikacije. Njegove mogućnosti su: pregled spostvenih treninga uz mogućnost dodavanja novog i brisanja postojećeg treninga kao i mogućnost unosa težina, ponavljanja, distance i vremena za serije svake vježbe odrađene na nekom treningu nekog datuma, pregled istorije svojih treninga uz prethodno unesene vrijednosti za serije svake od vježbi, unos novih mjerenja za neku mjeru koja postoji u sistemu(težina, struk, itd.) ili kreiranje nove mjere po potrebi a zatim unos vrijednosti, te mogućnosti praćenja istorije svake od mjera kao i istorije svake od vježbi. Važno je napomenuti da gdje god je moguć izbor vježbi, bilo pri kreiranju treninga ili pri pregledu progresa vježbi, moguće je izvršiti filtriranje prema tome da li je željena vježba kardio ili težinska vježba.

* Trener je uloga koja olakšava organizaciju klijenata i njihovih treninga osobama koje su treneri. Mogućnosti trenera su: efikasno upravljanje klijentima u vidu kreiranja i brisanja naloga klijenata, te mogućnost upravljanja treninzima za svakog od klijenata u vidu kreiranja, brisanja i pregleda sadržaja treninga.

## Korisničko uputstvo

### Prijava na aplikaciju

Prilikom otvaranja aplikacije, korisniku se prikayuje početni ekran za prijavu u samu aplikaciju. Prijava je ista za oba tipa korisnika.

![image](https://github.com/user-attachments/assets/41bbd025-e7f5-4bd1-ae47-0c3930a21201)

Da bi korisnici mogli da koriste funkcionalnosti same aplikacije, potrebno je da se prvo autentifikuju na sistem upotrebom svojih kredencijala(korisničko ime i lozinka). Nakon unosa kredencijala potrebno je kliknuti na dugme "Login" pri čemu se vrši provjera ispravnosti kredencijala a pri ispravno unesenim kredencijalima se vrši provjera kojoj grupi korisnika pripada dati korisnik sa unesenim keredencijalima te se potom otvara dio aplikacije namijenjen toj grupi korisnika o čemu će biti riječi u narednim poglavljima. Pri unesenim pogrešnim kredencijalima se korisniku prikazuje poruka o pogrešno unesenim kredencijalima i korisnik ima mogućnost ponovnog unosa kredencijala.

![image](https://github.com/user-attachments/assets/5871e085-30e1-4809-b8c1-f69cf20614b0)

U slučaju da korisnik nije unio trenutno lozinku ili da je unio netačnu trenutnu lozinku prikazuje mu se poruka o neispravnosti trenutne lozinke:

![image](https://github.com/user-attachments/assets/61a6e4cb-fc34-4346-9edb-44f9129c489c)

Ukoliko korisnik ne unese ponovljenu lozinku ili unese ponovljenu lozinku koja se ne poklapa sa lozinkom ispisuje mu se poruka o grešci:

![image](https://github.com/user-attachments/assets/3872e41a-3ea7-45b5-bcb9-fcb062addf16)



### Ažuriranje korisničkog imena i/ili lozinke

Svi korisnici imaju mogućnost promjene korisničkog imena i lozinke klikom na dugme sa znakom zubčanika. Moguće je promjeniti korisničko ime nezavisno od lozinke, kao i obrnuto, te je takođe moguće promjeniti oboje odjednom. Pri promjeni lozinke potrebno je unijeti trenutnu lozinku radi potvrde autentičnosti.

![image](https://github.com/user-attachments/assets/1b54905c-8a4c-4f3b-9772-0dc6c284842a)

### Podešavanja teme i jezika

Svim korisnicima aplikacije je omogućeno personalizovanje aplikacije u vidu promjene teme i jezika aplikacije uz podrške za: tamnu, svijetlu i zelenu temu kao i za srpski i engleski jezik. Važno je napomenuti da se svaka izmjena teme ili jezika identifikuje i čuva u bazi podataka tako da korisnik koji je odabrao željenu temu ili jezik ne mora po ponovnoj prijavi ponovo birati već će automatski biti učitana zadnja odabrana tema i zadnji odabrani jezik aplikacije. Odabir teme se vrši na dugme sa ikonicom palete, dok se odabir jezika vrši klikom na dugme koje ima prepoznatljivu ikonicu za promjenu jezika na popularnom Google Chrome web pretraživaču.

* Primjer tamne teme:
* 
![image](https://github.com/user-attachments/assets/9007a12b-789a-49d9-964d-7d035fdbd2f6)
* Primjer svijetle teme:
* 
![image](https://github.com/user-attachments/assets/cb2566ce-0d66-4ef2-83c5-c8ab06156f70)
* Primjer zelene teme:
* 
![image](https://github.com/user-attachments/assets/e50d7638-1a85-443d-a6ed-64051498d561)

Uz navedene teme je prikazano kako izgleda aplikacija prilikom odabira engleskog jezika, na narednoj slici je primjer izgleda aplikacije ukoliko je odabran srpski jezik.

![image](https://github.com/user-attachments/assets/49474e56-34e9-407a-b4c0-7d99ffcc4478)





