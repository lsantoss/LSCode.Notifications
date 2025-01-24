# LSCode.Notifications

[![NuGet version (LSCode.Notifications)](https://img.shields.io/nuget/v/LSCode.Notifications.svg?style=flat-square)](https://www.nuget.org/packages/LSCode.Notifications)

## Application:

LSCode.Notifications is a library created to facilitate the management and handling of notifications of inconsistencies in projects.

It allows you to identify and consolidate failures or error messages in an organized way, useful for systems that require consistent and clear validations.

Type: Class Library.

## Framework:

- .Net 9

## Dependencies:

- N/A

## How to install:

- Click on the following link and see here some ways to install: [click here](https://www.nuget.org/packages/LSCode.Notifications "LSCode.Notifications page on nuget.org").

## How to use the Notification class:

In the file that you want to use the class, you must import the following namespace:

```c#
using LSCode.Notifications.Models;
```

It is composed with 2 properties:
  - Property
	- Type: string
	- Description: Validated property that has the inconsistency
  - Message
	- Type: string
	- Description: Detailed description of the inconsistency found

Then you can create an instance of notification, passing by parameter: 
  - Property
  - Message

## How to use Notifiable class:

In the file that you want to use the class, you must import the following namespace:

```c#
using LSCode.Notifications.Models;
```

Then it will be possible to inherit the notifiable class. 

It is not possible to create an instance of the class, it is only possible to inherit it.

It is composed with 3 properties:
  - Valid
	- Type: boolean
	- Description: Returns `true` if there are no notifications and `false` otherwise it happens
  - Invalid
	- Type: boolean
	- Description: Returns `true` if there is at least one notification and `false` otherwise it happens
  - Notifications 
	- Type: IReadOnlyCollection\<Notification>
	- Description: List containing all inconsistency notifications

The values ​​of these properties are modified only through the AddNotification() methods and ClearNotifications() method.

It is possible to add notifications through the **AddNotification()** method, which has 5 overloads:

```c#
void AddNotification(string property, string message);
void AddNotification(Notification notification);
void AddNotification(IEnumerable<Notification> notifications);
void AddNotification(Notifiable notifiable);
void AddNotification(IEnumerable<Notifiable> notifiableList);
```

It is possible to clear the list of notifications and return to the initial state of all properties with the **ClearNotifications()** method:

```c#
void ClearNotifications();
```