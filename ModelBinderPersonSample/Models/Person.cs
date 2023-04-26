using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ModelBinderPersonSample.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public int Age { get; set; }

    }

    public class Student : Person
    {

    }

    public class Teacher : Person
    {

    }
   
}
