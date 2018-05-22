[![CircleCI](https://circleci.com/gh/CptWesley/CoreResourceManager.svg?style=shield)](https://circleci.com/gh/CptWesley/CoreResourceManager)
[![BetterCodeHub](https://bettercodehub.com/edge/badge/CptWesley/CoreResourceManager?branch=master)](https://bettercodehub.com/results/CptWesley/CoreResourceManager)
[![CodeCov](https://codecov.io/gh/CptWesley/CoreResourceManager/branch/master/graph/badge.svg)](https://codecov.io/gh/CptWesley/CoreResourceManager/)

# CoreResourceManager
Simplifies dealing with embedded resources in .NET core projects.

#### Prerequisites:
- Application supporting .NET Standard.

#### Usage:
- Get the [nuget](https://www.nuget.org/packages/CoreResourceManager/).
- Add the following to your `.csproj`:
```
<ItemGroup>
  <EmbeddedResource Include="Resources/**" />
</ItemGroup>
```