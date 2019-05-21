﻿using System;
using Flunt.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flunt.Tests
{
    [TestClass]
    public class DecimalContractTests
    {
        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanDecimal()
        {
            decimal v1 = 5;
            decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2")
                .IsGreaterThan(1, 1M, "decimal", "V1 is not greater than v2"); // 1 is not greater than 1 :)

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(2, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsGreaterThan(v2, v1, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanDouble()
        {
            double v1 = 5;
            decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            v1 = 10;
            v2 = 5;
            var right = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanFloat()
        {
            float v1 = 5;
            decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            v1 = 10;
            v2 = 5;
            var right = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanInt()
        {
            int v1 = 5;
            decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsGreaterThan(v2, v1, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.Valid);
        }       

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsBetweenDecimal()
        {
            decimal value = -1.01M;
            decimal from = 1.01M;
            decimal to = 10;

            var wrong = new Contract()
                .Requires()
                .IsBetween(value, from, to, "decimal", "The value -1.01 must be between 1.01 and 10");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            value = 1.015M;
            from = 1.01M;
            to = 1.02M;

            var right = new Contract()
                .Requires()
                .IsBetween(value, from, to, "decimal", "The value 1.015 is between 1.01 and 1.02");

            Assert.AreEqual(true, right.Valid);
        }  

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsNullOrNullable()
        {            
            var value = new Nullable<decimal>();
            
            var wrong = new Contract()
                .Requires()
                .IsNullOrNullable(value, "decimal", "The decimal is required");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            Nullable<DateTime> valueNull = null;
            
            var wrongNull = new Contract()
                .Requires()
                .IsNullOrNullable(valueNull, "decimal", "The decimal is required");

            Assert.AreEqual(false, wrongNull.Valid);
            Assert.AreEqual(1, wrongNull.Notifications.Count);


            var right = new Contract()
                .Requires()
                .IsNullOrNullable(10m, "decimal", "The decimal is required");

            Assert.AreEqual(true, right.Valid);
        }

    }
}
