# APBD - C# Projekt 1

Aplikacja konsolowa stworzona z użyciem C# dla uczelnianej wypożyczalni sprzętu. Pozwala na operacje takie jak dodawanie nowych urządzeń (Kamery, Laptopy, Projektory)  czy rejestracja nowych użytkowników (Pracownicy i Studenci). Kluczowe funkcjonalności oferowane przez system to wypożyczenia (z możliwością ich zakończenia oraz ewentualnie naliczenia kary), śledzenie dostępności urządzeń i wyświetlanie prostych raportów na ich temat.

## Decyzje projektowe

### Architektura projektu

- `/Exceptions` - Zawiera wyspecjalizowane wyjątki do obsługi specyficznych sytuacji (urządzenie aktualnie wypożyczone, przekroczony limit itd.). Istnieje w celu zapewnienia poprawności działania systemu zgodnie z wymaganiami biznesowymi.
- `/Models` - Modele urządzenia, wypożyczenia i użytkowników systemu. Zostały utworzone dwie abstrakcyjne klasy bazowe (`Person` oraz `Device`) zawierające części wspólne oraz konkretne klasy dziedziczące. Rozszerzenia klasy `Person` stanowią `Employee` oraz `Student`, a klasy `Camera`, `Laptop`, `Projector` dziedziczą z `Device`. Zgodnie z wymaganiami biznesowymi, każdy obiekt konkretnej klasy zawiera unikalny identyfikator, a niektóre klasy dają dostęp do wszystkich jej obiektów poprzez statyczne pole (w celu ułatwienia wykonywania operacji w serwisach).
- `/Services` - Serwisy zaprojektowane do obsługi logiki biznesowej. Każdy z nich stanowi konkretną implementację odpowiedniego interfejsu, co zapewnia low coupling i ułatwia przyszłą rozbudowę systemu.

### Struktura katalogów

- Zastosowana struktura katalogów i odpowiednia separacja klas zapewnia, że zmiana jednej zasady biznesowej (np. walidacja wypożyczenia) nie wymaga modyfikacji kodu odpowiedzialnego za coś innego (np. generowanie raportów).
- Projekt podzielono na katalogi `Models`, `Services`, `Exceptions`. Ułatwia to innym programistom nawigacje po projekcie oraz zrozumienie, gdzie szukać wybraną logikę. Sprawia, że kod jest prostszy w utrzymaniu i łatwiej rozszerzalny. Znalezienie konkretnego miejsca pod modyfikacje zajmuje znacznie mniej czasu.

### Kohezja

Dobrym przykładem zadbania o wysoką kohezję jest serwis **RentalValidatorService**, który jest odpowiedzialny za przestrzeganie zasad wypożyczeń. Wszystkie metody, które ten serwis zawiera są powiązane z jednym, tym samym kontekstem biznesowym - odpowiadają za walidację wypożyczenia.

### Coupling

W projekcie zadbano o uniknięcie wysokiego couplingu.
- Użycie interfejsów w klasach serwisowych. Każdy serwis w aplikacji jest konkretną implementacją jakiegoś interfejsu. W `Program.cs` i wewnątrz serwisów obiekty klas serwisowych są traktowane jako typu interfejsowego zamiast jako typu konkretnej klasy. Dzięki temu, w przyszłości można np. w prosty sposób podmienić sposób raportowania jedynie poprzez podmianę implementacji `IReportService`.
- Limity wypożyczeń są zaszyte w modelach użytkowników, dzięki czemu serwis walidujący nie musi znać konkretnego typu osoby, by sprawdzić jej uprawnienia.

## Uruchomienie

```
# Sklonuj repozytorium
git clone git@github.com:P4ZD4N/APBD-Cw1-s30359.git
# Nawiguj do katalogu projektu
cd /path/to/APBD-Cw1-s30359
# Przywracanie pakietów (opcjonalne)
dotnet restore
# Uruchom aplikacje
dotnet run 