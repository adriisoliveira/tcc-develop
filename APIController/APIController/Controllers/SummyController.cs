<<<<<<< HEAD
﻿using APIController.Business.Entity.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
=======
﻿using APIController.Models.Summarization;
using APISummarizationClient.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
>>>>>>> feature/develop/TCC-31-Front-Controller-PythonAPI

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
<<<<<<< HEAD
    [Route("summy")]
    public class SummyController : ControllerBase
    {
        
=======
    [Route("summarization")]
    public class SummyController : ControllerBase
    {
        protected IApiClient _client;
        public SummyController(IApiClient client) => _client = client;

        [HttpPost]
        [Route("summy")]
        public string Summy([FromBody] SummyApiModel summy)
        {
            var summyData = _client.Summarization.SummyLuhn(summy.Text, summy.LineQuantity);
            return ( summyData.Text);
        }
>>>>>>> feature/develop/TCC-31-Front-Controller-PythonAPI
    }
}
