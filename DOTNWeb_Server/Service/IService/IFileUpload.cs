﻿using Microsoft.AspNetCore.Components.Forms;
using System.Net;

namespace DOTNWeb_Server.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filePath);

    }
}
