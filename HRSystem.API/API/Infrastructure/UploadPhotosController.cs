using HRSystem.Application.Repositories;
using HRSystem.Persistence.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HRSystem.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadPhotosController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogEmployeeRepository _logEmployeeRepository;
        private readonly NotificationService _notificationService;

        public UploadPhotosController(IEmployeeRepository employeeRepository,
                                      ILogEmployeeRepository logEmployeeRepository, 
                                      NotificationService notificationService)
        {
            _employeeRepository = employeeRepository;
            _logEmployeeRepository = logEmployeeRepository;
            _notificationService = notificationService;            
        }

        // POST api/<UploadPhotosController>
        [HttpPost("{employeeID}")]
        public async Task<ActionResult> Post(int employeeID, IFormFile file)
        {
            try
            {                
                if (file.Length > 0)
                {
                    var fileSystemName = Guid.NewGuid().ToString();                   

                    var folderName = Path.Combine("Resources", "Photos");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileExtenstion = Path.GetExtension(fileName);

                    var fileSystemNameWithExtenstion = $"{fileSystemName}{fileExtenstion}";
                    var fullPath = Path.Combine(pathToSave, fileSystemNameWithExtenstion);
                    var dbPath = Path.Combine(folderName, fileSystemNameWithExtenstion);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    await _employeeRepository.UpdatePhoto(employeeID, fileSystemNameWithExtenstion);                   

                    if (await _employeeRepository.SaveChanges() > 0)
                    {
                        var employee = await _employeeRepository.GetById(employeeID);
                        await _logEmployeeRepository.Log(employee);
                        await _employeeRepository.SaveChanges();
                    }

                    //Send Notification
                    _notificationService.SendNotificaion("EMPLOYEE_PHOTO");

                    return Ok(new { fileSystemNameWithExtenstion });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
