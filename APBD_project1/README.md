# APBD_project1 – Wypożyczalnia urządzeń

## Opis projektu

Projekt przedstawia prostą aplikację konsolową napisaną w C#. 
Zadaniem projektu jest obsługa uczelnianej wypożyczalni sprzętu. System umożliwia dodawanie urządzeń, wypożyczeniu urządzeń, zarządzanie użytkownikami, zarządzanie wypożyczeniami, generowanie raportów. 
W projekcie zostały użyte różne typy sprzętu, oraz różne typy użytkowników. 

---

## Instrukcja uruchomienia

1. Otwórz projekt w Kompilatorze C#
2. Uruchom plik `Program.cs`
3. Program wykona przygotowany scenariusz demonstracyjny w konsoli

---

## Struktura projektu

Projekt został podzielony na kilka głównych części:

* Models – zawiera klasy domenowe (Device, User, Rental oraz klasy dziedziczące)
* Services – zawiera logikę biznesową (BusinessLogic)
* Enums – zawiera typy wyliczeniowe (np. DeviceStatus)
* Program.cs – odpowiada za uruchomienie programu i scenariusze demonstracyjne

---

## Decyzje projektowe

### Podział na warstwy

Projekt został rozdzielony w następujący sposób:

* model domenowy (Models)
* logikę biznesową (Services)
* warstwę prezentacji (Program.cs)

Dzięki temu:

* Program.cs - nie zawiera logiki biznesowej
* operacje są wykonywane przez "BusinessLogic"
* kod jest bardziej czytelny i łatwiejszy do rozbudowy

---

### Kohezja (spójność klas)

Każda klasa ma jedną odpowiedzialność:

* Device – reprezentuje sprzęt
* User – reprezentuje użytkownika
* Rental – odpowiada za pojedyncze wypożyczenie
* BusinessLogic – zawiera operacje systemowe (wypożyczenie, zwrot, raport)

---

### Coupling (powiązania między klasami)

Ograniczone zależności: 

* Program.cs korzysta tylko z "BusinessLogic"
* "BusinessLogic" zarządza listami obiektów
* klasy modeli nie znają logiki biznesowej

Dzięki temu zmiana jednej części systemu nie wpływa bezpośrednio na inne.

---

### Dziedziczenie

Dziedziczenie zostało użyte tam, gdzie ma sens:

* Device -> Laptop, Camera, Projector
* User -> Student, Employee

Pozwala to na:
* wspólne właściwości (np. Id, Name)
* różne inne specyficzne cechy dla typów

---

### Status sprzętu

Zastosowano enum DeviceStatus, który pozwala rozróżnić:

* Available (dostępny)
* Rented (wypożyczony)
* Unavailable (uszkodzony)

Dzięki temu stan sprzętu jest czytelny i łatwy do rozszerzenia.

---

### Obsługa błędów

Zamiast wyjątków zastosowano prosty mechanizm komunikatów:

* Console.WriteLine(...)
* przerywanie operacji (return)

Jest to świadoma decyzja, aby zachować prostotę rozwiązania.

---

## Funkcjonalności

System obsługuje:

* dodawanie sprzętu
* dodawanie użytkowników
* wypożyczanie sprzętu
* zwrot sprzętu
* naliczanie kary za opóźnienie
* oznaczanie sprzętu jako niedostępnego
* wyświetlanie listy sprzętu
* wyświetlanie dostępnych urządzeń
* wyświetlanie aktywnych wypożyczeń
* wyświetlanie przeterminowanych wypożyczeń
* generowanie raportu końcowego

---

## Scenariusz demonstracyjny

W Program.cs został przygotowany scenariusz pokazujący:

* dodanie sprzętu i użytkowników
* poprawne wypożyczenie
* próbę wykonania błędnej operacji
* zwrot w terminie
* zwrot po terminie (z karą)
* raport końcowy

---

## Uwagi

Projekt został wykonany z naciskiem na prostotę oraz czytelność. 

---
