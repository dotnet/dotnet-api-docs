// <Snippet1>
using System;

public class Person
{
    private string _name;

    public Person()
    { }

    public Person(string name) => this._name = name;

    public string Name
   { get => this._name;
     set => this._name = value; }

    public override string ToString() => this._name;
}
// </Snippet1>
