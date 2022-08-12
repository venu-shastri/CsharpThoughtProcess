using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public  class RequiredValidatorAttribute:System.Attribute
    {
        public string ErrorMessage { get; set; }
        public bool Validate(object data)
        {
            string _value= data.ToString();
            return string.IsNullOrEmpty(_value);
        }
    }
}
