
# Car Reservation System

## Wymagania

- .NET 6.0 SDK lub nowszy
- Visual Studio 2022 lub nowszy
- SQL Server (lub inna kompatybilna baza danych)
- Przeglądarka internetowa

---

## Instalacja

### 1. Klonowanie repozytorium:
Skopiuj repozytorium na swój lokalny komputer:

```bash
git clone https://github.com/TomasWarchol/Car_reservation_system.git
```

### 2. Otwórz projekt w Visual Studio:
Otwórz plik `.sln` w Visual Studio.

### 3. Przywróć pakiety NuGet:
W Visual Studio przejdź do **Tools > NuGet Package Manager > Package Manager Console** i uruchom:

```bash
Update-Package -reinstall
```

### 4. Konfiguracja łańcucha połączenia z bazą danych:
Edytuj plik `appsettings.json` i skonfiguruj łańcuch połączenia do swojej bazy danych:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CarReservationDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 5. Migracje bazy danych:
W **Package Manager Console** uruchom następujące komendy:

```bash
Add-Migration InitialCreate
Update-Database
```

### 6. Uruchomienie aplikacji:
W Visual Studio naciśnij `F5` lub kliknij **Start** w górnym pasku narzędzi.

---

## Testowi użytkownicy

### Administrator
- **Email**: `admin@admin.com`
- **Hasło**: `Admin1`

### Użytkownik
- **Email**: `222@op.pl`
- **Hasło**: `123456`

---

## Opis działania aplikacji

### Strona główna
Po uruchomieniu aplikacji użytkownik zostaje przekierowany na stronę główną, gdzie może zobaczyć listę dostępnych samochodów do wypożyczenia.

### Logowanie
Użytkownik może się zalogować, aby uzyskać dostęp do dodatkowych funkcji, takich jak wypożyczanie samochodów. Administratorzy mają dodatkowe uprawnienia do zarządzania samochodami.

### Zarządzanie samochodami
- **Dodawanie samochodów**: Administratorzy i menedżerowie mogą dodawać nowe samochody do systemu.
- **Edytowanie samochodów**: Administratorzy i menedżerowie mogą edytować istniejące samochody.
- **Usuwanie samochodów**: Administratorzy mogą usuwać samochody z systemu.

### Wypożyczanie samochodów
Zalogowani użytkownicy mogą wypożyczać dostępne samochody. Jeśli samochód jest już wypożyczony, opcja wypożyczenia jest niedostępna.

### Szczegóły samochodu
Użytkownicy mogą przeglądać szczegóły każdego samochodu, takie jak:
- Kategoria
- Marka
- Model
- Pojemność silnika
- Moc
- Liczba miejsc
- Liczba drzwi
- Rodzaj paliwa
- Skrzynia biegów
- Dostępność

### Powrót do strony głównej
Użytkownicy mogą wrócić do strony głównej, klikając przycisk **"Powrót do strony głównej"**.

---

## Podsumowanie

Aplikacja umożliwia zarządzanie flotą samochodów oraz ich wypożyczanie przez użytkowników. Administratorzy mają dodatkowe uprawnienia do zarządzania samochodami, co pozwala na efektywne zarządzanie zasobami.
```
