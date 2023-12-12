using ServiceContract;
using ServiceContract.DTO;
using Services;
using System;
using System.Collections.Generic;
using Xunit;
namespace TestProject1
{
    public class PersonsServiceTest
    {
        private readonly IPersonsServices _personsServices;
        
        public PersonsServiceTest()
        {
            _personsServices=new PersonsServices();
        }

        #region AddPerson

        // when PersonAddRequest == null  : throw ArgumentNullException
        [Fact]
        public void AddPerson_nullPerson()
        {
            //Arange
            PersonAddRequest? personAddRequest = null;

            //Act
                
        }

        #endregion
    }
}
