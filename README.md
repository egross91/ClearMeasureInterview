# Clear Measure Interview
A flexible and testable implementation of [FizzBuzz](https://en.wikipedia.org/wiki/Fizz_buzz). 

## Requirements
-  [Visual Studio 2017](https://www.visualstudio.com/downloads/)

### Installation

#### Build from Visual Studio
Just clone the repo and open solution (.sln) in Visual Studio.

#### Build from CLI
**Only works with Mac.**

```
cd path/to/proj/scripts
```
```
./build_mac.sh
```

##### Aside
I did attempt to get the Windows build script working but did not bother after running into numerous issues.

### Testing
Tests were created using NUnit 3.7.1. 

#### Run Tests in Visual Studio
Build the solution and run the tests using [NUnit Test Adapter](https://www.nuget.org/packages/NUnit3TestAdapter/).

#### Run Tests from CLI
*Requires solution to be built first.*

- Install [NUnit3 Console](https://www.nuget.org/packages/NUnit.Console).

- Run:
```
nunit3-console /path/to/proj/FizzBuzzNUnitTests/bin/Debug/FizzBuzzNUnitTests.dll
```