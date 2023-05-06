Feature: Calculator

Calculator for adding two numbers

@calculator


Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two number
	Given the first number is 120
	And   the second number is 70
	When  the two numbers are subtracted
	Then  the result should be 50

