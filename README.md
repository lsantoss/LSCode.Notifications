# LSCode.Notifications

## Application:
Offers codes to facilitate creation and handling of inconsistency notifications in projects produced by LSCode.

[![NuGet version (LSCode.Notifications)](https://img.shields.io/nuget/v/LSCode.Notifications.svg?style=flat-square)](https://www.nuget.org/packages/LSCode.Notifications)

---

## Frameworks:
- .Net Standard 2.1

---

## Current features:
- Classes for managing inconsistency notifications

---

## Dependencies:
- N/A

---

## Dependencies (Test projects):
- Microsoft.NET.Test.Sdk
- NUnit
- NUnit3TestAdapter
- NUnit.Analyzers
- coverlet.collector

---

## How to install:
- Click on the following link and see here some ways to install: [click here](https://www.nuget.org/packages/LSCode.Notifications "LSCode.Notifications page on nuget.org").

---

## How to use the **Notification** class:
First install the package, for example:

```xml
<PackageReference Include="LSCode.Notifications" Version="x.x.x" />
```

In the file that you want to use the class, you must import the following namespace:

```c#
using LSCode.Notifications.Models;
```

It is composed with 2 properties:
  - **Property** - string type, with default value of true
  - **Message** - string type, Detailed description of the inconsistency found

Then you can create an instance of notification, passing by parameter: 
  - **Property**
  - **Message**

```c#
using LSCode.Notifications.Models;

namespace MyNamespace
{
  public class MyClass
  {
    public MyClass() { }

    public Notification Method()
    {
	  var property = "Password";
	  var message = "The password must contain a maximum of 6 characters";

      var notification = new Notification(property, message);

      return notification;
    }
  }
}
```

---

## How to use **Notifiable** class:
First install the package, for example:

```xml
<PackageReference Include="LSCode.Notifications" Version="x.x.x" />
```

In the file that you want to use the service, you must import the following namespace:

```c#
using LSCode.Notifications.Models;
```

Then it will be possible to inherit the notifiable class. It is not possible to create an instance of the class, it is only possible to inherit it.

It is composed with 3 properties:
  - **Valid** - boolean type, with default value of true
  - **Invalid** - boolean type, with default value of false
  - **Notifications** - list of notifications, with default value of an empty list

The values ​​of these properties are modified only through the AddNotification() method, being applied:
  - **Valid** - the value is set to false
  - **Invalid** - the value is set to true
  - **Notifications** - a notification is added to the list

It is possible to add notifications through the **AddNotification()** method, which has 5 overloads:

```c#
  void AddNotification(string property, string message);
  void AddNotification(Notification notification);
  void AddNotification(IEnumerable<Notification> notifications);
  void AddNotification(Notifiable notifiable);
  void AddNotification(IEnumerable<Notifiable> notifiableList);
```

It is possible to clear the list of notifications and return to the initial state of all properties with the **Clear()** method:

```c#
  void Clear();
```

Below is a simple example of using one of the overloads of the **AddNotification()** method, in the private IsValid() method:

```c#
using LSCode.Notifications.Models;

namespace MyNamespace
{
  public class MyClass : Notifiable
  {
    public string Login { get; set; }
    public string Password { get; set; }

    public MyClass() 
    { 
      Login = string.Empty;
      Password = "this is my long password";

      var valid = IsValid();
    }

    private bool IsValid()
    {      
      if (string.IsNullOrWhiteSpace(Login))
        AddNotification("Login", "The login must not be null, empty or blanks");

      if (Password.Length > 6)
        AddNotification("Password", "The password must contain a maximum of 6 characters");

      return Valid;
    }
  }
}
```

Following the example above, inconsistencies were found as a result, so **two Notifications** were added, the **Valid property receives a value of false** and the **Invalid property receives a value of true**.

To exemplify the use of the **Valid** and **Invalid** properties, the IsValid() method will return the value of false contained in the Valid variable.

It is interesting to note that this return was made just to exemplify the use of the **Valid** and **Invalid** properties, as it is possible to obtain this data at any time in the class.

To finish, this will be the result represented in JSON:

```json
  {
    "Login": "",
    "Password": "this is my long password",
    "Valid": false,
    "Invalid": true,
    "Notification": [
      {
        "Property": "Login",
        "Message": "The login must not be null, empty or blanks"
      },
      {
        "Property": "Password",
        "Message": "The password must contain a maximum of 6 characters"
      }
    ]
  }
```

---