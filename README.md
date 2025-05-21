# FlaUI Testing on Calculator using FluentAPI pattern

## Overview

- This testing library can be used to test the Windows Calculator application using [FlaUI](https://docs.google.com/document/d/1J81neFboMnpdDmU-KBTnSdujf7LQ52M2/edit?tab=t.0).
- It uses the [Fluent API](https://dotnettutorials.net/lesson/fluent-interface-design-pattern/) pattern to provide a more readable and maintainable code structure.
- It supports basic calculator operations such as addition, subtraction, multiplication, and division.
- The operations can be performed with the method call syntax, making it easy to understand the flow of the test.
- The test cases are designed to be simple and straightforward, focusing on the core functionality of the calculator.

## Software Requirements
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- FlaUI.Core and FlaUI.UIA3 libraries
- Windows Calculator application (pre-installed on Windows 10 and later)
  
<img height="50" src="https://github.com/user-attachments/assets/a3b58d87-a855-4cb4-98d5-21ff0b8ad2dc">
<img height="50" src="https://github.com/user-attachments/assets/4b87d884-6501-4f44-8c38-2aa2225f13aa">

[![.NET](https://skillicons.dev/icons?i=visualstudio,dotnet)](https://skillicons.dev)

## To Get Started
1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution to restore the necessary packages.
4. Run the test cases using the Test Explorer in Visual Studio.
5. Ensure that the Windows Calculator application is installed and accessible on your machine.
6. The test cases will launch the calculator application, perform the specified operations, and verify the results.

## Test Cases
- TestAddition: Tests the addition operation by adding two numbers and verifying the result.
- TestSubtraction: Tests the subtraction operation by subtracting two numbers and verifying the result.
- TestMultiplication: Tests the multiplication operation by multiplying two numbers and verifying the result.
- TestDivision: Tests the division operation by dividing two numbers and verifying the result.
- TestComplexOperation: Tests a complex operation by performing multiple calculations in sequence and verifying the final result.

## Example Usage
The following example demonstrates how to use the Fluent API pattern to perform a simple addition operation and a complex operation:
```csharp

[TestMethod]
public void TestAddition()
{
	var calculator = new CalculatorTester();
	var result = calculator.Add(5, 3);
	Assert.AreEqual(8, result);
}

[TestMethod]
public void ComplexOperation()
{
	var calculator = new CalculatorTester();
	var result = calculator.Add(5, 3)
		.Subtract(2)
		.Multiply(4)
		.Divide(2);
	Assert.AreEqual(12, result);
}
```

## Implementation Details

![image](https://github.com/user-attachments/assets/470ca7d4-d042-407e-a8a8-da461e39dcdb)


[InputFormatter.cs](FlaUICalculatorTesting/FlaUICalculatorTesting/Helper/InputFormatter.cs) 

- This class is responsible for formatting the input values for the calculator operations in UI. 
- It ensures that the input values are formatted to the list of buttons to be clicked in the calculator UI.

[ICalculatorElements.cs](FlaUICalculatorTesting/FlaUICalculatorTesting/Models/ICalculatorElements.cs)
- This interface defines the elements of the calculator UI that will be interacted with during testing.
- It includes properties for the calculator buttons and display elements.
- Having an interface allows for better abstraction and easier maintenance of the code as there are multiple versions of the calculator are available in Windows.

[Windows11CalculatorElements.cs](FlaUICalculatorTesting/FlaUICalculatorTesting/Models/Windows11CalculatorElements.cs)
- This class implements the ICalculatorElements interface and provides the actual implementation for interacting with the calculator UI elements.
- It uses FlaUI to find and the calculator buttons and display elements.

[CalculatorTester.cs](FlaUICalculatorTesting/FlaUICalculatorTesting/CalculatorTester.cs)
- This class contains the main logic for interacting with the Windows Calculator application using FlaUI.
- It wraps the FlaUI functionality in a fluent API style, allowing for easy chaining of operations.
- The class includes methods for performing basic arithmetic operations (addition, subtraction, multiplication, division).

[CalculatorUITests.cs](FlaUICalculatorTesting/FlaUICalculatorTesting/CalculatorUITests.cs)
- This class is a test class that contains the test methods for the calculator operations.
- It contains test methods for addition, subtraction, multiplication, division, and complex operations.
- Each test method uses the CalculatorTester class to perform the operations and verify the results.

## References

- [FlaUI GitHub Repository](https://github.com/FlaUI/FlaUI)
- FlaUI Another approach integrating with Microsoft Excel CSV File : [Click Here](https://github.com/Srihari2025/FlaUI)
- [Self Made Notes](https://docs.google.com/document/d/1J81neFboMnpdDmU-KBTnSdujf7LQ52M2/edit?tab=t.0)
- [Fluent API pattern](https://dotnettutorials.net/lesson/fluent-interface-design-pattern/)
