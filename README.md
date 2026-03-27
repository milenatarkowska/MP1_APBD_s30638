# System Zarządzania Uczelniianą Wypożyczalnią Sprzętu (MP1)

## 1. Opis Projektu
Projekt stanowi system ewidencji i zarządzania zasobami IT (komputery, monitory, projektory) oraz procesami ich wypożyczania przez pracowników i studentów. Aplikacja pozwala na śledzenie stanu procesów wypożyczaania i zwracania urządzeń wraz z ich statusami dostępności.

---

## 2. Decyzje projektowe i architektura

### Podział klas i plików
* **Folder `Items/`**: Zawiera definicje zasobów fizycznych. Klasa bazowa `Sprzęt.cs` definiuje wspólne cechy, a klasy pochodne (`Komputer.cs`, `Monitor.cs`, `Projektor.cs`) rozszerzają ją o specyficzne właściwości.
* **Folder `Users/`**: Grupuje klasy związane z podmiotami korzystającymi z systemu. Rozdzielenie na `Student.cs` i `Pracownik.cs` pozwala na późniejszą implementację różnych limitów wypożyczeń dla tych grup.
* **Katalog główny**: Zawiera klasy procesowe i logikę biznesową, co oddziela modele od serwisów.

---

## 3. Uzasadnienie decyzji projektowych

### Kohezja
* **Logiczne grupy:** Klasy dotyczące urządzeń trzymane w folderze `Items`, a te o użytkownikach w `Users`.
* **Separacja logiki:** Klasa `Serwis.cs` - zajmuje się tylko logiką biznesową, klasy w foledrach `Items/` i `Users` to modele strukur.

### Coupling 
* **Klasa bazowa:** Klasa `Sprzęt.cs`, po której dziedziczą konkretne przedmioty (Monitor, Komputer, Projektor) - łatwe dodanie kolejnego rodzaju sprzętu. Analogicznie w implementacji Użytkowników.
* **Enumy:** Zamiast wpisywać statusy ręcznie w kodzie, użyłam `StatusSprzetu` - łatwa modyfikacja statusów.

### Odpowiedzialność klas
* **Wypozyczenie.cs:** To klasa łącząca. Pamięta kto, co i na jak długo pożyczył.
* **Program.cs:** Służy do uruchomienia aplikacji i pokazania jej działania. Logika i struktury mają oddzielne klasy.

---

## 4. Technologie
* **Język**: C#
* **Platforma**: .NET
* **Środowisko**: JetBrains Rider
