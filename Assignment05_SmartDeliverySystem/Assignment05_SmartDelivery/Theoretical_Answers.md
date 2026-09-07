# Assignment 05 - Part 01 Theoretical Answers

## Q1 Object Copying

### a) What happens when you assign one object variable to another object variable?
Both variables point to the same object in memory. A class variable stores a reference to the object.

### b) Does assigning one object to another create a new object?
No. For example:

```csharp
Shipment shipment2 = shipment1;
```
No new Shipment is created. Both variables refer to the same Shipment object.

### c) What is the difference between copying an object and copying its reference?
Copying a reference means two variables point to the same object. Copying an object means a new object is created, so the two objects are separate.

## Q2 Shallow Copy vs Deep Copy

### a) What is a Shallow Copy?
A shallow copy creates a new outer object and copies its fields. Reference-type fields still point to the same referenced objects.

### b) What is a Deep Copy?
A deep copy creates a new outer object and also creates new objects for the reference-type members that need to be independent.

### c) What happens to reference-type members when a Shallow Copy is created?
Their references are copied, so the original and copied objects point to the same referenced object.

### d) What happens to reference-type members when a Deep Copy is created?
A new referenced object is created, so changing it does not affect the original referenced object.

### e) Give one situation where Deep Copy would be safer than Shallow Copy.
Deep Copy is safer when two shipments must have completely independent delivery addresses. Changing the copied address should not change the original shipment.

## Q3 Static Members

### a) What is a static field, and how is it different from an instance field?
A static field belongs to the class itself and is shared by all objects. An instance field belongs to one object, so every object has its own value.

### b) What is a static method? Can a static method directly access instance members?
A static method belongs to the class. It can directly access static members, but it cannot directly access instance members because there is no specific object associated with the static method.

### c) What is a static constructor, and when is it executed?
A static constructor is used to initialize static data. It is executed automatically once before the class is first used. It cannot be called manually.

### d) What is a static class? Can you create an object from a static class?
A static class can contain only static members. No, you cannot create an object from a static class.

## Q4 Extension Methods

### a) What is an Extension Method?
An extension method is a method that allows us to add a method-like feature to an existing type without modifying its source code or creating a derived class.

### b) What keyword must be used in the first parameter of an extension method?
The `this` keyword.

Example:

```csharp
public static string GetSummary(this Shipment shipment)
```

### c) Where must an extension method be declared?
It must be inside a static class, and the extension method itself must be static.

### d) Can an extension method access private members of the class it extends?
No. It can access only members that are accessible from outside the class, such as public members.

## Q5 Partial Classes and Partial Methods

### a) What is a Partial Class?
A partial class allows one class to be split into multiple files. All parts are combined by the compiler into one class.

### b) Why would a developer split one class into multiple files?
To keep a large class organized and easier to read. Different files can contain different responsibilities of the same class.

### c) What is a Partial Method?
A partial method is a method declared in one part of a partial class and implemented in another part of the same partial class.

### d) What happens if a declared partial method has no implementation?
For a valid optional partial method declaration, the compiler can remove the declaration and its calls if there is no implementation. In this assignment, the method is implemented in another Shipment part so that a message is displayed.
