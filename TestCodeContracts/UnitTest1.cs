using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;

namespace TestCodeContracts
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void DividirComErro()
        {
            Dividir(10, 0);
        }

        [TestMethod]
        public void DividirSemErro()
        {
            Dividir(10, 0);
        }

        float Dividir(int valor, int divisor)
        {
            return valor / divisor;
        }

        float DividirComVerificacao(float valor, float divisor)
        {
            Contract.Requires(divisor > 0);
            return valor / divisor;
        }
    }
}
