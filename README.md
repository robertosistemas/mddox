[![NuGet version](https://badge.fury.io/nu/LoxSmoke.mddox.svg)](https://badge.fury.io/nu/LoxSmoke.mddox) [![NuGet](https://img.shields.io/nuget/dt/LoxSmoke.mddox.svg)](https://www.nuget.org/packages/LoxSmoke.mddox) 

# mddox

Global tool that creates markdown documentation using reflection and XML comments extracted from the source code by the compiler.

[Sample documentation generated by the tool](https://github.com/loxsmoke/DocXml/blob/master/api-reference.md)

[MSDN page on XML documentation comments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments)


## Installation

```bash
dotnet tool install -g loxsmoke.mddox
```

## Uninstallation

```bash
dotnet tool uninstall -g loxsmoke.mddox
```

## Usage

```bash
mddox
Usage: mddox <assembly> [optional-parameters]

<assembly>   - The name of the assembly to document.
```
Optional parameters:

Short format | Long format | Comment
|---|---|---|
| -**o** output_md |--**output** output_md  | The name of the markdown output file. |
| -**f** format | --**format** format   |  The markdown file format. Valid values: github,bitbucket. |
|   | --**all-recursive**           | Step into all referenced assemblies recursively. This option ignores all assemblies specified by --recursive option below. |
| -**r** assembly  | --**recursive** assembly | Step recursivelly only into specified assembly or assemblies.<br> This parameter can be used multiple times to specify multiple assemblies. |
| -**m**  | --**ignore-methods**      | Do not generate documentation for methods and constructors. |
| -**d**  | --**method-details**      | Generate detailed documentation for methods and constructors.<br>Setting has no effect if --ignore-methods is specified. |
| -**a** name  | --**ignore-attribute** name | Do not generate documentation for properties with specified custom attribute. For example  JsonIgnoreAttribute<br> This parameter can be used multiple times to specify multiple sttributes. |
| -**t** name  | --**type** name         | Document only this type and all types referenced by this type. |
| -**s** [view]  | --**msdn** [view]     | Generate links to the MSDN documentation for System.* and Microsoft.* types.<br>The documentation pages are located at this site https://docs.microsoft.com<br>View is an optional parameter of URL specifying the version of the type. For example: netcore-3.1 |  
| -**i** "title" | --**title** "title"   | Document title. Use {assembly} and {version} in the format string to insert the name of the assembly and assembly version. |
| -**n**  | --**no-title**            | Do not write the "created by mddox at date" in the markdown file. |
| -**v**  | --**verbose**             | Print some debug info when generating documentation. It may help troubleshooting some issues such as missing type information of referenced assemblies. |
  
For best results enable XML documentation build switch in your project and use publish build to get all referenced assemblies in one folder.

Documenting all types of one assembly

```bash
mddox MyAssembly.dll
```

Documenting only fields and properties of all types in assembly

```bash
mddox MyAssembly.dll --ignore-methods
```

Documenting types that do not have specified custom attributes

```bash
mddox MyAssembly.dll --ignore-attribute JsonIgnoreAttribute --ignore-attribute XmlIgnore
```

Document one type and all referenced types from different assemblies 

```bash
mddox MyAssembly.dll --type ClassToDocument --recursive ReferencedAssembly1.dll --recursive ReferencedAssembly2.dll
```

