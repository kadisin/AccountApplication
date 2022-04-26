# AccountApplication
Aplikacja desktopowa przeznaczona do zarządzania kontami użytkowników. Aplikacja napisana przy użyciu WPF na platformie .NET 6.0 przy użyciu wzorca MVVM. W skład aplikacji wchodzi także baza danych.


INSTRUKCJA OBSŁUGI:
1. Należy uruchomić skrypt CreateDatabase_AccountDB_.sql, skrypt został utworzony przy pomocy Microsoft SQL Server Managment Studio.
1a. Został przesłany także skrypt AccountTableCreateScript.sql, tworzący już konkretnie wykorzystywaną w aplikacji tabelę.
2. Należy sprawdzić czy po uruchomieniu skryptu zostały zwrócone trzy przykładowe wiersze z tabeli Account.
3. Należy skompilować i uruchomić aplikację AccountApplication.
4. Aplikacja jest gotowa do użytku.
5. Dane aplikacji dotyczące łączenia się z bazą danych znajdują się w stałej _connectionData (path: AccountApplication.Database.DatabaseContext.cs) 


Po pierwszym uruchomieniu aplikacji powinno pojawić się następujące okno:


![obraz](https://user-images.githubusercontent.com/38622355/165308445-5c2a21f5-3e93-4983-9dc3-4dea98d162f8.png)

