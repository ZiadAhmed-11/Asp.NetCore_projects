

Eagle e=new Eagle();
e.Move();

abstract class Animal   // (Abstract Class) Can't take instance from it : just for inheritance
{                       // While (Abstract method) not has body and change in every child.. 
    public virtual void Move()     // Just virtual(primary) use Can override the method in the childs
    {
        Console.WriteLine("Moving");
    }
}

sealed class Eagle: Animal   // (Sealedمختوم) Method can't override /class Can't inherite from it
{
    public override void Move()      // Override the method
    {
        base.Move();       // should write --> base: call the parent as (this)
        Console.WriteLine("The Eagle");

    }

    public void Fly()
    {
        Console.WriteLine("Flying");
        
    }
    
}











class BaseClass
{
    public int x;

    public BaseClass()
    {

    }
    public BaseClass(int value)
    {
        x = value;
    }
}

class SubClass : BaseClass
{
    public SubClass() 
    {
    }

}