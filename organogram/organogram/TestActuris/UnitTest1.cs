using System;
using Xunit;
using Acturis_1;
using System.Collections.Generic;
using System.Linq;

namespace TestActuris
{
    public class UnitTest1
    {

        [Fact]
        public void TestSplitData()
        {
            var emp = new Employee("19,18,Samantha,McFee,Oracle,Johannesburg,Junior Analyst,0826984512,0113589799,0113589798");
            
            emp.SplitData();
            
            Assert.Equal(19, emp.RowId);
            Assert.Equal(18, emp.ParentRecord);
            Assert.Equal("Samantha", emp.Name);
            Assert.Equal("McFee", emp.Surname);
            Assert.Equal("Oracle", emp.Company);
            Assert.Equal("Johannesburg", emp.Place);
            Assert.Equal("Junior Analyst", emp.Position);
            Assert.Equal("0826984512", emp.Data1);
            Assert.Equal("0113589799", emp.Data2);
            Assert.Equal("0113589798", emp.Data3);

        }

        [Fact]
        public void TestWriteDta()
        {
            var emp = new Employee("19,18,Samantha,McFee,Oracle,Johannesburg,Junior Analyst,0826984512,0113589799,0113589798");

            emp.SplitData();
            string result = emp.WriteData();

            Assert.Equal("  19 18 Samantha McFee Oracle Johannesburg Junior Analyst 0826984512 0113589799 0113589798 ", result);
        }
    }
}
