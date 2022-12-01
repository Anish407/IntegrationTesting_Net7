
using StudentManagement.Core.Entities;

namespace StudentManagement.Core.Entities;
public class Family : IDocument
{
    public override string PartitionKey() => Id;
    public Parent[] parents { get; set; }
    public Child[] children { get; set; }
    public Address address { get; set; }
    public int creationDate { get; set; }
    public bool isRegistered { get; set; }
}

public class Address
{
    public string state { get; set; }
    public string county { get; set; }
    public string city { get; set; }
}

public class Parent
{
    public string familyName { get; set; }
    public string givenName { get; set; }
}

public class Child
{
    public string familyName { get; set; }
    public string givenName { get; set; }
    public string gender { get; set; }
    public int grade { get; set; }
    public Pet[] pets { get; set; }
}

public class Pet
{
    public string givenName { get; set; }
}
