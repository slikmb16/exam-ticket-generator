# Exam Ticket Generator (C# Console)

Генератор экзаменационных билетов с записью в Excel `journal.xlsx`.

## Возможности
- Ввод `Last name` и `First name`
- Генерация билета 1..20
- Сохранение **после каждой записи**
- Дозапись в конец без перезаписи старых данных
- Выход по ESC на этапе ввода фамилии
- Обработка ситуации, когда файл открыт в Excel

## Запуск
```bash
dotnet restore
dotnet run
```

## Документация
- [docs/RUN.md](docs/RUN.md)
- [docs/TESTS.md](docs/TESTS.md)
- [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md)
- [skills/ESC_INPUT.md](skills/ESC_INPUT.md)