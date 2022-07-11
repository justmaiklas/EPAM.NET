# EPAM.NET
 .NET Mentoring Program Basics

 ## Module #2: .NET Fundamentals

### Home Task
**Task 1:**
Create 3 basic applications for the following .NET platforms:

    .NET Core – console
    .NET Framework – WinForms/WPF
    
*Application requirements:*

Input: {username} (for console app – as a command line parameter)
Output: “Hello, {username}” (via form or separate window) 

**Task 2:**  
Create a .NET standard library which will handle “hello world” concatenation logic. Add this library for both projects. Change the output to following: “{current_time} Hello, {username}!”

**Task 3 (extra, not scored):**
Create Xamarin or MAUI hello world applications. 

## How to use
Two directories can be found:
- source
- compiled

Each one of these directories consists of three more sub-directories: 
- ClassLibrary
- ConsoleApp
- WinForms

**ClassLibrary** can not be executed directly, just a class.

**ConsoleApp** can be executed in the following order:
```sh
cd compiled/ConsoleApp
ConsoleApp1.exe ...
```
For example:
```sh
ConsoleApp1.exe Aurimas
```

**WinForms** can be ran and exucuted directly by opening it.
```
cd compiled/WinForms
WinFormsApp1.exe
```
