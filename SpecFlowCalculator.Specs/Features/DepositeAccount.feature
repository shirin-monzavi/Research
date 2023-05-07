Feature: DepositeAccount

A short summary of the feature

@Deposite
Scenario: Deposite from an account
	Given the below information account is given
		| Name | HeightInInches | BankAccountBalance |
		| John | 72             | 10                 |
	When I deposite 5$
	Then The account should be
		| Name | HeightInInches | BankAccountBalance |
		| John | 72             | 5                 |
