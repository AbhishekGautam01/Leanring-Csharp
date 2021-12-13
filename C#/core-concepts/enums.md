# enums
* Java does enums different than c#. 
```
    // JAVA ENUM EXAMPLE 

    // Java enums can have private constructor
    // We can expose properties out of enums also 
    public enum Subscriptions {
        FREE("Free", .0), 
        PREMIUM("Premium", .25), 
        VIP("Vip", .50) 

        private final String name;
        private final double discount;

        Subscriptions(String name, double discount){
            this.name = name ; 
            this.discount = discount;
        }

        public String getName(){
            return name;
        }

        public String getDiscount(){
            return discount;
        }
    }

    public static void main(String[] args){
        var freeTier = Subscriptions.FREE;
        System.out.println(freeTier);
        //consuming enums methods. 
        System.out.println("Discount for " + freeTier.getName() + " is " + freeTier.getDiscount());
    }
```

* To get this smart enums in C# by using package SmartEnum
```
using Ardalis.SmartEnum;

namespace SmartEnums;

public sealed class Subscriptions : SmartEnum<Subscription>{
    public static readonly Subscriptions Free = new Subscription("Free", 1, 0.0);
    public static readonly Subscriptions Premium = new Subscription("Premium",2 ,.25);
    public static readonly Subscriptions Vip = new Subscription("Vip", 3, .50);

    public double Discount { get;}


    public Subscriptions(string name, int value, double discount): base(name, value, discount){
        Discount = discount
    }
}

// to consume this enum
var free = Subscriptions.Free;
var freeToo = Subscriptions.Free;

// Another way to get these smart enum values 
var freefromName = Subscriptions.FromName("Free");
var freeFromValue = Subscriptions.FromValue(1);

Console.WriteLine(free == freeToo);
Console.WriteLine($"Discount is {freeFromName.Discount}")
```