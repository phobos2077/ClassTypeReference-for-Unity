README
======

A class which provides serializable references to `System.Type` of classes with an accompanying custom property drawer which allows class selection from drop-down.

![screenshot](https://bitbucket.org/rotorz/classtypereference-for-unity/raw/master/screenshot.png)

Whilst we have not encountered any platform specific issues yet, the source code in this repository *might* not necessarily work for all of Unity's platforms or build configurations. It would be greatly appreciated if people would report issues using the [issue tracker](https://github.com/SolidAlloy/ClassTypeReference-for-Unity/issues).

This is a fork of the currently inactive project by Rotorz: [ClassTypeReference for Unity](https://bitbucket.org/rotorz/classtypereference-for-unity/src/master/)

## Install via Git URL

Project supports Unity Package Manager. To install the project as a Git package do the following:

1. In Unity, open **Window** -> **Package Manager**.
2. Press the **+** button, choose "**Add package from git URL...**"
3. Enter "https://github.com/SolidAlloy/ClassTypeReference-for-Unity.git#upm" and press **Add**.

Usage Examples
--------------

Type references can be made using the inspector simply by using `ClassTypeReference`:

```csharp
using UnityEngine;
using TypeReferences;

public class ExampleBehaviour : MonoBehaviour
{
    public ClassTypeReference greetingLoggerType;
}
```

A default value can be specified in the normal way:

```csharp
public ClassTypeReference greetingLoggerType = typeof(DefaultGreetingLogger);
```

You can apply one of two attributes to drastically reduce the number of types presented when using the drop-down field.

```csharp
using UnityEngine;
using TypeReferences;

public class ExampleBehaviour : MonoBehaviour
{
    // Allow selection of classes that implement an interface.
    [ClassImplements(typeof(IGreetingLogger))]
    public ClassTypeReference greetingLoggerType;

    // Allow selection of classes that extend a specific class.
    [ClassExtends(typeof(MonoBehaviour))]
    public ClassTypeReference someBehaviourType;
}
```

To create an instance at runtime you can use the `System.Activator` class from the .NET / Mono library:

```csharp
using System;
using UnityEngine;
using TypeReferences;

public class ExampleBehaviour : MonoBehaviour
{
    [ClassImplements(typeof(IGreetingLogger))]
    public ClassTypeReference greetingLoggerType = typeof(DefaultGreetingLogger);

    private void Start()
    {
        if (greetingLoggerType.Type == null)
        {
            Debug.LogWarning("No type of greeting logger was specified.");
        }
        else
        {
            var greetingLogger = Activator.CreateInstance(greetingLoggerType) as IGreetingLogger;
            greetingLogger.LogGreeting();
        }
    }
}
```

Presentation of drop-down list can be customized by supplying a `ClassGrouping` value to any of the attributes: `ClassTypeConstraint`,  `ClassImplements` or `ClassExtends`.

- **ClassGrouping.None** - No grouping, just show type names in a list; for instance, "Some.Nested.Namespace.SpecialClass".

- **ClassGrouping.ByNamespace** - Group classes by namespace and show foldout menus for nested namespaces; for instance, "Some > Nested > Namespace > SpecialClass".

- **ClassGrouping.ByNamespaceFlat** (default) - Group classes by namespace; for instance, "Some.Nested.Namespace > SpecialClass".

- **ClassGrouping.ByAddComponentMenu** - Group classes in the same way as Unity does for its component menu. This grouping method must only be used for `MonoBehaviour` types.

For instance,

```csharp
using UnityEngine;
using TypeReferences;

public class ExampleBehaviour : MonoBehaviour
{
    [ClassImplements(typeof(IGreetingLogger), Grouping = ClassGrouping.ByAddComponentMenu)]
    public ClassTypeReference greetingLoggerType;
}
```



You can exclude **(None)** so that no one can choose it from the dropdown. Use it with any of the attributes like this:

```csharp
using UnityEngine;
using TypeReferences;

public class ExampleBehaviour : MonoBehaviour
{
    [ClassTypeConstraint(ExcludeNone = true)]
    public ClassTypeReference someTypeExample;
}
```

Note that the type can still be null by default or if set through code.

Credits
------------

- [Original creator of the repo](https://bitbucket.org/rotorz)
- GitHub action to split the upm branch was created by [rfadeev](https://github.com/rfadeev)

Contribution Agreement
----------------------

This project is licensed under the MIT license (see LICENSE). To be in the best
position to enforce these licenses the copyright status of this project needs to
be as simple as possible. To achieve this the following terms and conditions
must be met:

- All contributed content (including but not limited to source code, text,
  image, videos, bug reports, suggestions, ideas, etc.) must be the
  contributors own work.

- The contributor disclaims all copyright and accepts that their contributed
  content will be released to the public domain.

- The act of submitting a contribution indicates that the contributor agrees
  with this agreement. This includes (but is not limited to) pull requests, issues,
  tickets, e-mails, newsgroups, blogs, forums, etc.

