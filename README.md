# CircleAnglePicker Control for Windows Forms

[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2005%20%2F%202017-68217a.svg?style=flat)](https://www.visualstudio.com/)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms--68217a.svg?style=flat)](https://docs.microsoft.com/en-us/dotnet/framework/winforms/)
[![.NET Framework](https://img.shields.io/badge/.NET-v2.0%20%2F%20v4.7-68217a.svg?style=flat)](https://www.microsoft.com/net/download)
[![License](https://img.shields.io/github/license/meet-aleksey/CircleAnglePicker.svg?style=flat&label=License)](https://github.com/meet-aleksey/CircleAnglePicker/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/CircleAnglePicker.svg?style=flat&label=Downloads)](https://www.nuget.org/packages/CircleAnglePicker/)

This is user interface control for Windows Forms, which allows to pick an angles.

The control of a circular shape, something similar can be seen in Photoshop.

![Preview](preview.gif)

To install CircleAnglePicker, run the following command in the Package Manager Console:

```
Install-Package CircleAnglePicker
```

## How to use

Install the CircleAnglePicker package in your Windows Forms project.

Or [download an archive file containing binary assemblies](https://github.com/meet-aleksey/CircleAnglePicker/releases), 
unpack it and add to your project a reference to the assembly of the version of .NET Framework that you are using.

Now you can create an instance of the CircleAnglePicker and add to the form:

```C#
var circleAnglePicker = new CircleAnglePicker();

Controls.Add(circleAnglePicker);
```

If you can not find the control on the toolbox in designer mode, you need to add CircleAnglePicker to the toolbox:

[![How to add a control to the Visual Studio toolbox](youtube.jpg)](https://www.youtube.com/watch?v=Zasmw8zfIbI)

1. Right-click on toolbox.
2. Select "Choose Items".
3. Browse the CircleAnglePicker assembly on your computer.
4. Add the item.
5. Enjoy!

[See also article about installing and using CircleAnglePicker](https://goo.gl/4mQsDw).

## Requirements

* .NET Framework 2.0/3.5/4.0/4.5/4.6/4.7 or later;
* Windows Forms.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Copyright © 2018, [@meet-aleksey](https://github.com/meet-aleksey)