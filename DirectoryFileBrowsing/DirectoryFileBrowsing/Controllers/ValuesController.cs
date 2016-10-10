using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Web.Http;
using DirectoryFileBrowsing.Models;

namespace DirectoryFileBrowsing.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        public Files Get(string path)
        {
            var model = new Files();
            try
            {
                model.Warning = "";
                var directories = Directory.EnumerateDirectories(path);
                var files = Directory.EnumerateFiles(path);
        
                model.Names = directories.Concat(files);
                foreach (var dir in directories)
                {
                    var size = GetFolderSize(dir);
                    if (size <= 10485760)
                        model.First++;
                    else if (size > 10485760 && size <= 52428800)
                        model.Second++;
                    else if (size >= 104857600)
                        model.Third++;
                }
                foreach (var file in files)
                {
                    var size = new FileInfo(file).Length;
                    if (size <= 10485760)
                        model.First++;
                    else if (size > 10485760 && size <= 52428800)
                        model.Second++;
                    else if (size >= 104857600)
                        model.Third++;
                }

                return model;
            }
            catch (DirectoryNotFoundException ex)
            {
                model.Warning = ex.Message;
                return model;
            }
        }

        long GetFolderSize(string path)
        {
            long result = 0;
            try
            {
                foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    result += new FileInfo(file).Length;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
            }
            return result;
        }
    }
}
