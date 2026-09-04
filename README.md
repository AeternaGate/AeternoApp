# AeternoApp

Простое WPF-приложение для регистрации пользователей с локальной SQLite-базой данных.

Создано для практики в .NET / C# / WPF.

## Возможности

- Окно логина/регистрации (`LoginWindow`)
- Личный кабинет пользователя (`UserPageWindow`)
- Локальная база данных SQLite (`AeternoAppBase.db`) через Entity Framework
- Встраивание зависимостей через Costura.Fody

## Стек

- **.NET Framework 4.7.2**
- **WPF** (XAML)
- **Entity Framework 6** + **System.Data.SQLite**
- **Costura.Fody** (сборка зависимостей в один exe)

## Структура

```
AeternoApp/
├── App.xaml / App.xaml.cs
├── AppContext.cs          # DbContext (Entity Framework)
├── User.cs                # Модель пользователя
├── LoginWindow.xaml       # Окно входа/регистрации
├── MainWindow.xaml        # Главное окно
├── UserPageWindow.xaml    # Страница пользователя
└── AeternoAppBase.db      # Локальная SQLite-база
```

## Запуск

Откройте `AeternoApp.sln` в Visual Studio (с поддержкой .NET Framework 4.7.2) и соберите проект.
