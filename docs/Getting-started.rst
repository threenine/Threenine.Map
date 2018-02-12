Getting Started Guide
=====================

What is Threenine.Map
*********************

Threenine.Map is a code library to enable easier and leaner object-object mapper. Under the hood it makes use of the most popular C# object-object mapper  `Automapper 
<http://automapper.org/>`_. 

Object-object mapping works by transforming an input object of one type into an output object of a different type. 

What makes AutoMapper interesting is that it provides some interesting conventions to take the dirty work out of figuring out how to map type A to type B. As long as type B follows AutoMapper's established convention, almost zero configuration is needed to map two types.

Why use Threenine.Map
*********************
Using AutoMapper, developers typically place mapping configuration in a completely separate profile class, which creates an artificial barrier between two things that 
are likely to change together:  The Object Model and the mapping definition.  
 
 Threenine.Map provides and alternative approach to help keep you Automapper Configuration logic clean and closer  to the object model you're mapping whether that be Domain Objects,
 View Models and entities.
 
 Using the magic of reflection and assembly scanning Threenine.Map will also ensure your mapping logic is available when needed.


How to install
**************

Threenine.map is available via a nuget package `Threenine.map 
<https://www.nuget.org/packages/Threenine.Map/>`_.  and can be easily installed to your project using either

via package manager :
::

   Install-Package Threenine.Map  

Or dotnet core cli :
::

    dotnet add package Threenine.Map


