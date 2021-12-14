# Generics
* Pre-generics: We needed separate class to store different collection of data like a class ListInt and ListBook 
    ```
    namespace Generics{
        public class BookList{
            public void Add(Book book){}

            //indexer
            public Book this[int index]{}
        }
    }
    ```
* One solution for this would be to create an ObjectList class, but the problem is performance due to boxing(while storing) and unboxing(while reading), or if we use reference type then casting would be required. 

* This problem was solved by generics
```
    public class GenericList<T>{
        public void Add(T item){
        }

        public T this[int index]{
        }
    }

    static void Main(string[] args){
        var numbers = new GenericList<int>();
        numbers.Add(19);

        var books = new GenericList<Book>();
        books.Add(new Book());
    }

```

* Generics also supports constraints. These can be applied at method or class level. 
```
    public T Max<T>(T a, T b) where T: IComparable {
        return a.CompareTo(b) > 0 ? a : b;
    }
```

* **Types of Constraint
    1. where T: IInterface // 
    2. where T: Product // any reference type
    3. where T: struct // any value type
    4. where T: class
    5. where T: new() // 

* we can define multiple value for constraint  like where T: IComparable, new()