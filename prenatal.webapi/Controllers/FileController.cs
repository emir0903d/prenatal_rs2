﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prenatal.model;
using prenatal.model.Requests;
using prenatal.webapi.Database;
using prenatal.webapi.Filters;
using prenatal.webapi.Services;

namespace prenatal.webapi.Controllers
{

    public class FileController
        : CRUDController<File, object, FileUpsertRequest, FileUpsertRequest, Files>
    {
        public FileController(ICRUDservice<File, object, FileUpsertRequest, FileUpsertRequest,Files> baseService) : base(baseService)
        {
        }
    }
}
