using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/5/2018 9:18:45 PM
* bradyxiao
*/
namespace Demo.test
{
    class Test
    {
        protected string protectedValue;

        public string publicValue;

        private string privateValue;

        internal string internaleValue;

        protected internal string protectedInternalValue;
    }

    class Test2
    {
        public Test2()
        {
            Test test = new Test();
            test.internaleValue = "interanl value";
            test.protectedInternalValue = "protected interanl value";
            test.publicValue = "public value";
        }
    }
}
