using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DokanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                var dbPaths = new List<string>();
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    dbPaths.Add(dbPath);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok(new { dbPaths });

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult Get(string imagePath = null)
        {
            try
            {
                if (imagePath != null || imagePath != "null")
                {
                    Byte[] b = System.IO.File.ReadAllBytes(imagePath);
                    string mimeType = GetContentType(imagePath);
                    return File(b, mimeType);
                }

                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        private string GetContentType(string fname)
        {
            string contentType = "application/octet-stream";
            try
            {
                // get the registry classes root
                Microsoft.Win32.RegistryKey classes = Microsoft.Win32.Registry.ClassesRoot;

                // find the sub key based on the file extension
                Microsoft.Win32.RegistryKey fileClass = classes.OpenSubKey(Path.GetExtension(fname));
                contentType = fileClass.GetValue("Content Type").ToString();
            }
            catch { }

            return contentType;
        }
    }
}