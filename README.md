[![CircleCI](https://circleci.com/gh/CptWesley/CoreResourceManager.svg?style=shield)](https://circleci.com/gh/CptWesley/CoreResourceManager)
[![BetterCodeHub](https://bettercodehub.com/edge/badge/CptWesley/CoreResourceManager?branch=master)](https://bettercodehub.com/results/CptWesley/CoreResourceManager)
[![CodeCov](https://codecov.io/gh/CptWesley/CoreResourceManager/branch/master/graph/badge.svg)](https://codecov.io/gh/CptWesley/CoreResourceManager/)

# CoreResourceManager
Simplifies dealing with embedded resources in .NET core projects.

#### Prerequisites:
- Application supporting .NET Standard.

#### Usage:
- Get the [nuget](https://www.nuget.org/packages/CoreResourceManager/).
- Create a `Resources` folder in your project directory.
- Add the following to your `.csproj`:
```
<ItemGroup>
  <EmbeddedResource Include="Resources/**" />
</ItemGroup>
```
- Call `Resource.Get(NAME)` where `NAME` is the resource name (e.g. if you added a file called `foo.txt` in the resources folder, this will be `Resource.Get("foo.txt")`.