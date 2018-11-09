using System;
using System.Collections.Generic;

using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/9/2018 4:48:37 PM
* bradyxiao
*/
namespace Demo.test
{
    public class InterfaceTest
    {
        private Listener listener;

        public void SetListener(Listener listener)
        {
            this.listener = listener;
        }

        public void test()
        {
            listener.GetResult("ok");
        }
    }

    public class Impl : Listener
    {
        public void GetResult(string value)
        {
            Console.WriteLine(value);
        }
    }

    public interface Listener
    {
        void GetResult(string value);
    }
}
