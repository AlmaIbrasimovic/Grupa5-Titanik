# Grupa5-Titanik
### Tema: Sistem putovanja
### Članovi tima:
- Alma Ibrašimović
- Eldin Kapetanović
- Zlata Karić


## Opis teme
Aplikacija **TravelBook** ima za cilj da pojednostavi traženje putovanja od strane korisnika i kreiranje putovanja od strane raznih turističkih agencija. Agencija ima uvid na kreirana putovanja i broj korisnika koji su odabrali to putovanje. Korisnik ima mogućnost da pretražuje i sortira putovanja po cijeni, datumu, destinaciji i agenciji koja nudi putovanje. Omogućeno je plaćanje online karticom ili lično na adresi **TravelBook** gdje su obuhvaćene sve turističke agencije koje su dale ponude.


## Procesi
#### Registracija korisnika na aplikaciju
Na početnom prikazu aplikacije prikazuju se putovanja sortirana po datumu. Da bi se rezervisalo putovanje potrebna je registracija. Korisnik koji želi da uplati putovanje mora se logovati u aplikaciju.<br/>
Korisnik se registruje sa osnovnim podacima o sebi, a to su:
* Ime
* Prezime
* Datum rođenja
* JMBG
* E-mail
* Password
* Adresa stanovanja
* Kontakt telefon
* Podaci o kreditnoj kartici

#### Registracija agencija na aplikaciju
Angencija se mora registrovati na aplikaciju, ako želi da kreira putovanje.<br/>
Kod registracije agecija mora unijeti iduće informacije:
* Naziv 
* Adresu
* Podatke o bankovnom računu
* Password

#### Kreiranje putovanja
Nakon kreiranja računa agencija dobiva pristup formi pomoću koje može kreirati putovanje.<br/> 
Pod kreiranjem putovanja se smatra sljedeće:
* Odabir destinacije
* Datum početka i završetka putovanja
* Minimalni i maximalni broj putnika
* Navodi se hotel
* Odabir leta(interakcija sa timom **Grupa6-piloti**)
* Cijena putovanja
* Opis putovanja
* Slike hotela i destinacije<br/>
Agencija može da vidi sva svoja kreirana putovanja i korisnike koji su učestvovali/učestvuju u putovanju.
Zatim se putovanje prikaže na **TravelBook** početnoj stranici.

#### Evidencija broj putnika po putovanju
Ukoliko se ne dostigne minimalni broj putnika, 10 dana prije putovanja, onda se putovanje otkazuje i vraća se novac putnicima.
Ukoliko je dostignut maximalni broj putnika, označava se da je popunjeno.
Putnici mogu otkazati putovanje do 10 dana pred putovanje, ali se uzima određeni procenat.

#### Proces naplate putovanja
Korisnik može online odabrati putovanje i platiti kartično ili da ode na lokaciju **TravelBook** i uplati gotovinom putovanje.
Ako je online korisnik uplatio više od 10 putovanja, preko kartice, ostvaruje određeni popust na iduća putovanja.

#### Proces unosa podataka u poslovnici
Korisnik daje sljedeće informacije uposleniku u agenciji:
* Ime
* Prezime
* Kontakt telefon
* JMBG


### Funkcionalnosti
Funkcionalnosti aplikacije:
* Pregled ponude putovanja
* Pregled lokacije hotela
* Pregled lokacije **TravelBook**
* Online plaćanje
* Mogućnost ocjenjivanja agencija
* Mogućnost sortiranja putovanja
* Mogućnost kupovanja više karata s ličnim podacima svih putnika
* Mogućnost otkazivanja putovanja 10 dana pred putovanje


### Akteri
* Putnička agencija(pravno lice): Kreiranje i pregled putovanja 
* Obični korisnik: Izbor i uplata putovanja na lokaciji agencije **TravelBook**
* Online korisnik: Izbor i uplata putovanja online sa kreditnom karticom
* Administrator: Održava stranicu i pregleda validaciju
* Šef: Krade zaradu!!!!
* Uposlenik u agenciji: Rezerviše i naplaćuje putovanja običnih putnika(koji su došli na lokaciju)
* Lejlin aerodrom: Preuzimanje informacija o letovima i rezervisanje 
* Sistem za autorizaciju i naplatu karticom: Provjerava validnost uplate
* Poštar: Dostavlja karte na adresu stanovanja online korisnicima, a obični preuzimaju u poslovnici



