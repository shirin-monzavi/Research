// See https://aka.ms/new-console-template for more information
using TemplateMethodDesignPatternSample;

var houseLoan = new HousLoanConcret();
houseLoan.GetLoan();
Console.WriteLine("<------------------>");
var productLoanConcret = new ProductLoanConcret();
productLoanConcret.GetLoan();

