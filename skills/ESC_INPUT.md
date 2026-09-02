# ESC INPUT SKILL

`Console.ReadLine()` не ловит ESC без Enter.  
Поэтому:
1. Читаем первую клавишу `Console.ReadKey(intercept: true)`.
2. Если ESC — выход.
3. Иначе эта клавиша становится первым символом, остаток читается через `ReadLine()`.

Так выполняется требование лабораторной.