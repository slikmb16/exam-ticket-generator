# ARCHITECTURE

- `EnsureWorkbookExists()` — создаёт `journal.xlsx` с шапкой при первом запуске.
- `ReadLastNameWithEsc()` — обрабатывает ESC через `Console.ReadKey`.
- `ReadNonEmpty()` — не пропускает пустой ввод, делает Trim.
- `AppendRecordWithRetry()` — дописывает строку и сразу сохраняет; при блокировке файла даёт повтор.

Ключевое требование надежности: сохранение сразу после каждой записи.