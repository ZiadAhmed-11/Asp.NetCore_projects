using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_1
{
    //<classModifier> <class> <className>
    //<classModifier> -> public , internal(default)
    //{
    //  class Block;
    //}
    public class Employee
    {
        //Constant -> <AccessModifier> const <DataType> <ConstantName> = <Value>;
        //fields -> <AccessModifier> <Datatype> <fieldName> = <initialValue>;
        //<AccessModifier> -> public , private, protected
        public static double Tax = 0.03;
        public string fname;
        public string lname;
        public double wage;
        public double loggedhours;

    }
}
