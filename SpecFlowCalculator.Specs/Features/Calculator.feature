Feature: Calculator

Calculator for adding two numbers

@calculator

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 120
	And   the second number is 70
	When  the two numbers are subtracted
	Then  the result should be 50


Scenario Outline: Divide two numbers
	Given I have entered <First> into the calculator
	And   I also have entered <Second> into the calculator
	When  I press add button
	Then  the result must be <Result> on the screen

Examples: 
	| First | Second | Result |
	| 10    | 5      | 2      |
	| 12    | 3      | 4      |
