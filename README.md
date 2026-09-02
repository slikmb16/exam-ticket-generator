<div align="center">

# 🎓 Exam Ticket Generator
### Консольное приложение на C# для генерации экзаменационных билетов и записи в Excel

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Console-239120?logo=c-sharp)
![Excel](https://img.shields.io/badge/Excel-journal.xlsx-217346?logo=microsoft-excel)
![Language](https://img.shields.io/badge/language-C%23-178600)

</div>

---

## ✨ Возможности

- ✅ Ввод `Last name` и `First name`
- 🎲 Генерация номера билета от **1 до 20**
- 💾 Сохранение **после каждой записи**
- 📄 Автоматическое создание `journal.xlsx` с шапкой
- ➕ Дозапись в конец файла без перезаписи старых данных
- ⌨️ Выход по **ESC** на этапе ввода фамилии
- 🛡️ Обработка ошибки, если файл открыт в Excel (без падения приложения)

---

## 🧱 Структура проекта

```text
exam-ticket-generator/
├─ Program.cs
├─ docs/
│  ├─ RUN.md
│  ├─ TESTS.md
│  └─ ARCHITECTURE.md
├─ skills/
│  └─ ESC_INPUT.md
├─ README.md
└─ .gitignore
```

---

## 🚀 Быстрый запуск

### 1) Установить .NET SDK
Проверка:

```bash
dotnet --version
```

### 2) Восстановить зависимости

```bash
dotnet restore
```

### 3) Запустить приложение

```bash
dotnet run
```

---

## 🧪 Проверка требований лабораторной

1. Ввести 3 студентов, выйти по ESC → в `journal.xlsx` есть 3 строки + шапка.
2. Запустить снова, ввести ещё 2 студентов → стало 5 строк, первые 3 не изменены.
3. После ввода студента аварийно закрыть приложение → последняя запись сохранена.
4. Открыть `journal.xlsx` в Excel и попробовать добавить запись → программа показывает понятную ошибку и не падает.
5. Нажать Enter на пустом поле → приложение повторяет запрос.

---

## 🏗️ Технические решения

- Для работы с Excel используется библиотека **ClosedXML**.
- `EnsureWorkbookExists()` создаёт файл и шапку при первом запуске.
- `ReadNonEmpty()` валидирует ввод и убирает пробелы по краям (`Trim`).
- `ReadLastNameWithEsc()` использует `Console.ReadKey()` для обработки ESC до Enter.
- `AppendRecordWithRetry()` сразу сохраняет изменения и обрабатывает блокировку файла.

---

## 📚 Документация

- [Запуск](docs/RUN.md)
- [Тест-кейсы](docs/TESTS.md)
- [Архитектура](docs/ARCHITECTURE.md)
- [ESC Input Skill](skills/ESC_INPUT.md)

---

## 👨‍🎓 Автор

Лабораторная работа по программированию: генератор экзаменационных билетов.
