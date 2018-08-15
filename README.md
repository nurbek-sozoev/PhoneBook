# PhoneBook - Телефонный справочник
Небольшое (тестовое) веб-приложение на ASP.NET Core MVC и Angular.

# Зависимости
- nodejs/npm (https://nodejs.org/)
- ASP.NET Core 2.1 (https://www.microsoft.com/net/download/dotnet-core/2.1)
- .NET Framework 4.5.2 (https://www.microsoft.com/en-us/download/confirmation.aspx?id=42643)
- .Net Core CLI (https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial)

# Запуск проекта
```bash
npm install -g @angular/cli

cd PhoneBook/ClientApp
npm install

cd ..
dotnet run --project PhoneBook.csproj
```

# Что осталось доделать (TODO)
- Механизм аутентификации/авторизации пользователя
- Прикрутить БД
