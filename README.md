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

![image](https://github.com/user-attachments/assets/9007a12b-789a-49d9-964d-7d035fdbd2f6)
* Primjer svijetle teme:

![image](https://github.com/user-attachments/assets/cb2566ce-0d66-4ef2-83c5-c8ab06156f70)
* Primjer zelene teme:

![image](https://github.com/user-attachments/assets/e50d7638-1a85-443d-a6ed-64051498d561)

Uz navedene teme je prikazano kako izgleda aplikacija prilikom odabira engleskog jezika, na narednoj slici je primjer izgleda aplikacije ukoliko je odabran srpski jezik.

![image](https://github.com/user-attachments/assets/49474e56-34e9-407a-b4c0-7d99ffcc4478)

### Odjava sa sistema

Svi korisnici se mogu u bilo kom trenutku odjaviti sa sistema klikom na dugme sa prepoznatljivom ikonicom odjave.

## Nalog vježbača

### Podešavanja naloga vježbača

Ova funckionalnost je prethodno opisana u sekciji "Ažuriranje korisničkog imena i/ili lozinke".

### Pregled treninga vježbača

Nakon uspješne prijave vježbača na sistem, prikazuje mu se ekran na kom može da vidi sve svoje treninge kao i da ih obriše, te kreira nove.

![image](https://github.com/user-attachments/assets/3c23708b-e16b-4f90-ae64-c32e3a6195c9)

Kada korisnik klikne na dugme "Create Training" otvara mu se prozor na kom moze kreirati novi trening tako što upiše ime treninga a zatim iz padajuće liste bira vježbe koje želi dodati na trening te bira broj serija za svaku vježbu. Dostupno je i filtriranje dostupnih vježbi radi lakšeg pronalaženja željene vježbe. Vježbe dodane na trening je u svakom trenutku procesa kreiranja treninga moguće ukloniti sa samog treninga jednostavnim klikom na dugme "Delete".

![image](https://github.com/user-attachments/assets/27cc452c-5f56-4e2e-8061-7bffd69b5ebb)

Ukoliko željena vježba ne postoji u sistemu, moguće je kreirati istu klikom na dugme "Create Exercise" pri čemu u jednostavnom prozoru se unese naziv vježbe i proizvoljan komentar te se bira da li je vježba težinska ili kardio vježba radi kasnijeg filtriranja.

![image](https://github.com/user-attachments/assets/c54423b6-2297-43ad-ae06-fd02f175f09f)

Po uspješno kreiranoj vježbi se prikazuje poruka:

![image](https://github.com/user-attachments/assets/60620179-c7cc-4d7e-8cad-039e1f5e55d7)

Po uspješno kreiranom treningu se prikazuje poruka:

![image](https://github.com/user-attachments/assets/c4e95e90-8896-4f6b-aa87-4aab310e0148)

Klikom na željeni trening se korisniku prikazuju sve serije svake vježbe na treningu uz mogućnost upisivanja rezultata treniranja u vidu broja ponavljanja, težine, distance i vremena za svaku vježbu nakon čega korisnik može da zabilježi da je na određeni datum odradio neki trening prostim izborom datuma iz jednostavnog Date Picker-a i klikom na dugme "Save". Klikom na dugme "Save" se resetuje tabela u koju je korisnik prethodno unosio podatke za konkretno odrađen trening.

![image](https://github.com/user-attachments/assets/e08642a2-fb6c-4583-a86e-6e25ac33af08)

### Pregled istorije treninga

Klikom na "Training History" korisniku se prikazuje prozor u kom može vidjeti sve svoje prethodno odrađene treninge sa datumima kada su i odrađeni te klikom na svaki od njih mu se u tabeli prikazuju rezultati koje je prethodno unio kada je bilježio odrađen trening.

![image](https://github.com/user-attachments/assets/2e900b0a-09e2-4da9-9bd5-4233b761de19)

### Unos mjerenja

Klikom na "Enter Messurements" korisniku se otvara prozor na kom je moguće izabrati mjeru koja već postoji u sistemu(težina, struk, itd.) i unijeti vrijednost za tu mjeru te kliknutni na dugme "Save" pri čemu će se za tog korisnika i za trenutni datum zabilježiti mjerenje za odabranu mjeru.

![image](https://github.com/user-attachments/assets/c20364de-52f3-416f-a579-a6db39a8e2a6)

Po uspješno sačuvanom mjerenju korisniku se ispisuje ispisuje poruka:

![image](https://github.com/user-attachments/assets/4b8133bc-f759-45d3-b580-b11e9f70151e)

Ukoliko željena mjera ne postoji već u sistemu, korisnik u gornjem dijelu prozora može da unese naziv nove mjere te da klikne na dugme "Create". Po uspješno kreiranom mjerenju se korisniku ispisuje poruka:

![image](https://github.com/user-attachments/assets/b6a5a237-dde1-4b2b-943d-43d1a0ee77da)

### Progres mjerenja

Klikom na "Messurement Progress" korisniku se prikazuje prozor u kom iz liste može da izabere mjeru koja postoji u sistemu te mu se za izabranu mjeru u tabeli prikazuju mjerenja pri čemu svako mjerenje čini vrijednost i datum kada je ta vrijednost ostvarena.

![image](https://github.com/user-attachments/assets/3a4d2b19-7618-43c4-9d6f-aadc98b99b00)

### Progres vježbi

Klikom na "Exercise Progress" korisniku se prikazuje prozor u kom iz liste može da izabere vježbu koja postoji u sistemu te mu se za izabranu vježbu u tabeli prikazuju svi rezultati koje je unio za datu vježbu prilikom bilježenja odrađenog treninga, pri čemu korisnik može da sortira tabelu prema svojim željama. Takođe postoji mogućnost filtriranja vježbi radi lakšeg pronalaska željene vježbe.

![image](https://github.com/user-attachments/assets/2aac2bbd-0ec9-4965-8fa3-68c4f53771e6)

## Nalog trenera

### Podešavanja naloga trenera

Ova funckionalnost je prethodno opisana u sekciji "Ažuriranje korisničkog imena i/ili lozinke".

### Pregled klijenata

Po prijavi na sistem trener vidi listu svojih klijenata uz mogućnost brisanja i dodavanja svakog klijenta.

![image](https://github.com/user-attachments/assets/a1032623-a7d7-4923-b620-1c6562a1a776)

Dodavanje klijenata se vrši klikom na dugme "Add Client" pri čemu se otvara jednostavan prozor u kom je potrebno popuniti podatke o klijentu i kliknuti na dugme "Save".

![image](https://github.com/user-attachments/assets/7c0106f0-8693-4f5f-8eea-769dfac7ac90)

Pri uspješnom kreiranju klijenta, treneru se ispisuje poruka:

![image](https://github.com/user-attachments/assets/85f51c0f-7f55-4b04-bbb2-2b77cd170138)

Ukoliko trener nije popunio sva polja prikazuje mu se poruka:

![image](https://github.com/user-attachments/assets/c3a7ecc8-eae7-4206-86aa-25e7944c72d0)

Ukoliko je korisničko ime već zauzeto, treneru se prikazuje poruka:

![image](https://github.com/user-attachments/assets/8c839698-f58b-42bc-9142-90fbbe302b4a)

Ukoliko trener ne unese ispravnu ponovljenu lozinku za klijenta ispisuje mu se poruka:

![image](https://github.com/user-attachments/assets/0c7d456a-e0d9-443b-b098-dbf3e0e2b2f0)

Posljednje 3 poruke označavaju da klijent nije uspješno kreiran.

### Pregled detalja klijenta

Klikom na klijenta treneru se prikazuju u desnom dijelu ekrana njegovo ime, prezime i korisničko ime te lista treninga koje je trener kreiarao za tog klijenta uz mogućnost brisanja treninga, pregleda detalja treninga te dodavanja novog treninga.

![image](https://github.com/user-attachments/assets/e34ed576-97b2-442c-9702-22b851e88fd2)

Klikom na dugme "Details" se treneru prikazuje prozor sa svim vježbama i brojem serija za svaku vježbu na odabranom treningu odabranog klijenta.

![image](https://github.com/user-attachments/assets/d07129f6-29eb-48b4-a121-d79f558c8b96)

Klikom na dugme "Delete" se briše trening za datog klijenta i lista treninga se automatski ažurira. Kreiranje treninga je istovjetno kreiranju treninga opisanom u sekciji "Pregled treninga vježbača".

















