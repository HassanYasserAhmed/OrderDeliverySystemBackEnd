using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportDeliverySystemDataAccessLayer.Report;

namespace ReportDeliverySystemAPi.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("GetReport{ReportID}")]
        public ActionResult<ReportDTO> GetReport(int ReportID)
        {
            var Report = ReportData.Find(ReportID);
            if (Report == null)
            {
                return NotFound("Not Found");
            }
            return Ok(Report);
        }
        [HttpGet("GetAllReports")]
        public ActionResult<List<ReportDTO>> GetAllReports()
        {
            var ReportsList = ReportData.FindAll();

            if (ReportsList == null | ReportsList.Count == 0)

                return NotFound("No Reports Found");
            else
                return Ok(ReportsList);
        }


        [HttpDelete("DeleteReport{ReportID}")]
        public ActionResult<int> DeleteReport(int ReportID)
        {
            int IsDeleted = ReportData.Delete(ReportID);
            if (IsDeleted == 0)
            {
                return NotFound($"Person with ID {ReportID} not found.");
            }
            return Ok($"Person with ID {ReportID} Deleted successfully.");
        }


        [HttpPost("AddNewPerson")]
        public ActionResult<ReportDTO> AddNewReport()
        {

            int Result =ReportData.Add();
            if(Result ==0 )
            {
                return BadRequest("Ther Are An Error");
            }
            return Ok($"Report Added Successfully");
        }
    }
}
