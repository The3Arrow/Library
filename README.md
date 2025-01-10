# Dokumentacja Systemu Zarządzania Biblioteką

## 1. Wprowadzenie

System zarządzania biblioteką umożliwia zarządzanie książkami, użytkownikami, wypożyczeniami oraz zwrotami w bibliotece. System jest stworzony jako aplikacja webowa z wykorzystaniem ASP.NET Core MVC oraz bazy danych SQL Server.

---

## 2. Wymagania

### System operacyjny:
- Windows 10/11, Linux, lub macOS.

### Serwer aplikacji:
- ASP.NET Core 8.0.10 lub nowszy.

### Serwer bazy danych:
- Microsoft SQL Server (lokalny lub zdalny).

### Przeglądarka:
- Google Chrome, Firefox, Microsoft Edge.

### Środowisko programistyczne:
- Visual Studio 2022.

---

## 3. Diagram baz danych

Poniżej znajduje się uproszczony diagram relacji baz danych:

- **Tabela `Books`**: Przechowuje informacje o książkach.
- **Tabela `Category`**: Przechowuje informacje o kategoriach.
- **Tabela `Copies`**: Przechowuje informacje o kopiach książki.
- **Tabela `Clients`**: Przechowuje informacje o klientach.

---

## 4. Konfiguracja

### 4.1. Łańcuch połączenia z bazą danych

Edytuj plik `appsettings.json` w katalogu głównym projektu. Zaktualizuj sekcję `ConnectionStrings`:
```json:
"ConnectionStrings": { 
  "DevConnection": "Server=YOUR_SERVER_NAME;Database=Library;Trusted_Connection=True;TrustServerCertificate=True;" 
}
```
- **YOUR_SERVER_NAME**: Nazwa serwera SQL (np. localhost lub DESKTOP-XXXX\SQLEXPRESS).

### 4.2. Dodaj migracje i zaktualizuj bazę danych

W konsoli menadżera pakietów wpisz komendy:

```bash
Add-Migration Initial
Update-Database
```
### 4.3 Uruchom aplikację

1. Uruchom Microsoft SQL Server.
2. Otwórz projekt za pomocą Visual Studio i uruchom aplikację (F5).

## 5. Opis działania aplikacji

### 5.1 Funkcjonalność

**Użytkownik:**
- Przeglądanie książek.

**Administrator:**
- Edycja i dodawanie książek.
- Edycja i dodawanie kategorii.
- Edycja i dodawanie kopii książek.
- Edycja i dodawanie klientów.
- Przypisywanie wypożyczonej książki do użytkownika oraz obsługa zwrotów.

### 5.2 Obsługa aplikacji

Strona główna przedstawia listę książek, którą widzi każdy użytkownik.

Aby przejść do widoku administratora, należy przejść pod adres: [https://localhost:7265/Books/Index](https://localhost:7265/Books/Index).

W tym miejscu możemy edytować lub dodać książkę.

