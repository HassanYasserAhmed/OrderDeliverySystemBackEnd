using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.People;

namespace OrderDeliverySystemBusinessLayer.Person
{



    public class PersonService
    {
        public enum enMode { AddNew = 0, Update = 1, Get = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public DataAccessPersonDTO PDTO => new DataAccessPersonDTO(
            PersonID,
            FullName,
            Email,
            PhoneNumber,
            BirthDate,
            AreaID,
            CreatedAt,
            UpdatedAt,
            IsDeleted
        );

        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public int? AreaID { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public PersonService() { }

        public PersonService(DataAccessPersonDTO PDTO)
        {
            if (PDTO == null)
                throw new ArgumentNullException(nameof(PDTO));

            PersonID = PDTO.PersonID;
            FullName = PDTO.FullName;
            Email = PDTO.Email;
            PhoneNumber = PDTO.PhoneNumber;
            BirthDate = PDTO.BirthDate;
            AreaID = PDTO.AreaID;
            CreatedAt = PDTO.CreatedAt;
            UpdatedAt = PDTO.UpdatedAt;
            IsDeleted = PDTO.IsDeleted;
        }

        public static PersonService Find(int ID)
        {
            var PDTO = PersonData.Find(ID);
            return PDTO != null ? new PersonService(PDTO) : null;
        }

        public static List<PersonService> FindAll()
        {
            var peopleDTOList = PersonData.FindAll() ?? new List<DataAccessPersonDTO>();
            return peopleDTOList.Select(personDTO => new PersonService(personDTO)).ToList();
        }

        public static int DeletePerson(int id)
        {
            return PersonData.DeletePerson(id);
        }

        public static int UpdatePerson(PersonService personService)
        {
            if (personService == null)
                throw new ArgumentNullException(nameof(personService));

            var personDTO = personService.PDTO;
            return PersonData.UpdatePerson(personDTO);
        }

        public static int AddNewPerson(DataAccessPersonDTO NewPerson)
        {
            return PersonData.AddNewPerson(NewPerson);
        }
    }

}
