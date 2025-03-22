using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OrderDeliverySystemDataAccessLayer.People;
using OrderDeliverySystemBusinessLayer.Person;
using System.Linq.Expressions;

namespace OrderDeliverySystemAPi.Controllers.Person
{
    [Route("api/People")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonData BusinessLayer;

        [HttpGet("GetPerson{id}")]
        public ActionResult<PersonService> GetPersonById(int id)
        {
            var person = PersonData.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpGet("GetAll")]
        public ActionResult<List<PersonService>> GetAllPeople()
        {
            var PeopleList = PersonData.FindAll();

            if (PeopleList == null | PeopleList.Count == 0)

                return NotFound("No People Found");
            else
                return Ok(PeopleList);
        }


        [HttpDelete("DeletePerson{id}")]
        public ActionResult<int> DeletePerson(int id)
        {
            int IsDeleted = PersonData.DeletePerson(id);
            if (IsDeleted == 0)
            {
                return NotFound($"Person with ID {id} not found.");
            }
            return Ok($"Person with ID {id} deleted successfully.");
        }

        [HttpPut("UpdatePerson{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DataAccessPersonDTO> UpdatePerson(int id, DataAccessPersonDTO Updatedperson)
        {
            if (id < 1 || Updatedperson == null || string.IsNullOrEmpty(Updatedperson.FullName) || id != Updatedperson.PersonID)
            {
                return BadRequest("Invalid person data or ID.");
            }

            PersonService person = PersonService.Find(id);

            if (person == null)
            {
                return NotFound(new { message = "Person not found or update failed." });

            }


            person.FullName = Updatedperson.FullName;
            person.PersonID = Updatedperson.PersonID;
            person.Email = Updatedperson.Email;
            person.PhoneNumber = Updatedperson.PhoneNumber;
            person.BirthDate = Updatedperson.BirthDate;
            person.AreaID = Updatedperson.AreaID;
            PersonService.UpdatePerson(person);

            return Ok(person.PDTO);
        }

        [HttpPost("AddNewPerson")]
        public ActionResult<PersonService> AddNewArea(DataAccessPersonDTO NewPerson)
        {
            if (NewPerson == null)
            {
                return BadRequest("There Are An Error Try Again");
            }
            PersonService Person
                = new PersonService(new DataAccessPersonDTO(NewPerson.PersonID, NewPerson.FullName,
                                                                    NewPerson.Email, NewPerson.PhoneNumber, NewPerson.BirthDate,
                                                                    NewPerson.AreaID, NewPerson.CreatedAt, NewPerson.UpdatedAt,
                                                                    NewPerson.IsDeleted));
            PersonData.AddNewPerson(Person.PDTO);
            return Ok(NewPerson);
        }
    }
}
