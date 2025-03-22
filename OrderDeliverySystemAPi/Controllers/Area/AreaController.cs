using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemDataAccessLayer;
using OrderDeliverySystemBusinessLayer;
using OrderDeliverySystemBusinessLayer.Area;
using OrderDeliverySystemDataAccessLayer.Area;
using Microsoft.AspNetCore.Identity;

namespace OrderDeliverySystemAPi.Controllers.Area
{
    [Route("api/Areas")]
    [ApiController]
    public class AreaController : ControllerBase
    {

        [HttpGet("GetArea{id}", Name = "GetArea")]
        public ActionResult<AreaService> GetArea(int id)
        {
            var Area = AreaData.Find(id);
            if (Area == null)
            {
                return NotFound("Area Not Found");
            }
            else
            {
                return Ok(Area);
            }
        }


        [HttpGet("GetAllAreas")]
        public ActionResult<AreaService> GetAllAreas()
        {
            var Areas = AreaData.FindAll();
            if (Areas == null)
            {
                return NotFound("Area Not Found");
            }
            else
            {
                return Ok(Areas);
            }
        }

        [HttpPost("AddNewArea")]
        public ActionResult<AreaService> AddNewArea(AreaDTO NewAreaDTO)
        {
            if (NewAreaDTO == null)
            {
                return BadRequest("Somthing Error Accured");
            }
            AreaService Area = new AreaService(new AreaDTO(NewAreaDTO.AreaID, NewAreaDTO.AreaName,
                                                                                                          NewAreaDTO.Governerate, NewAreaDTO.IsActive, NewAreaDTO.DeliveryFee,
                                                                                                          NewAreaDTO.CreatedAt, NewAreaDTO.UpdatedAt, NewAreaDTO.IsDeleted));
            int Result = AreaData.Add(Area.ADTO);

            //return CreatedAtRoute("GetArea", Area, NewAreaDTO);
            return CreatedAtRoute("GetArea", new { id = NewAreaDTO.AreaID }, NewAreaDTO);

        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            int Result = AreaData.Delete(id);
            if (Result == 0)
            {
                return BadRequest("There Are An Error");

            }
            return Ok("Area Deleted Successfully");
        }
        [HttpPut()]
        public ActionResult<AreaDTO> UpdateArea([FromBody] AreaDTO UpdatedArea)
        {
            var Area = AreaData.Find(UpdatedArea.AreaID);
            if (Area == null)
            {
                return NotFound("There is No Area here");
            }
            Area.AreaID = UpdatedArea.AreaID;
            Area.AreaName = UpdatedArea.AreaName;
            Area.Governerate = UpdatedArea.Governerate;
            Area.DeliveryFee = UpdatedArea.DeliveryFee;
            Area.IsActive = UpdatedArea.IsActive;
            int Result = AreaData.Update(Area);
            return Ok(Area);

        }
    }
}
