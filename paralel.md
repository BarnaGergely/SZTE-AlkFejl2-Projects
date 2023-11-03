# Párhuzamosítás

## Thread

```C#

// egyszerű Thread megadás
Thread t1 = new Thread(SimpleFgv);
Thread t2 = new Thread(() => AdvancedFgv(12, "alma"));

// A szálak csak akkor futnak le, ha elidnítjuk őket
t1.Start();
t2.Start();

t1.Join(t2); // egyik szál megvárja a másikat
t1.Sleep(12); // meghatározott idejű várakoztatás
t1.Abort();  // lelövi a szálat

// egy objektum egy metódusának megadásának egy módja
Thread thread3 = new Thread(new ThreadStart(p1.Count));
Thread thread3 = new Thread(p1.Count);
thread3.Start();

// thread paraméter megadása
Thread thread4 = new Thread(new ParameterizedThreadStart(p2.Count2));
thread4.Start(40)

```

## Task

```C#
// egyszerű task létrehozás
Task task1 = new Task(() => SimpleFgv());
task1.Start() // A Taskot is el kell indítani

Task task2 = new Task.Run(() =>  AdvancedFgv(12, "alma")); // létrehozza és rögtön el is indítja

task2.Wait; // megvárja hogy a task lefusson
Console.WriteLine(task2.Result); // kiiratja a visszatérési értékét
```

### Async task

```C#
// Külön szálon idítható metódus
// (csak void, Task, Task<> visszatérési értékkel használható async)
static async Task<int> Work() {
    int sum = 0;

    // külön szálon lefuttatja ezt, de mivel avait, bevárja a lefutását a folytatás előtt
    // Ha nem lenne avait, párhuzamosan futna ez a rész
    // (Csak async metódusban használható az await)
    await Task.Run(() => {
        for (int i = 0; i < 20; i++) {
            sum += i;
            Console.WriteLine($"Work: {i}");
        }
    });

    Console.WriteLine($"Returning sum {sum}");
    return sum;
}

int Main() {
    Task<int> task = Work(); // lefuttatja a Work-öt külön szálon és eltárolja a visszatérési értékét
    Console.WriteLine(task.Result); // kiiratja az eredményét
}
```
